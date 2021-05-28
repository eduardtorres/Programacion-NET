using System;
using System.Collections.Generic;
using System.Text;

namespace ProveedoresCore.DTO
{
    public class OrdenesRequestDTO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string codigoProveedor { get; set; }
        public string tipoProveedor { get; set; }
        public int CantidadOrdenada { get; set; }
    }
}