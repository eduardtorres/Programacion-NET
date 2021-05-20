package inventario.pica.acciones.queries;

import inventario.pica.servicios.*;
import inventario.pica.repositorios.*;
import inventario.pica.dominio.*;

import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;

import java.util.List;

import javax.inject.Inject;

@Path("/inventario")
public class InventarioQueriesResource {

    @Inject
    InventarioService InventarioService;

    @Path("/producto/consultar")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Inventario> getAll() {
        return InventarioService.fetchAll();
    }

    @Path("/obtener/{id}/{codigo}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Inventario Obtener( @PathParam("codigo") String codigo , @PathParam("tipoproveedor") String tipoproveedor ) {
        return InventarioService.ObtenerPorCodigoTipoPro(codigo,tipoproveedor);
    }
/*
    @Path("/productos/consultar/{id}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Inventario> ConsultarProductos(@PathParam("id") int id) {
        return InventarioService.ObtenerInventario(id);
    }

    @Path("/orden/cotizar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public CotizacionDto CotizarOrden( CotizacionRequest request ) {
        return inventarioService.CotizarOrden(request);
    }

    @Path("/inventario/disponibilidad/{id}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<InventarioDto> Disponibilidad(@PathParam("id") int id) {
        return inventarioService.id;
    }
*/
}