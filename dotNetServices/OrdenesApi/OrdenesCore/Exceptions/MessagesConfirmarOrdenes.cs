using OrdenesCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenesCore.Exceptions
{
    public class MessagesConfirmarOrdenes
    {
        public MessagesConfirmarOrdenes()
        {

        }

        public ResponseConfirmarOrden OkOrden()
        {
            ResponseConfirmarOrden resultado = new ResponseConfirmarOrden
            {
                codigo = 1,
                mensaje = "Orden creada y notificada"
            };
            return resultado;
        }

        public ResponseConfirmarOrden BadOrden()
        {
            ResponseConfirmarOrden resultado = new ResponseConfirmarOrden
            {
                codigo = 0,
                mensaje = "Error en la creación de la orden"
            };
            return resultado;
        }
        public ResponseConfirmarOrden EmailNoSend()
        {
            ResponseConfirmarOrden resultado = new ResponseConfirmarOrden
            {
                codigo = 1,
                mensaje = "Orden creada y error en el envío de correo"
            };
            return resultado;
        }
    }
}
