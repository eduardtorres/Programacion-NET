package co.com.aespica.Servicio;

import org.eclipse.microprofile.rest.client.inject.RegisterRestClient;

import co.com.aespica.dominio.*;

import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.core.MediaType;

//import java.util.Set;

@Path("/ProveedorPagos/")
@RegisterRestClient
public interface ProveedorPagoService {

    @POST
    @Path("/ProcesarPago/")
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    RespuestaProveedorPago ejecutarPagoProveedor(PagoDTO pagoDTO);
}