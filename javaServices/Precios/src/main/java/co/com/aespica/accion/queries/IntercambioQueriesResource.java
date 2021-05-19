package co.com.aespica.accion.queries;

import co.com.aespica.repositorio.*;
import co.com.aespica.Servicio.*;

import java.util.List;

import javax.inject.Inject;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.PathParam;


@Path("/precio")
public class IntercambioQueriesResource {
    @Inject
    IntercambioService intercambioService;

    @Path("/tasa/obtener")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Intercambio> getAll() {
        return intercambioService.fetchAll();
    }

    @Path("/tasa/obtener/{CodMoneda}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Intercambio getById(@PathParam("CodMoneda") String CodMoneda) {
        return intercambioService.getById(CodMoneda);
    }

    @Path("/impuesto/obtener/{CodPais}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Impuesto> getByIdImpuesto(@PathParam("CodPais") String CodPais) {
        return intercambioService.getByIdImpuesto(CodPais);
    }

    @Path("/impuesto/total/obtener/{CodPais}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public double getByIdImpuestoTotal(@PathParam("CodPais") String CodPais) {
        return intercambioService.getByIdImpuestoTotal(CodPais);
    }

}
