using ProveedoresCore.DTO;
using ProveedoresCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProveedoresApi.Controllers
{
    [Route("proveedor")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        IProveedoresServices iProveedoresServices;
        public ProveedoresController(IProveedoresServices _iProveedoresServices)
        {
            iProveedoresServices = _iProveedoresServices;
        }

        [HttpGet("listado/obtener")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProveedorDTO>> ListarProveedores()
        {
            return Ok(await iProveedoresServices.ListarProveedores());
        }

        [HttpGet("productos/obtener/{filtro}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> BuscarProductosProveedores([FromRoute] string filtro)
        {
            return Ok(await iProveedoresServices.BuscarProductosProveedores(filtro));
        }

        [HttpPost("orden/colocar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CrearOrdenProveedor([FromBody] OrdenesRequestDTO ordenesRequestDTO)
        {
            return Ok(await iProveedoresServices.CrearOrdenProveedor(ordenesRequestDTO));
        }

        [HttpGet("inventario/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProveedorDTO>> ConsultarInventario(IList<ProductoDTO> productos)
        {
            return Ok(await iProveedoresServices.ConsultarInventario(productos));
        }
    }
}
