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

    @Path("/obtener/tasasIntercambio")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Pago> getAll() {
        return intercambioService.fetchAll();
    }

    @Path("/obtener/tasasIntercambio/{CodMoneda}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Pago getById(@PathParam("CodMoneda") String CodMoneda) {
        return intercambioService.getById(CodMoneda);
    }

    @Path("/obtener/impuesto/{CodPais}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<MediosPago> getByIdImpuesto(@PathParam("CodPais") String CodPais) {
        return intercambioService.getByIdImpuesto(CodPais);
    }

    @Path("/obtener/impuesto/total/{CodPais}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public double getByIdImpuestoTotal(@PathParam("CodPais") String CodPais) {
        return intercambioService.getByIdImpuestoTotal(CodPais);
    }

}
