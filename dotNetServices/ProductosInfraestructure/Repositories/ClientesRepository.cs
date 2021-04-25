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
    public class ClientesRepository : IClientesRepository
    {
        public ClientesRepository() { }
        public async Task<IReadOnlyList<ClienteEntity>> ListarClientes(ListarClientesRequest request)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PICA;Persist Security Info=True;User ID=sa;Password=Pass@word");
            connection.Open();
            SqlCommand command = new SqlCommand("GetAllClientes", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            List<ClienteEntity> lista = new List<ClienteEntity>();
            while (await reader.ReadAsync())
            {
                ClienteEntity cliente = new ClienteEntity();
                cliente.IdCliente = Convert.ToInt64(reader["IdCliente"]);
                cliente.Nombre = reader["Nombre"].ToString();
                cliente.Direccion = reader["Direccion"].ToString();
                cliente.Nit = reader["Nit"].ToString();
                cliente.Telefono = reader["Telefono"].ToString();
                lista.Add(cliente);
            }
            connection.Close();
            return lista;
        }
    }
}
