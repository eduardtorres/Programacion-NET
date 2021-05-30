using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenesCore.DTO
{
    public class ResponseOrdenesByCliente
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }

        public IEnumerable<OrdenesByCliente> OrdenesByCliente { get; set; }
    }
}
