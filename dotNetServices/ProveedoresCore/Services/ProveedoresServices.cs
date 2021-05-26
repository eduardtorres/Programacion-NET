using ProveedoresCore.DTO;
using ProveedoresCore.Entities;
using ProveedoresCore.Interfaces;
using ProveedoresCore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveedoresCore.Services
{
    public class ProveedoresServices : IProveedoresServices
    {
        IProveedoresRepository iProveedoresRepository;
        IProveedoresApiRepository iProveedoresApiRepository;
        //ProveedoresAssembler proveedoresAssembler;
        //ProductosAssembler productosAssembler;

        public ProveedoresServices(IProveedoresRepository _iProveedoresRepository,
            IProveedoresApiRepository _iProveedoresApiRepository)
        {
            iProveedoresRepository = _iProveedoresRepository;
            iProveedoresApiRepository = _iProveedoresApiRepository;
            //proveedoresAssembler = _proveedoresAssembler;
            //productosAssembler = _productosAssembler;
        }

        public async Task<IList<ProveedorDTO>> ListarProveedores()
        {
            ProveedoresAssembler proveedoresAssembler = new ProveedoresAssembler();
            IList<ProveedorDTO> listaProveedores = proveedoresAssembler.assemblyDTOs(await iProveedoresRepository.ListarProveedores());
            return listaProveedores;
        }        

        public async Task<IList<ProductoDTO>> BuscarProductosProveedores(string filtro)
        {
            List<ProductoDTO> respuesta = new List<ProductoDTO>();

            foreach (var proveedorDTO in await ListarProveedores())
            {               
                if (!string.IsNullOrEmpty(proveedorDTO.Body))
                {
                    proveedorDTO.Body = proveedorDTO.Body.Replace("@filtro", filtro);
                }

                List<ProductoDTO> listaProductos = (await iProveedoresApiRepository.BuscarProductos(
                filtro,
                proveedorDTO
                )).ToList();

                foreach (var item in listaProductos)
                {
                    item.TipoProveedor = "Externo";
                    item.CodigoProveedor = proveedorDTO.Nombre;
                }

                respuesta.AddRange(listaProductos);
            }

            return respuesta;
        }

        public async Task<IList<InventarioDTO>> ConsultarInventario(IList<ProductoDTO> productos)
        {
            ProductosAssembler assemblerProducto = new ProductosAssembler();
            InventarioAssembler assemblerInventario = new InventarioAssembler();
            IList<InventarioDTO> listaInventario = assemblerInventario.assemblyDTOs(await iProveedoresRepository.ConsultarInventario(assemblerProducto.assemblyEntities(productos)));
            return listaInventario;
        }
    }
}