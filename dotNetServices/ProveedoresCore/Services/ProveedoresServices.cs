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
            var proveedores = await iProveedoresRepository.ListarProveedores();
            var listaProveedores = proveedores.Select(entity => new ProveedorDTO()
            {
                IdProveedor = entity.IdProveedor,
                Nombre = entity.Nombre,
                Direccion = entity.Direccion,
                Nit = entity.Nit,
                Telefono = entity.Telefono,
                UrlServicio = entity.UrlServicio,
                UrlServicioOrden = entity.UrlServicioOrden,
                TipoApi = entity.TipoApi,
                MetodoApi = entity.MetodoApi,
                MetodoApiOrden = entity.MetodoApiOrden,
                TransformacionProductos = entity.TransformacionProductos,
                TransformacionOrdenes = entity.TransformacionOrdenes,
                SOAPAction = entity.SOAPAction,
                SOAPActionOrden = entity.SOAPActionOrden,
                Body = entity.Body,
                BodyOrden = entity.BodyOrden,
                Prioridad = entity.Prioridad,
                Activo = entity.Activo,
            });

            return listaProveedores.ToList();
        }
        public async Task<ProveedorDTO> BuscarProveedor(string nombre)
        {
            ProveedorDTO dtoResult = new ProveedorDTO();
            var proveedor = await iProveedoresRepository.BuscarProveedor(nombre);

            dtoResult.IdProveedor = proveedor.IdProveedor;
            dtoResult.Nombre = proveedor.Nombre;
            dtoResult.Direccion = proveedor.Direccion;
            dtoResult.Nit = proveedor.Nit;
            dtoResult.Telefono = proveedor.Telefono;
            dtoResult.UrlServicio = proveedor.UrlServicio;
            dtoResult.UrlServicioOrden = proveedor.UrlServicioOrden;
            dtoResult.TipoApi = proveedor.TipoApi;
            dtoResult.MetodoApi = proveedor.MetodoApi;
            dtoResult.MetodoApiOrden = proveedor.MetodoApiOrden;
            dtoResult.TransformacionProductos = proveedor.TransformacionProductos;
            dtoResult.TransformacionOrdenes = proveedor.TransformacionOrdenes;
            dtoResult.SOAPAction = proveedor.SOAPAction;
            dtoResult.SOAPActionOrden = proveedor.SOAPActionOrden;
            dtoResult.Body = proveedor.Body;
            dtoResult.BodyOrden = proveedor.BodyOrden;
            dtoResult.Prioridad = proveedor.Prioridad;
            dtoResult.Activo = proveedor.Activo;

            return dtoResult;
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

                List<ProductoDTO> listaProductos = (await iProveedoresApiRepository.BuscarProductos(proveedorDTO)).ToList();

                foreach (var item in listaProductos)
                {
                    item.TipoProveedor = "Externo";
                    item.CodigoProveedor = proveedorDTO.Nombre;
                    item.Prioridad = proveedorDTO.Prioridad;
                }

                respuesta.AddRange(listaProductos);
            }

            return respuesta;
        }
        public async Task<OrdenesDTO> CrearOrdenProveedor(OrdenesRequestDTO ordenesRequestDTO)
        {        
            var proveedorDTO = await BuscarProveedor(ordenesRequestDTO.codigoProveedor);
            if (!string.IsNullOrEmpty(proveedorDTO.BodyOrden))
            {
                proveedorDTO.BodyOrden = proveedorDTO.BodyOrden.Replace("@codigo", ordenesRequestDTO.codigo);
                proveedorDTO.BodyOrden = proveedorDTO.BodyOrden.Replace("@CantidadOrdenada", ordenesRequestDTO.CantidadOrdenada.ToString());
            }

            OrdenesDTO respuesta = await iProveedoresApiRepository.CrearOrdenProveedor(proveedorDTO);

            if (!string.IsNullOrEmpty(respuesta.numeroOrdenProveedor))
            {
                respuesta.codigo = 1;
                respuesta.mensaje = "Proveedor aceptó la orden";                
            }
            else                
            {
                respuesta.codigo = 0;
                respuesta.mensaje = "Proveedor no aceptó la orden";                
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