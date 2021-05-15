using System;
namespace ProductosCore.DTO
{
    public class ProductoDto
    {
        public ProductoDto()
        {
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Fabricante { get; set; }
        public string TipoProveedor { get; set; }
        public string CodigoProveedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string UrlImagen { get; set; }
        public double Precio { get; set; }
        public string Moneda { get; set; }
        public int Inventario { get; set; }
        public string Disponibilidad { get; set; }
    }
}
