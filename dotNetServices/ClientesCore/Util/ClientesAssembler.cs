using ClientesCommon.Util;
using ClientesCore.DTO;
using ClientesCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesCore.Util
{
    public class ClientesAssembler : AbstractAssembler<ClienteDTO, ClienteEntity>
    {
        public override ClienteDTO assemblyDTO(ClienteEntity entity)
        {
            ClienteDTO dto = new ClienteDTO();
            dto.IdCliente = entity.IdCliente;
            dto.Nombre = entity.Nombre;
            dto.Direccion = entity.Direccion;
            dto.Nit = entity.Nit;
            dto.Telefono = entity.Telefono;
            dto.UserName = entity.UserName;
            dto.Password = entity.Password;
            return dto;
        }

        public override ClienteEntity assemblyEntity(ClienteDTO dto)
        {
            ClienteEntity entity = new ClienteEntity();
            entity.IdCliente = dto.IdCliente;
            entity.Nombre = dto.Nombre;
            entity.Direccion = dto.Direccion;
            entity.Nit = dto.Nit;
            entity.Telefono = dto.Telefono;
            entity.UserName = dto.UserName;
            entity.Password = dto.Password;
            return entity;
        }
    }
}
