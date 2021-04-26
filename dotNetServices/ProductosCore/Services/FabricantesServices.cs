using ProductosCore.DTO;
using ProductosCore.Entities;
using ProductosCore.Interfaces;
using ProductosCore.Util;
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
        public async Task<IList<FabricanteDTO>> ListarFabricantes()
        {
            FabricantesAssembler assembler = new FabricantesAssembler();
            IList<FabricanteDTO> listaFabricantes = assembler.assemblyDTOs(await iFabricantesRepository.ListarFabricantes());
            return listaFabricantes;
        }

        public async Task<IList<ProductoDto>> ListarProductosFabricantes(long IdFabricante)
        {
            ProdcutosAssembler assembler = new ProdcutosAssembler();
            IList<ProductoDto> listaFabricantes = assembler.assemblyDTOs(await iFabricantesRepository.ListarProductosFabricantes(IdFabricante));
            return listaFabricantes;
        }
    }
}