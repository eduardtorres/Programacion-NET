using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;
using ProductosCore.Entities;
using System.Data.SqlClient;
using ProductosCore.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ProductosInfraestructure.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        IConfiguration iConfiguration;

        public ProductosRepository( IConfiguration _iConfiguration)
        {
            iConfiguration = _iConfiguration;
        }

        public async Task<IList<Producto>> ListarProductos(string filtro)
        {
            SqlConnection connection = new SqlConnection(iConfiguration.GetConnectionString("DefaultConnection"));
            connection.Open();
            SqlCommand command = new SqlCommand(
                @"select
                    Id,
                    Codigo,
                    Fabricante,
                    TipoProveedor,
                    CodigoProveedor,
                    Nombre,
                    Descripcion,
                    Categoria,
                    UrlImagen,
                    Precio,
                    Moneda,
                    Inventario
                    from productos
                where Nombre like '%' + @nombre + '%'

", connection);

            command.Parameters.Add(new SqlParameter("@nombre", filtro));

            SqlDataReader reader = command.ExecuteReader();
            List<Producto> lista = new List<Producto>();
            while ( await reader.ReadAsync())
            {
                Producto producto = new Producto();
                producto.Id = reader.GetInt32(0);
                producto.Codigo = reader.GetString(1);
                producto.Fabricante = reader.GetString(2);
                producto.TipoProveedor = reader.GetString(3);
                producto.CodigoProveedor = reader.GetString(4);
                producto.Nombre = reader.GetString(5);
                producto.Descripcion = reader.GetString(6);
                producto.Categoria = reader.GetString(7);
                producto.UrlImagen = reader.GetString(8);
                producto.Precio = reader.GetDouble(9);
                producto.Moneda = reader.GetString(10);
                producto.Inventario = reader.GetInt32(11);
                lista.Add(producto);
            }
            connection.Close();
            return lista;
        }
    }

}
