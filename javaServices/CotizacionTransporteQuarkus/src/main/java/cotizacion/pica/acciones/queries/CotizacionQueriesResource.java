package cotizacion.pica.acciones.queries;

import cotizacion.pica.servicios.*;
import cotizacion.pica.repositorios.*;
import cotizacion.pica.dominio.*;

import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;

import java.util.List;

import javax.inject.Inject;

@Path("/cotizacion")
public class CotizacionQueriesResource {

    @Inject
    CotizacionService CotizacionService;

    @Path("/producto/consultar")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Cotizacion> getAll() {
        return CotizacionService.fetchAll();
    }

    @Path("/obtener/{codigo}/{tipoProveedor}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
        public Cotizacion Obtener( @PathParam("Id") Long Id ) {
        System.out.println("Id : " +Id);
        //System.out.println("tipoproveedor : " + tipoproveedor );
        return CotizacionService.ObtenerPorCodigoTipoPro(Id);
    }

    @Path("/cotizacion/consultar/{id}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<CotizacionDto> ConsultarCotizacions(@PathParam("id") long id) {
        System.out.println("Consulta por ID");
        System.out.println("id : " +id);
        return CotizacionService.ObtenerCotizacionDto(id);
    }
/*
    @Path("/orden/cotizar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public CotizacionDto CotizarOrden( CotizacionRequest request ) {
        return cotizacionService.CotizarOrden(request);
    }

    @Path("/cotizacion/disponibilidad/{id}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<CotizacionDto> Disponibilidad(@PathParam("id") int id) {
        return cotizacionService.id;
    }
*/
}