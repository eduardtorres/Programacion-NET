package co.com.aespica.accion.queries;

import co.com.aespica.dominio.*;
import co.com.aespica.repositorio.*;
import co.com.aespica.servicios.*;

import javax.inject.Inject;
import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;
import java.util.List;

@Path("/transportador")
public class CotizacionQueriesResource {

    @Inject
    CotizacionService CotizacionService;

    @Path("/envio/consultar")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Cotizacion> getAll() {
        return CotizacionService.fetchAll();
    }

    @Path("/envio/consultar/{IdTransportador}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
        public Cotizacion Obtener( @PathParam("IdTransportador") Long IdTransportador ) {
        System.out.println("idTransportador : " + IdTransportador);
        //System.out.println("tipoproveedor : " + tipoproveedor );
        return CotizacionService.ObtenerPorIdTransportador(IdTransportador);
    }

    @Path("/envio/cotizar")
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaCotizacionDto obtenerFlete(CotizacionDto cotizacionDto) {
        System.out.println("Consulta por ID");
        System.out.println("id : " + cotizacionDto.codCiudadOrigen);
        return CotizacionService.obtenerFlete(cotizacionDto);
    }
}