using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosCore.DTO;
using ProductosCore.Interfaces;

namespace ProductosApi.Controllers
{
    [Route("producto")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        IProductosService iProductosService;

        public ProductosController(IProductosService _iProductosService)
        {
            iProductosService = _iProductosService;
        }

        [HttpGet("listado/obtener/{moneda}/{filtro}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ListarProductos(string moneda,string filtro)
        {
            try
            {
                return Ok(await iProductosService.ListarProductos(moneda, filtro));
            }
            catch( Exception ex )
            {
                return Ok(ex.ToString());
            }
        }

        [HttpPost("insertar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AgregarProducto(List<ProductoDto> newProducto)
        {
            try
            {
                return Ok(await iProductosService.AgregarProducto(newProducto));
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }

        [HttpPost("inventario/actualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateProducto(ProductoDto newProducto)
        {
            try
            {
                return Ok(await iProductosService.UpdateProducto(newProducto));
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }
    }
}