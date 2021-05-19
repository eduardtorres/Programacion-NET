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


@Path("/pagos")
public class IntercambioQueriesResource {
    @Inject
    PagoService pagoService;

    @Path("/mediospago/")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<MediosPago> obtenerMediosPago() {
        return pagoService.ObtenerListaMediosPago();
    }

    @Path("/mediospago/{id}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public MediosPago obtenerMediosPagoByID(@PathParam("id") int id) {
        return pagoService.ObtenerMedioPago(id);
    }

    @Path("/obtenerPagoXIdPago/{id}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Pago ObtenerPagoXIdPago(@PathParam("id") int Id) {
        return pagoService.ObtenerPagoXIdPago(Id);
    }

}
