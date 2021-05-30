using OrdenesCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenesCore.Exceptions
{
    public class MessagesObtenerOrdenesxCliente
    {
        public MessagesObtenerOrdenesxCliente()
        {
        }

        public ResponseOrdenesByCliente NoFoundOrdenes(ResponseOrdenesByCliente respuesta)
        {

            respuesta.Codigo = 0;
            respuesta.Mensaje = "El cliente no tiene ninguna orden";
            return respuesta;
        }

        public ResponseOrdenesByCliente OkFoundOrdenes(ResponseOrdenesByCliente respuesta)
        {
            respuesta.Codigo = 1;
            respuesta.Mensaje = "Las órdenes del cliente se encontraron exitosamente";
            return respuesta;
        }
    }
}

