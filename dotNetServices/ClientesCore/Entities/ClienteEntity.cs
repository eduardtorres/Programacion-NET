using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientesCore.Entities
{
    [Serializable]
    public class ClienteEntity
    {
        public ClienteEntity()
        {

        }

        [Key]
        public long IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
