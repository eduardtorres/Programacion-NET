using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FabricantesCore.DTO
{
    [Serializable]
    public class FabricanteDTO
    {
        [Key]
        public long IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string UrlServicio { get; set; }
    }
}
