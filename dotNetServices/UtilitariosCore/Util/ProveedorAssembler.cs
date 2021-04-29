using System;
using System.Collections.Generic;
using System.Text;
using UtilitariosCommon.Util;
using UtilitariosCore.DTO;
using UtilitariosCore.Entities;

namespace UtilitariosCore.Util
{
    public class ProveedorAssembler : AbstractAssembler<ProveedorDTO, ProveedorEntity>
    {
        public override ProveedorDTO assemblyDTO(ProveedorEntity entity)
        {
            ProveedorDTO dto = new ProveedorDTO();
            dto.IdProveedor = entity.IdProveedor;
            dto.Nombre = entity.Nombre;
            dto.Direccion = entity.Direccion;
            dto.Nit = entity.Nit;
            dto.Telefono = entity.Telefono;
            dto.UrlServicio = entity.UrlServicio;
            return dto;
        }

        public override ProveedorEntity assemblyEntity(ProveedorDTO dto)
        {
            ProveedorEntity entity = new ProveedorEntity();
            entity.IdProveedor = dto.IdProveedor;
            entity.Nombre = dto.Nombre;
            entity.Direccion = dto.Direccion;
            entity.Nit = dto.Nit;
            entity.Telefono = dto.Telefono;
            entity.UrlServicio = dto.UrlServicio;
            return entity;
        }
    }
}
