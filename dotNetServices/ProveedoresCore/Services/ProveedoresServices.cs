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

        public ProveedoresServices(IProveedoresRepository _iProveedoresRepository,
            IProveedoresApiRepository _iProveedoresApiRepository)
        {
            iProveedoresRepository = _iProveedoresRepository;
            iProveedoresApiRepository = _iProveedoresApiRepository;
        }

        public async Task<IList<ProveedorDTO>> ListarProveedores()
        {
            ProveedoresAssembler assembler = new ProveedoresAssembler();
            IList<ProveedorDTO> listaProveedores = assembler.assemblyDTOs(await iProveedoresRepository.ListarProveedores());
            return listaProveedores;
        }

        public async Task<IList<ProductoDTO>> ListarProductosProveedores(long IdProveedor)
        {
            ProductosAssembler assembler = new ProductosAssembler();
            IList<ProductoDTO> listaProveedores = assembler.assemblyDTOs(await iProveedoresRepository.ListarProductosProveedores(IdProveedor));
            return listaProveedores;
        }

        public async Task<IList<ProductoDTO>> BuscarProductosProveedores(string filtro)
        {

            List<ProductoDTO> respuesta = new List<ProductoDTO>();

            foreach ( var ProveedorEntity in await ListarProveedores())
            {

            //ProveedorEntity ProveedorEntity = new ProveedorEntity();

            //ProveedorEntity.UrlServicio = "https://nox60j22ea.execute-api.us-east-2.amazonaws.com/dev/catalog/products";

            //ProveedorEntity.UrlServicio = "https://cmdev.sigue.com/aes/WcfServiceProveedor2/Service1.svc";
            //ProveedorEntity.TipoApi = "SOAP";
            //ProveedorEntity.SOAPAction = "http://tempuri.org/IService1/GetDataUsingDataContract";

                if (!string.IsNullOrEmpty(ProveedorEntity.Body))
                {

                    ProveedorEntity.Body = ProveedorEntity.Body.Replace("@filtro", filtro);
                }

                List < ProductoDTO > listaProveedor = ( await iProveedoresApiRepository.BuscarProductos(
                filtro,
                ProveedorEntity
                ) ).ToList();

                respuesta.AddRange(listaProveedor);
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