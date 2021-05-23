using ProveedoresCommon.Util;
using ProveedoresCore.DTO;
using ProveedoresCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProveedoresCore.Util
{
    public class InventarioAssembler : AbstractAssembler<InventarioDTO, InventarioEntity>
    {
        public override InventarioDTO assemblyDTO(InventarioEntity entity)
        {
            InventarioDTO dto = new InventarioDTO();
            dto.IdInventario = entity.IdInventario;
            dto.IdProducto = entity.IdProducto;
            dto.IdProveedor = entity.IdFabricante;
            dto.Cantidad = entity.Cantidad;
            return dto;
        }

        public override InventarioEntity assemblyEntity(InventarioDTO dto)
        {
            InventarioEntity entity = new InventarioEntity();
            entity.IdInventario = dto.IdInventario;
            entity.IdProducto = dto.IdProducto;
            entity.IdFabricante = dto.IdProveedor;
            entity.Cantidad = dto.Cantidad;
            return entity;
        }
    }
}
