using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenesCore.DTO
{
    public class RequestDescargarInventario
    {

        public string codigo { get; set; }
        public string codigoProveedor { get; set; }
        public string tipoProveedor { get; set; }
        public int CantidadOrdenada { get; set; }
    }
}
