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
            return Ok( await iProductosService.ListarProductos(moneda,filtro) );
        }

        [HttpPost("inventario/actualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ListarProductos(ProductoDto newProducto)
        {
            return Ok(await iProductosService.UpdateProducto(newProducto));
        }
    }
}