using ProductosCore.DTO;
using ProductosCore.Entities;
using ProductosCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProductosInfraestructure.Repositories
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

        public async Task<IList<Producto>> ListarProductosFabricantes(long IdFabricante)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PICA;Persist Security Info=True;User ID=sa;Password=Pass@word");
            connection.Open();
            SqlCommand command = new SqlCommand("SPGetProductosFabricante", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@IdFabricante", SqlDbType.BigInt)).Value = IdFabricante;            
            SqlDataReader reader = command.ExecuteReader();
            IList<Producto> lista = new List<Producto>();
            while (await reader.ReadAsync())
            {
                Producto producto = new Producto();
                producto.Id = Convert.ToInt32(reader["Id"]);
                producto.Nombre = reader["Nombre"].ToString();
                producto.Precio = Convert.ToDouble(reader["Precio"]);                
                lista.Add(producto);
            }
            connection.Close();
            return lista;
        }
    }
}
