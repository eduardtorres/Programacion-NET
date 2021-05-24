package transportadores.pica.acciones.queries;

import transportadores.pica.servicios.*;
import transportadores.pica.repositorios.*;
import transportadores.pica.dominio.*;

import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;

import java.util.List;

import javax.inject.Inject;

@Path("/transportador")
public class TransportadorQueriesResource {

    @Inject
    TransportadorService TransportadorService;

    @Path("/listado/obtener")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Transportador> getAll() {
        return TransportadorService.fetchAll();
    }

    @Path("/listado/consultar/{id}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Transportador> ConsultarTransportadors(@PathParam("idTransportador") long idTransportador) {
        System.out.println("Consulta por ID");
        System.out.println("idTransportador : " + idTransportador);
        return TransportadorService.ObtenerTransportadorID(idTransportador);
    }
}