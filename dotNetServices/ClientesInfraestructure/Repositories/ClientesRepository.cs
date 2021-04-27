using ClientesCore.Entities;
using ClientesCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClientesInfraestructure.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        public ClientesRepository() { }
        public async Task<IList<ClienteEntity>> ListarClientes()
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PICA;Persist Security Info=True;User ID=sa;Password=Pass@word");
            connection.Open();
            SqlCommand command = new SqlCommand("SPGetAllClientes", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            IList<ClienteEntity> lista = new List<ClienteEntity>();
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

        public async Task<ClienteEntity> AuthenticarCliente(string UserName, string Password)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PICA;Persist Security Info=True;User ID=sa;Password=Pass@word");
            connection.Open();
            SqlCommand command = new SqlCommand("SPGetClienteByUserPass", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50)).Value = UserName;
            command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50)).Value = Password;
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
                cliente.UserName = reader["UserName"].ToString();
                cliente.Password = reader["Password"].ToString();
                lista.Add(cliente);
            }
            connection.Close();
            return lista[0];
        }
        
        public async Task<ClienteEntity> RegistrarCliente(ClienteEntity clienteEntity)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=PICA;Persist Security Info=True;User ID=sa;Password=Pass@word");
            connection.Open();
            SqlCommand command = new SqlCommand("SPRegistrarCliente", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar)).Value = clienteEntity.Nombre;
            command.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar)).Value = clienteEntity.Direccion;
            command.Parameters.Add(new SqlParameter("@Nit", SqlDbType.VarChar)).Value = clienteEntity.Nit;
            command.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar)).Value = clienteEntity.Telefono;
            command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar)).Value = clienteEntity.UserName;
            command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = clienteEntity.Password;
            SqlParameter ParamId = command.Parameters.Add("@IdCliente", SqlDbType.BigInt);
            ParamId.Direction = ParameterDirection.InputOutput;
            command.Parameters.Add(ParamId);
            await command.ExecuteNonQueryAsync();
            clienteEntity.IdCliente = Convert.ToInt64(ParamId.Value);
            connection.Close();
            return clienteEntity;
        }
    }
}
