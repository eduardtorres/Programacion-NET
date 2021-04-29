using FabricantesCommon.Util;
using FabricantesCore.DTO;
using FabricantesCore.Entities;

namespace FabricantesCore.Util
{
    public class FabricantesAssembler : AbstractAssembler<FabricanteDTO, FabricanteEntity>
    {
        public override FabricanteDTO assemblyDTO(FabricanteEntity entity)
        {
            FabricanteDTO dto = new FabricanteDTO();
            dto.IdFabricante = entity.IdFabricante;
            dto.Nombre = entity.Nombre;
            dto.Direccion = entity.Direccion;
            dto.Nit = entity.Nit;
            dto.Telefono = entity.Telefono;
            dto.UrlServicio = entity.UrlServicio;            
            return dto;
        }

        public override FabricanteEntity assemblyEntity(FabricanteDTO dto)
        {
            FabricanteEntity entity = new FabricanteEntity();
            entity.IdFabricante = dto.IdFabricante;
            entity.Nombre = dto.Nombre;
            entity.Direccion = dto.Direccion;
            entity.Nit = dto.Nit;
            entity.Telefono = dto.Telefono;
            entity.UrlServicio = dto.UrlServicio;
            return entity;
        }
    }
}