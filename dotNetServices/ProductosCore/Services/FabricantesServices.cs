using ProductosCore.DTO;
using ProductosCore.Entities;
using ProductosCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCore.Services
{
    public class FabricantesServices : IFabricantesServices
    {
        IFabricantesRepository iFabricantesRepository;
        public FabricantesServices(IFabricantesRepository _iFabricantesRepository)
        {
            iFabricantesRepository = _iFabricantesRepository;
        }
        public async Task<ListarFabricantesResponse> ListarFabricantes(ListarFabricantesRequest request)
        {
            IReadOnlyList<FabricanteEntity> lista = await iFabricantesRepository.ListarFabricantes(request);
            ListarFabricantesResponse response = new ListarFabricantesResponse();

            var fabricantes = lista.Select(x => new FabricanteDTO()
            {
                IdCliente = x.IdCliente,
                Nombre = x.Nombre,
                Direccion = x.Direccion,
                Nit = x.Nit,
                Telefono = x.Telefono
            });

            response.fabricantes = fabricantes.ToList();
            return response;
        }
    }
}