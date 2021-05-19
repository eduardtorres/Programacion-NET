using System;
namespace ProductosCore.DTO
{
    public class ProductoDto
    {
        public ProductoDto()
        {
        }
        public int id { get; set; }
        public string codigo { get; set; }
        public string fabricante { get; set; }
        public string tipoProveedor { get; set; }
        public string codigoProveedor { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string categoria { get; set; }
        public string urlImagen { get; set; }
        public double precio { get; set; }
        public string moneda { get; set; }
        public double precioOriginal { get; set; }
        public string monedaOriginal { get; set; }
        public int inventario { get; set; }
        public string disponibilidad { get; set; }
    }
}
