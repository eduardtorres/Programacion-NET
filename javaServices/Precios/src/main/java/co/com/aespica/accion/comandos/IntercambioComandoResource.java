package co.com.aespica.accion.comandos;

import java.util.List;

import javax.inject.Inject;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import co.com.aespica.Servicio.IntercambioService;
import co.com.aespica.repositorio.Intercambio;

@Path("/precio")
public class IntercambioComandoResource {
    @Inject
    IntercambioService intercambioService;

    @Path("/obtener/tasasIntercambioXXX")
    @POST
    @Produces(MediaType.APPLICATION_JSON)
    public List<Intercambio> getAll() {
        return intercambioService.fetchAll();
    }


}
