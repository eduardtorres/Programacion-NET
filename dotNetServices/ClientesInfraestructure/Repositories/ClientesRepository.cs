using ClientesCore.Entities;
using ClientesCore.Interfaces;
using ClientesInfraestructure.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;

namespace ClientesInfraestructure.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        CustomersContext _customersContext;
        public ClientesRepository(CustomersContext customersContext)
        {
            _customersContext = customersContext;
        }
        public async Task<IList<ClienteEntity>> ListarClientes()
        {
            var lista = _customersContext.Clientes.ToList();
            return await Task.FromResult(lista);
        }

        public async Task<ClienteEntity> AuthenticarCliente(string UserName, string Password)
        {
            var lista = (from c in _customersContext.Clientes
                         where c.UserName == UserName && c.Password == Password
                         select c).FirstOrDefault();
            return await Task.FromResult(lista);
        }
        
        public async Task<ClienteEntity> RegistrarCliente(ClienteEntity clienteEntity)
        {
            try
            {
                var cliente = (from c in _customersContext.Clientes
                               where c.UserName == clienteEntity.UserName
                               select c).FirstOrDefault();
                if (cliente == null)
                {
                    _customersContext.Clientes.Add(clienteEntity);
                    await _customersContext.SaveChangesAsync();
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Error al guardar el cluente " + exc.Message);
            }
            return clienteEntity;
        }
    }
}
