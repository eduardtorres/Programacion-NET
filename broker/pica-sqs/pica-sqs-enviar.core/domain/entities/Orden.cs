using System;
using System.Collections.Generic;

namespace pica_sqs_enviar.core.domain.entities
{
    public class Orden
    {
        public long Id { get; set; }
        public string Estado { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaEnvio { get; set; }
        public string FechaUltimaActualizacion { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal ValorImpuestos { get; set; }
        public string NumeroDocumentoCliente { get; set; }
        public string TipoDocumentoCliente { get; set; }
        public string EmailCliente { get; set; }
        public string DireccionFacturacion { get; set; }
        public string CiudadFacturacion { get; set; }
        public string EstadoFacturacion { get; set; }
        public string PaisFacturacion { get; set; }
        public string CodigoAreaFacturacion { get; set; }
        public string CorreoElectronicoFacturacion { get; set; }
        public string TelefonoFacturacion { get; set; }
        public string DireccionEnvio { get; set; }
        public string CiudadEnvio { get; set; }
        public string EstadoEnvio { get; set; }
        public string PaisEnvio { get; set; }
        public string CodigoAreaEnvio { get; set; }
        public string NombreEnvio { get; set; }
        public string ApellidoEnvio { get; set; }
        public string TelefonoEnvio { get; set; }
        public long PagoId { get; set; }
        public long CarritoId { get; set; }
        public IList<DetalleOrden> DetallesOrden { get; set; }
        public IList<DatosPago> DatosPago { get; set; }
    }
}
