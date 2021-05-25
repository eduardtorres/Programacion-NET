package co.com.aespica.accion.queries;

import co.com.aespica.repositorio.*;
import co.com.aespica.servicio.*;

import java.util.List;

import javax.inject.Inject;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.PathParam;


@Path("/transportador")
public class TransportadorQueriesResource {
    @Inject
    TransportadorService transportadorService;

    @Path("/obtener")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Transportador> TransportadorObtener() {
        return transportadorService.TransportadorObtener();
    }
}