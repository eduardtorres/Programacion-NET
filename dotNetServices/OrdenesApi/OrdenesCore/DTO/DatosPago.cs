using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenesCore.DTO
{
   public  class DatosPago
    {
        public int MedioPago { get; set; }
        public string CodMoneda { get; set; }
        public int NumeroTarjeta { get; set; }
        public int MesExpiracion { get; set; }
        public int AnoExpiracion { get; set; }
        public string CodCV { get; set; }
        public string TipoTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public string Email { get; set; }
    }
}
