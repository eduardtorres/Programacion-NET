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

    @Path("/obtener/{codigo}/{tipoProveedor}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
        public Inventario Obtener( @PathParam("codigo") String codigo , @PathParam("tipoProveedor") String tipoproveedor ) {
        System.out.println("codigo : " +codigo);
        System.out.println("tipoproveedor : " + tipoproveedor );
        return InventarioService.ObtenerPorCodigoTipoPro(codigo,tipoproveedor);
    }

    @Path("/inventario/consultar/{id}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<InventarioDto> ConsultarInventarios(@PathParam("id") long id) {
        System.out.println("Consulta por ID");
        System.out.println("id : " +id);
        return InventarioService.ObtenerInventarioDto(id);
    }
/*
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