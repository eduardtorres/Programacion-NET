using FabricantesCore.DTO;
using FabricantesCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricantesApi.Controllers
{
    [Route("fabricante")]
    [ApiController]
    public class FabricantesController : ControllerBase
    {
        IFabricantesServices iFabricantesServices;
        public FabricantesController(IFabricantesServices _iFabricantesServices)
        {
            iFabricantesServices = _iFabricantesServices;
        }

        [HttpGet("listado/obtener")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FabricanteDTO>> ListarFabricantes()
        {
            return Ok(await iFabricantesServices.ListarFabricantes());
        }

        [HttpGet("productos/obtener")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FabricanteDTO>> ListarProductosFabricantes(long IdFabricante)
        {
            return Ok(await iFabricantesServices.ListarProductosFabricantes(IdFabricante));
        }

        [HttpGet("productos/buscar/{filtro}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> BuscarProductosFabricantes([FromRoute]string filtro)
        {
            return Ok(await iFabricantesServices.BuscarProductosFabricantes(filtro));
        }

        [HttpGet("inventario/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FabricanteDTO>> ConsultarInventario(IList<ProductoDTO> productos)
        {
            return Ok(await iFabricantesServices.ConsultarInventario(productos));
        }
    }
}
