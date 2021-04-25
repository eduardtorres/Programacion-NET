using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductosCore.Entities
{
    [Serializable]
    public class FabricanteEntity
    {
        public FabricanteEntity()
        {

        }

        [Key]
        public long IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string UrlServicio { get; internal set; }
    }
}
