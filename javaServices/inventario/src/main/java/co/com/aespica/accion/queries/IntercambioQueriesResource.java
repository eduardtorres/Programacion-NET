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


@Path("/inventario")
public class IntercambioQueriesResource {
    @Inject
    InventarioService inventarioService;

    @Path("/producto/consultar")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Inventario> obtenerMediosPago() {
        return inventarioService.ObtenerListaInventario();
    }

    //@Path("/medios/consultar/{id}")
    //@GET
    //@Produces(MediaType.APPLICATION_JSON)
    //public MediosPago obtenerMediosPagoByID(@PathParam("id") int id) {
    //    return pagoService.ObtenerMedioPago(id);
    //}

    //@Path("/obtener/{id}")
    //@GET
    //@Produces(MediaType.APPLICATION_JSON)
    //public Pago ObtenerPagoXIdPago(@PathParam("id") int Id) {
    //    return pagoService.ObtenerPagoXIdPago(Id);
    //}

}
