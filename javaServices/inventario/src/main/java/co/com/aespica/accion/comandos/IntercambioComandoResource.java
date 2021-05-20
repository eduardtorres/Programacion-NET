package co.com.aespica.accion.comandos;

import co.com.aespica.Servicio.InventarioService;
import co.com.aespica.dominio.PagoDTO;

import javax.inject.Inject;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.core.MediaType;

@Path("/pago")
public class IntercambioComandoResource {
    @Inject
    InventarioService inventarioService;

    @Path("/orden/authorizar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public int agregarPago(PagoDTO pagoDto) {
        return 0;
    }


}
