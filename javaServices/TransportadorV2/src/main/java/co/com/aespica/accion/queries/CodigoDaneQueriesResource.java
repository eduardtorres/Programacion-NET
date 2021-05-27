package co.com.aespica.accion.queries;

import co.com.aespica.repositorio.CodigoDane;
import co.com.aespica.repositorio.Transportador;
import co.com.aespica.servicio.CodigoDaneService;
import co.com.aespica.servicio.TransportadorService;

import javax.inject.Inject;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import java.util.List;


@Path("/codigodane")
public class CodigoDaneQueriesResource {
    @Inject
    CodigoDaneService codigodaneService;

    @Path("/obtener")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<CodigoDane> CodigoDaneObtener() {
        return codigodaneService.CodidoDaneObtener();
    }

    @Path("/obtener/{CodigoDane}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<CodigoDane> Obtener(@PathParam("CodigoDane") String idcoddane ) {
        System.out.println("idcoddane : " + idcoddane);
        return codigodaneService.ObtenerCodidoDaneXId(idcoddane);
    }

    @Path("/obtener/municipio/{cadena}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<CodigoDane> Obtenermunicipio(@PathParam("cadena") String cadena ) {
        System.out.println("cadena : " + cadena);
        return codigodaneService.ObtenerCodidoDaneXMuni(cadena);
    }
}