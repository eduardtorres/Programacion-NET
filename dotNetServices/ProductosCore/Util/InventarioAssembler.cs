using ProductosCommon.Util;
using ProductosCore.DTO;
using ProductosCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductosCore.Util
{
    public class InventarioAssembler : AbstractAssembler<InventarioDTO, InventarioEntity>
    {
        public override InventarioDTO assemblyDTO(InventarioEntity entity)
        {
            InventarioDTO dto = new InventarioDTO();
            dto.IdInventario = entity.IdInventario;
            dto.IdProducto = entity.IdProducto;
            dto.IdFabricante = entity.IdFabricante;
            dto.Cantidad = entity.Cantidad;
            return dto;
        }

        public override InventarioEntity assemblyEntity(InventarioDTO dto)
        {
            InventarioEntity entity = new InventarioEntity();
            entity.IdInventario = dto.IdInventario;
            entity.IdProducto = dto.IdProducto;
            entity.IdFabricante = dto.IdFabricante;
            entity.Cantidad = dto.Cantidad;
            return entity;
        }
    }
}
