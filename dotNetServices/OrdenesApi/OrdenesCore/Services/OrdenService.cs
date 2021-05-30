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
        private readonly IMapper _mapper;
        //private IRestClientCarritoCompras _restClientCarritoCompras;

        public OrdenService(IAsyncRepository<Ordenes> RepositoryOrdenes, IAsyncRepository<DetalleOrdenes> RepositoryDetalleOrdenes, IMapper mapper)
        {
            _repositoryOrdenes = RepositoryOrdenes;
            _repositoryDetalleOrdenes = RepositoryDetalleOrdenes;
            _mapper = mapper;
        }

        public async Task<RequestConfirmarOrden> CreateOrden(RequestConfirmarOrden orden)
        {
            orden.FechaCreacion = DateTime.Now.ToString();
            var EntityOrden = _mapper.Map<Ordenes>(orden);
            var ordenCreada = await _repositoryOrdenes.AddAsync(EntityOrden);
            var ListaDetalleOrden = orden.DetallesOrden;
            List<DetalleOrdenes> ListaEnDetalleOrdenes = new List<DetalleOrdenes>();

            foreach (var elemento in ListaDetalleOrden)
            {
                var EntityDetalleOrden = _mapper.Map<DetalleOrdenes>(elemento);
                EntityDetalleOrden.OrdenId = ordenCreada.Id;
                ListaEnDetalleOrdenes.Add(EntityDetalleOrden);
            }

            await _repositoryDetalleOrdenes.AddRangeAsync(ListaEnDetalleOrdenes);

            return orden;
        }

        public async Task DeleteOrden(long codigoOrden)
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
            if (resultado.Count > 0)
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

        public async Task<IEnumerable<OrdenesByCliente>> GetOrdenesByCustomer(string ordenesByCustomer)
        {

            var resultado = await _repositoryOrdenes.GetByCustomerAsync(ordenesByCustomer);
            List<OrdenesByCliente> ListaOrdenes = new List<OrdenesByCliente>();
            if (resultado.Count > 0)
            {
                foreach (var elemento in resultado)
                {
                    var dtoOrden = _mapper.Map<OrdenesByCliente>(elemento);
                    var entitiesDetallesOrden = await _repositoryDetalleOrdenes.GetOrdenDetailByOrdenIdAsync(dtoOrden.Id);
                    List<DetalleOrden> listaDetOrden = new List<DetalleOrden>();
                    foreach (var entity in entitiesDetallesOrden)
                    {
                        var dtoDetalleOrden = _mapper.Map<DetalleOrden>(entity);
                        listaDetOrden.Add(dtoDetalleOrden);
                    }
                    dtoOrden.DetallesOrden = listaDetOrden;
                    ListaOrdenes.Add(dtoOrden);

                }
                return ListaOrdenes;
            }
            return null;
        }

    }
}
