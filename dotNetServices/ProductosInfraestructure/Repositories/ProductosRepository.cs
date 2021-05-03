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

        public async Task<IReadOnlyList<Producto> > ListarProductos(ListarProductosRequest request)
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
                    Precio,
                    Inventario
                    from productos
                where Nombre like '%' + @nombre + '%'

", connection);

            command.Parameters.Add(new SqlParameter("@nombre", request.Nombre));

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
                producto.Precio = reader.GetDouble(8);
                producto.Inventario = reader.GetInt32(9);
                lista.Add(producto);
            }
            connection.Close();
            return lista;
        }
    }

}
