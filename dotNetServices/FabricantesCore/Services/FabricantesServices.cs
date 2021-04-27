using FabricantesCore.DTO;
using FabricantesCore.Interfaces;
using FabricantesCore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricantesCore.Services
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

        public async Task<IList<ProductoDTO>> ListarProductosFabricantes(long IdFabricante)
        {
            ProductosAssembler assembler = new ProductosAssembler();
            IList<ProductoDTO> listaFabricantes = assembler.assemblyDTOs(await iFabricantesRepository.ListarProductosFabricantes(IdFabricante));
            return listaFabricantes;
        }

        public async Task<IList<InventarioDTO>> ConsultarInventario(IList<ProductoDTO> productos)
        {
            ProductosAssembler assemblerProducto = new ProductosAssembler();
            InventarioAssembler assemblerInventario = new InventarioAssembler();
            IList<InventarioDTO> listaInventario = assemblerInventario.assemblyDTOs(await iFabricantesRepository.ConsultarInventario(assemblerProducto.assemblyEntities(productos)));
            return listaInventario;
        }
    }
}