using System;
namespace ClientesCore.DTO
{
    public class AutenticarDTO
    {
        public ClienteDTO cliente { get; set; }
        public int code { get; set; }
        public string token { get; set; }
    }
}
