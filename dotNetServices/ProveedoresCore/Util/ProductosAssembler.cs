using ProveedoresCommon.Util;
using ProveedoresCore.DTO;
using ProveedoresCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProveedoresCore.Util
{
    public class ProductosAssembler : AbstractAssembler<ProductoDTO, ProductoEntity>
    {
        public override ProductoDTO assemblyDTO(ProductoEntity entity)
        {
            ProductoDTO dto = new ProductoDTO();
            dto.Id = entity.Id;
            dto.Codigo = entity.Codigo;
            dto.Proveedor = entity.Proveedor;
            dto.TipoProveedor = entity.TipoProveedor;
            dto.CodigoProveedor = entity.CodigoProveedor;
            dto.Nombre = entity.Nombre;
            dto.Descripcion = entity.Descripcion;
            dto.Categoria = entity.Categoria;
            dto.UrlImagen = entity.UrlImagen;
            dto.Precio = entity.Precio;
            dto.Moneda = entity.Moneda;
            dto.PrecioOriginal = entity.PrecioOriginal;
            dto.MonedaOriginal = entity.MonedaOriginal;
            dto.Inventario = entity.Inventario;
            dto.Disponibilidad = entity.Disponibilidad;
            dto.Prioridad = entity.Prioridad;
            dto.Activo = entity.Activo;
            return dto;
        }

        public override ProductoEntity assemblyEntity(ProductoDTO dto)
        {
            ProductoEntity entity = new ProductoEntity();
            entity.Id = dto.Id;
            entity.Codigo = dto.Codigo;
            entity.Proveedor = dto.Proveedor;
            entity.TipoProveedor = dto.TipoProveedor;
            entity.CodigoProveedor = dto.CodigoProveedor;
            entity.Nombre = dto.Nombre;
            entity.Descripcion = dto.Descripcion;
            entity.Categoria = dto.Categoria;
            entity.UrlImagen = dto.UrlImagen;
            entity.Precio = dto.Precio;
            entity.Moneda = dto.Moneda;
            entity.PrecioOriginal = dto.PrecioOriginal;
            entity.MonedaOriginal = dto.MonedaOriginal;
            entity.Inventario = dto.Inventario;
            entity.Disponibilidad = dto.Disponibilidad;
            entity.Prioridad = dto.Prioridad;
            entity.Activo = dto.Activo;
            return entity;
        }
    }
}