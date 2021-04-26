using ProductosCommon.Util;
using ProductosCore.DTO;
using ProductosCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductosCore.Util
{
    public class ProdcutosAssembler : AbstractAssembler<ProductoDto, Producto>
    {
        public override ProductoDto assemblyDTO(Producto entity)
        {
            ProductoDto dto = new ProductoDto();
            dto.Id = entity.Id;
            dto.Nombre = entity.Nombre;
            dto.Precio = entity.Precio;            
            return dto;
        }

        public override Producto assemblyEntity(ProductoDto dto)
        {
            Producto entity = new Producto();
            entity.Id = dto.Id;
            entity.Nombre = dto.Nombre;
            entity.Precio = dto.Precio;            
            return entity;
        }
    }
}