using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenesCore.Interfaces;
using OrdenesCore.DTO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdenesApi.Controllers
{
    [Route("Prod/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private IOrdenService _servicio;
        private IRestClientCarritoCompras _restClientCarritoCompras;
        private IRestClientBroker _restClientBroker;
        private ISendEmails _sendEmails;

        public OrdenController(IOrdenService servicio, IRestClientCarritoCompras restClientCarritoCompras, IRestClientBroker restClientBroker, ISendEmails sendEmails)
        {
            _servicio = servicio;
            _restClientCarritoCompras = restClientCarritoCompras;
            _restClientBroker = restClientBroker;
            _sendEmails = sendEmails;
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
        public async Task<ActionResult<Orden>> Post([FromBody] Orden orden)
        {
            Orden resultado;
            if (!await _restClientCarritoCompras.GetProductAvailability(orden.CarritoId))
                return ValidationProblem("NoAvailability");
            if (!await _restClientCarritoCompras.DeleteCarritoCompras(orden.CarritoId))
                return ValidationProblem("OrderWasNotCreated");
            resultado = await _servicio.CreateOrden(orden);
            if (resultado == null)
                return BadRequest();
            if (!await _restClientBroker.CreateOrdenBroker(orden))
                return BadRequest();
            string body = this.GetMsgEmail(orden);
            if (!await _sendEmails.SendEmail(orden.EmailCliente, body))
                return BadRequest();
            return Ok(resultado);
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
            await _servicio.deleteOrden(codigoOrden);
        }

        public string GetMsgEmail(Orden orden)
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
                "<h4>Número de orden:" + orden.Id.ToString() + "<h4Z" +
                "<span>Tenemos noticias," + orden.EmailCliente + "<span>" +
                "<br/><br/>" +
    "<span>Tu pedido ha sido aceptado. Iniciaremos con la preparación de tu orden. Recibirás el estado del envío y tu factura en correos electrónicos independiente.<span>" +

    "<br/><br/>" +
    "<span>Gracias por tu compra.<span>" +
    "<br/><br/>" +
    "<span>El equipo K' ALL SONY.<span>" +
"<body>";
                    return bodyOrdenAceptada;

                default:
                    return null;
            }

        }
    }
}
