using System;
namespace ProductosCore.DTO
{
    public class ProductoDto
    {
        public ProductoDto()
        {
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }
}
