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
            dto.UrlServicioOrden = entity.UrlServicioOrden;
            dto.TipoApi = entity.TipoApi;
            dto.MetodoApi = entity.MetodoApi;
            dto.MetodoApiOrden = entity.MetodoApiOrden;
            dto.TransformacionProductos = entity.TransformacionProductos;
            dto.TransformacionOrdenes = entity.TransformacionOrdenes;
            dto.SOAPAction = entity.SOAPAction;
            dto.SOAPActionOrden = entity.SOAPActionOrden;
            dto.Body = entity.Body;
            dto.BodyOrden = entity.BodyOrden;
            dto.Prioridad = entity.Prioridad;
            dto.Activo = entity.Activo;
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
            entity.UrlServicioOrden = dto.UrlServicioOrden;
            entity.TipoApi = dto.TipoApi;
            entity.MetodoApi = dto.MetodoApi;
            entity.MetodoApiOrden = dto.MetodoApiOrden;
            entity.TransformacionProductos = dto.TransformacionProductos;
            entity.TransformacionOrdenes = dto.TransformacionOrdenes;
            entity.SOAPAction = dto.SOAPAction;
            entity.SOAPActionOrden = dto.SOAPActionOrden;
            entity.Body = dto.Body;
            entity.BodyOrden = dto.BodyOrden;
            entity.Prioridad = dto.Prioridad;
            entity.Activo = dto.Activo;
            return entity;
        }
    }
}