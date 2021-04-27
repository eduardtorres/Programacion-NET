using System.Collections.Generic;

namespace ClientesCommon.Util
{
    public abstract class AbstractAssembler<TDto, TEntity>
    {
        public abstract TDto assemblyDTO(TEntity entity);

        public virtual TDto AssembleDTO(TEntity entity)
        {
            return assemblyDTO(entity);
        }

        public abstract TEntity assemblyEntity(TDto dto);

        public virtual TEntity AssembleEntity(TDto dto)
        {
            return assemblyEntity(dto);
        }

        public IList<TDto> assemblyDTOs(IList<TEntity> entities)
        {
            IList<TDto> response = new List<TDto>();
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    response.Add(assemblyDTO(entity));
                }
            }
            return response;
        }

        public virtual IList<TDto> AssembleDTOs(IList<TEntity> entities)
        {
            IList<TDto> response = new List<TDto>();
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    response.Add(AssembleDTO(entity));
                }
            }
            return response;
        }

        public IList<TEntity> assemblyEntities(IList<TDto> dtos)
        {
            IList<TEntity> response = new List<TEntity>();
            if (dtos != null)
            {
                foreach (var dto in dtos)
                {
                    response.Add(assemblyEntity(dto));
                }
            }
            return response;
        }

        public virtual IList<TEntity> AssembleEntities(IList<TDto> dtos)
        {
            IList<TEntity> response = new List<TEntity>();
            if (dtos != null)
            {
                foreach (var dto in dtos)
                {
                    response.Add(AssembleEntity(dto));
                }
            }
            return response;
        }
    }
}
