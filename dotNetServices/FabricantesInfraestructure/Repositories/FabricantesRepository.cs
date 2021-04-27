using FabricantesCore.Entities;
using FabricantesCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FabricantesInfraestructure.Repositories
{
    public class FabricantesRepository : IFabricantesRepository
    {
        public FabricantesRepository() { }
        public async Task<IList<FabricanteEntity>> ListarFabricantes()
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PICA;Persist Security Info=True;User ID=sa;Password=Pass@word");
            connection.Open();
            SqlCommand command = new SqlCommand("SPGetAllFabricantes", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            IList<FabricanteEntity> lista = new List<FabricanteEntity>();
            while (await reader.ReadAsync())
            {
                FabricanteEntity fabricante = new FabricanteEntity();
                fabricante.IdCliente = Convert.ToInt64(reader["IdCliente"]);
                fabricante.Nombre = reader["Nombre"].ToString();
                fabricante.Direccion = reader["Direccion"].ToString();
                fabricante.Nit = reader["Nit"].ToString();
                fabricante.Telefono = reader["Telefono"].ToString();
                lista.Add(fabricante);
            }
            connection.Close();
            return lista;
        }

        public async Task<IList<ProductoEntity>> ListarProductosFabricantes(long IdFabricante)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PICA;Persist Security Info=True;User ID=sa;Password=Pass@word");
            connection.Open();
            SqlCommand command = new SqlCommand("SPGetProductosFabricante", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@IdFabricante", SqlDbType.BigInt)).Value = IdFabricante;            
            SqlDataReader reader = command.ExecuteReader();
            IList<ProductoEntity> lista = new List<ProductoEntity>();
            while (await reader.ReadAsync())
            {
                ProductoEntity producto = new ProductoEntity();
                producto.Id = Convert.ToInt32(reader["Id"]);
                producto.Nombre = reader["Nombre"].ToString();
                producto.Precio = Convert.ToDouble(reader["Precio"]);                
                lista.Add(producto);
            }
            connection.Close();
            return lista;
        }

        public async Task<IList<InventarioEntity>> ConsultarInventario(IList<ProductoEntity> productos)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PICA;Persist Security Info=True;User ID=sa;Password=Pass@word");
            connection.Open();

            IList<InventarioEntity> lista = new List<InventarioEntity>();
            foreach (ProductoEntity producto in productos)
            {
                SqlCommand command = new SqlCommand("SPGetInventario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.BigInt)).Value = producto.Id;
                command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.BigInt)).Value = producto.Nombre;
                SqlDataReader reader = command.ExecuteReader();                
                while (await reader.ReadAsync())
                {
                    InventarioEntity inventario = new InventarioEntity();
                    inventario.IdInventario = Convert.ToInt64(reader["IdInventario"]);
                    inventario.IdProducto = Convert.ToInt64(reader["IdProducto"]);
                    inventario.IdFabricante = Convert.ToInt64(reader["IdFabricante"]);
                    inventario.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                    lista.Add(inventario);
                }
            }
            connection.Close();
            return lista;
        }
    }
}
