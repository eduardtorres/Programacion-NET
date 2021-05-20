using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using OrdenesCore.DTO;
using OrdenesCore.Entities;
using OrdenesCore.Interfaces;
using AutoMapper;

namespace OrdenesCore.Services
{
    public class OrdenService : IOrdenService
    {
        private IAsyncRepository<Ordenes> _repositoryOrdenes;
        private IAsyncRepository<DetalleOrdenes> _repositoryDetalleOrdenes;
        private IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        //private IRestClientCarritoCompras _restClientCarritoCompras;

        public OrdenService(IAsyncRepository<Ordenes> RepositoryOrdenes, IAsyncRepository<DetalleOrdenes> RepositoryDetalleOrdenes, IUnitOfWork unitofwork, IMapper mapper)
        {
            _repositoryOrdenes = RepositoryOrdenes;
            _repositoryDetalleOrdenes = RepositoryDetalleOrdenes;
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        public async Task<Orden> CreateOrden(Orden orden)
        {
            orden.Estado = "PENDIENTE";
            orden.FechaCreacion = DateTime.Now.ToString();
            var EntityOrden = _mapper.Map<Ordenes>(orden);
            var ordenCreada = await _repositoryOrdenes.AddAsync(EntityOrden);
            orden.Id = ordenCreada.Id;

            var ListaDetalleOrden = orden.DetallesOrden;
            List<DetalleOrdenes> ListaEnDetalleOrdenes = new List<DetalleOrdenes>();

            foreach (var elemento in ListaDetalleOrden)
            {
                var EntityDetalleOrden = _mapper.Map<DetalleOrdenes>(elemento);
                EntityDetalleOrden.OrdenId = orden.Id;
                ListaEnDetalleOrdenes.Add(EntityDetalleOrden);
            }
            
            var DetalleordenCreada = await _repositoryDetalleOrdenes.AddRangeAsync(ListaEnDetalleOrdenes);

            return orden;
        }

        public async Task deleteOrden(long codigoOrden)
        {
            var resultado = await _repositoryOrdenes.GetByIdAsync(codigoOrden);
            if (resultado != null)
            {
                await _repositoryOrdenes.DeleteAsync(resultado);
            }

        }

        public async Task<Orden> GetOrdenById(long codigoOrden)
        {
            var resultado = await _repositoryOrdenes.GetByIdAsync(codigoOrden);

            if (resultado != null)
            {
                var orden = new Orden
                {
                    Id = resultado.Id,
                    Estado = resultado.Estado,
                    TelefonoEnvio = resultado.TelefonoEnvio

                };
                return orden;
            }
            return null;

        }

        public async Task<IEnumerable<Orden>> GetOrdenes()
        {
            var resultado = await _repositoryOrdenes.GetAllAsync();
            if (resultado.Count >0)
            {
                var listaOrden = resultado
                 .Select(orden => new Orden
                 {
                     Id = orden.Id,
                     Estado = orden.Estado,
                     TelefonoEnvio = orden.TelefonoEnvio
                  });
                return listaOrden;
            }
            return null;

        }

        public async Task<Orden> UpdateEstadoOrden(long codigoOrden, Orden orden)
        {
            var entidadOrdenActualizar = await _repositoryOrdenes.GetByIdAsync(codigoOrden);
            if (entidadOrdenActualizar != null)
            {
                entidadOrdenActualizar.Id = codigoOrden;
                entidadOrdenActualizar.Estado = orden.Estado;
                entidadOrdenActualizar.FechaUltimaActualizacion = orden.FechaUltimaActualizacion;
                entidadOrdenActualizar.PagoId = orden.PagoId;
                await _repositoryOrdenes.UpdateAsync(entidadOrdenActualizar);
                orden.Id = entidadOrdenActualizar.Id;
                return orden;
             }
            return null;
        }
    }
}
