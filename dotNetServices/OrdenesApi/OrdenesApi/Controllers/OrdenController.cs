using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenesCore.Interfaces;
using OrdenesCore.DTO;
using OrdenesCore.Exceptions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdenesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private IOrdenService _servicio;
        private IRestClientCarritoCompras _restClientCarritoCompras;
        private IRestClientBroker _restClientBroker;
        private IRestClientPagos _restClientPagos;
        private IRestClientInventario _restClientInventario;
        private ISendEmails _sendEmails;

        public OrdenController(IOrdenService servicio, IRestClientCarritoCompras restClientCarritoCompras, IRestClientBroker restClientBroker, ISendEmails sendEmails, IRestClientPagos restClientPagos, IRestClientInventario restClientInventario)
        {
            _servicio = servicio;
            _restClientCarritoCompras = restClientCarritoCompras;
            _restClientBroker = restClientBroker;
            _sendEmails = sendEmails;
            _restClientPagos = restClientPagos;
            _restClientInventario = restClientInventario;
        }

        // GET: Prod/<OrdenesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> Get()
        {
            var resultado = await _servicio.GetOrdenes();
            if (resultado != null)
                return Ok(resultado);
            return NotFound();
        }

        // GET Prod/<OrdenesController>/5
        [HttpGet("{codigoOrden}")]
        public async Task<ActionResult<Orden>> Get(long codigoOrden)
        {
            var resultado = await _servicio.GetOrdenById(codigoOrden);
            if (resultado != null)
                return Ok(resultado);
            return NotFound();
        }

        // POST Prod/<OrdenesController>
        [HttpPost("colocar")]
        public async Task<ActionResult<ResponseColocarOrden>> Post([FromBody] Orden orden)
        {
            MessagesColocarOrdenes respuesta = new MessagesColocarOrdenes();
            if (!await _restClientCarritoCompras.GetProductAvailability(orden.CarritoId))
                return respuesta.NoAvailability();
            var ordenId = await _restClientBroker.CreateOrdenBroker(orden);
            if (ordenId == 0)
                return respuesta.ErrorCreateOrdenBroker();
            var resultado = respuesta.OKCreateOrdenBroker();
            resultado.OrdenId = ordenId;
            return resultado;
        }


        // POST Prod/<OrdenesController>
        [HttpPost("confirmar")]
        public async Task<ActionResult<ResponseConfirmarOrden>> Post([FromBody] RequestConfirmarOrden orden)
        {
            DatosPago datosPago;
            datosPago = orden.DatosPago.First();
            datosPago.Valor = orden.PrecioTotal;
            var resultadoPago = await _restClientPagos.AuthPaymentOrden(datosPago);
            if (resultadoPago == 0)
            {
                orden.Estado = "RECHAZADA";
                return await this.CreateNotificationOrden(orden);
            }
            orden.PagoId = resultadoPago;
            var resultadoInventario = await _restClientInventario.RemoveProductInventory(orden.DetallesOrden);
            if (resultadoInventario == 0)
            {
                orden.Estado = "PENDIENTE INVENTARIO";
                return await this.CreateNotificationOrden(orden);
            }
            orden.Estado = "ACEPTADA";
            return await this.CreateNotificationOrden(orden);
        }


        // PUT Prod/<OrdenesController>/5
        [HttpPut("{codigoOrden}")]
        public async Task<ActionResult<Orden>> Put(long codigoOrden, [FromBody] Orden orden)
        {
            var resultado = await _servicio.UpdateEstadoOrden(codigoOrden, orden);
            if (resultado != null)
                return Ok(resultado);
            return NotFound();

        }

        // DELETE api/<OrdenesController>/5
        [HttpDelete("{codigoOrden}")]
        public async Task Delete(long codigoOrden)
        {
            await _servicio.DeleteOrden(codigoOrden);
        }

        [HttpGet("ordenes_cliente/{email}")]
        public async Task<ActionResult<ResponseOrdenesByCliente>> Get(string email)
        {
            MessagesObtenerOrdenesxCliente resultadoOperacion = new MessagesObtenerOrdenesxCliente();
            ResponseOrdenesByCliente respuesta = new ResponseOrdenesByCliente();
            var resultado = await _servicio.GetOrdenesByCustomer(email);
            if (resultado != null)
            {
                respuesta = resultadoOperacion.OkFoundOrdenes(respuesta);
                respuesta.OrdenesByCliente = resultado;
                return respuesta;
            }
            respuesta = resultadoOperacion.NoFoundOrdenes(respuesta);
            return respuesta;
        }


        public async Task<ResponseConfirmarOrden> CreateNotificationOrden(RequestConfirmarOrden orden)
        {
            RequestConfirmarOrden ordenCreada;
            MessagesConfirmarOrdenes respuesta = new MessagesConfirmarOrdenes();
            string body;
            try
            {
                ordenCreada = await _servicio.CreateOrden(orden);
                if (ordenCreada == null)
                    return respuesta.BadOrden();
                body = this.GetMsgEmail(orden);
                if (!await _sendEmails.SendEmail(orden.EmailCliente, body))
                    return respuesta.EmailNoSend();
                return respuesta.OkOrden();
            }
            catch
            {
                return respuesta.BadOrden();
            }
        }




        public string GetMsgEmail(RequestConfirmarOrden orden)
        {
            string estadoOrden = orden.Estado; ;

            switch (estadoOrden)
            {

                case "PENDIENTE":
                    string bodyOrdenPendiente =
        "<body>" +
            "<h1>TU PEDIDO ESTA EN PROCESO DE APROBACIÓN </h1>" +
            "<h4>Número de orden:" + orden.Id.ToString() + "</h4>" +
            "<span>Tenemos noticias, " + orden.EmailCliente + "</span>" +
             "<br/><br/>" +
            "<span>Tu pedido ha sido recibido, pero está en proceso de pago. Recibirás un nuevo correo indicando el estado del pago y de tu orden.</span>" +
            "<br/><br/>" +
            "<span>Gracias por tu compra.</span>" +
            "<br/><br/>" +
            "<span>El equipo K' ALL SONY.</span>" +
        "<body>";
                    return bodyOrdenPendiente;

                case "RECHAZADA":
                    string bodyOrdenRechazada =
            "<body>" +
                "<h1>TU PEDIDO HA SIDO RECHAZADO <h1>" +
                "<h4>Número de orden:" + orden.Id.ToString() + "<h4Z" +
                "<span>Tenemos noticias, " + orden.EmailCliente + "<span>" +
                "<br/><br/>" +
    "<span>Tu pedido ha sido rechaza, el pago no fue exitoso. Te invitamos a intentar nuevamente hacer la compra.<span>" +
    "<br/><br/>" +
    "<span>Gracias.<span>" +
    "<br/><br/>" +
    "<span>El equipo K' ALL SONY.<span>" +
"<body>";
                    return bodyOrdenRechazada;

                case "ACEPTADA":
                    string bodyOrdenAceptada =
            "<body>" +
                "<h1>TU PEDIDO ESTA EN PROCESO DE APROBACION <h1>" +
                "<h4>Número de orden:" + orden.Id.ToString() + "<h4>" +
                "<span>Tenemos noticias," + orden.EmailCliente + "<span>" +
                "<br/><br/>" +
    "<span>Tu pedido ha sido aceptado. Iniciaremos con la preparación de tu orden. Recibirás el estado del envío y tu factura en correos electrónicos independiente.<span>" +

    "<br/><br/>" +
    "<span>Gracias por tu compra.<span>" +
    "<br/><br/>" +
    "<span>El equipo K' ALL SONY.<span>" +
"<body>";
                    return bodyOrdenAceptada;

                case "PENDIENTE INVENTARIO":

                    string bodyOrdenInventario =
            "<body>" +
                "<h1>TU PEDIDO ESTA EN PROCESO DE VERIFICACION DE INVENTARIO <h1>" +
                "<h4>Número de orden:" + orden.Id.ToString() + "<h4Z" +
                "<span>Tenemos noticias," + orden.EmailCliente + "<span>" +
                "<br/><br/>" +
    "<span>Tu pedido ha sido recibido. Iniciaremos con la verificación y preparación de tu orden. Recibirás el estado de tu orden en un nuevo correo.<span>" +

    "<br/><br/>" +
    "<span>Gracias por tu compra.<span>" +
    "<br/><br/>" +
    "<span>El equipo K' ALL SONY.<span>" +
"<body>";
                    return bodyOrdenInventario;

                default:
                    return null;
            }

        }
    }
}
