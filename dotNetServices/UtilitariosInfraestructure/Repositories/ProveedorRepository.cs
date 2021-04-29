using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using UtilitariosCore.Interfaces;

namespace UtilitariosInfraestructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        IConfiguration iConfiguration;
        public ProveedorRepository(IConfiguration _iConfiguration)
        {
            iConfiguration = _iConfiguration;
        }
        public async Task EjecutarOperacion()
        {
            /*SqlConnection connection = new SqlConnection(iConfiguration.GetConnectionString("DefaultConnection"));
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
            return clienteEntity;*/
            throw new InvalidOperationException();
        }
    }
}
