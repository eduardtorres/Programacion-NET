using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;
using ProductosCore.Entities;
using System.Data.SqlClient;
using ProductosCore.Interfaces;

namespace ProductosInfraestructure.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        public ProductosRepository()
        {
        }

        public async Task<IReadOnlyList<Producto> > ListarProductos(ListarProductosRequest request)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PICA;Persist Security Info=True;User ID=sa;Password=123qwe");
            connection.Open();
            SqlCommand command = new SqlCommand("select Id, Nombre from productos", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Producto> lista = new List<Producto>();
            while ( await reader.ReadAsync())
            {
                Producto producto = new Producto();
                producto.Id = reader.GetInt32(0);
                producto.Nombre = reader.GetString(1);
                lista.Add(producto);
            }
            connection.Close();
            return lista;
        }
    }

}
