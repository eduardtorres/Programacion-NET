using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProveedoresCore.DTO
{
    [Serializable]
    public class ProveedorDTO
    {
        [Key]
        public long IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string UrlServicio { get; set; }
        public string TipoApi { get; set; }
        public string MetodoApi { get; set; }
        public string TransformacionProductos { get; set; }
        public string TransformacionOrdenes { get; set; }
        public string SOAPAction { get; set; }
        public string Body { get; set; }
    }
}
