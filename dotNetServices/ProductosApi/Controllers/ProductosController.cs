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

        [HttpPost("listado/obtener")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ListarProductosResponse>> ListarProductos(ListarProductosRequest request)
        {
            return Ok( await iProductosService.ListarProductos( request ) );
        }

    }
}