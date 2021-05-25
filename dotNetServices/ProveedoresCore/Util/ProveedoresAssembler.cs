using ProveedoresCommon.Util;
using ProveedoresCore.DTO;
using ProveedoresCore.Entities;

namespace ProveedoresCore.Util
{
    public class ProveedoresAssembler : AbstractAssembler<ProveedorDTO, ProveedorEntity>
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
            dto.TipoApi = entity.TipoApi;
            dto.MetodoApi = entity.MetodoApi;
            dto.TransformacionProductos = entity.TransformacionProductos;
            dto.TransformacionOrdenes = entity.TransformacionOrdenes;
            dto.SOAPAction = entity.SOAPAction;
            dto.Body = entity.Body;
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
            entity.TipoApi = dto.TipoApi;
            entity.MetodoApi = dto.MetodoApi;
            entity.TransformacionProductos = dto.TransformacionProductos;
            entity.TransformacionOrdenes = dto.TransformacionOrdenes;
            entity.SOAPAction = dto.SOAPAction;
            entity.Body = dto.Body;
            return entity;
        }
    }
}