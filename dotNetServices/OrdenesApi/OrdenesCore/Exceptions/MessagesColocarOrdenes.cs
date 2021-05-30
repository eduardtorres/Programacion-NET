using OrdenesCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenesCore.Exceptions
{
    public class MessagesColocarOrdenes
    {
        public MessagesColocarOrdenes()
        {
        }

        public ResponseColocarOrden NoAvailability()
        {
            ResponseColocarOrden resultado = new ResponseColocarOrden
            {
                codigo = 0,
                mensaje = "Alguno de los productos no está disponible"
            };
            return resultado;
        }

        public ResponseColocarOrden ErrorCreateOrdenBroker()
        {
            ResponseColocarOrden resultado = new ResponseColocarOrden
            {
                codigo = 0,
                mensaje = "No es posible generar número de orden"
            };
            return resultado;
        }

        public ResponseColocarOrden OKCreateOrdenBroker()
        {
            ResponseColocarOrden resultado = new ResponseColocarOrden
            {

                codigo = 1,
                mensaje = "El número de orden fue creado exitosamente"
            };
            return resultado;
        }



    }
}
