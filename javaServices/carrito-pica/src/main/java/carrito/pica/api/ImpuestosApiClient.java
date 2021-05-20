package carrito.pica.api;

import org.eclipse.microprofile.rest.client.inject.RegisterRestClient;

import javax.enterprise.context.Dependent;
import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;

@Dependent
@RegisterRestClient
public interface ImpuestosApiClient {
    
    @Path("/precio/impuesto/total/obtener/{CodPais}")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Consumes(MediaType.APPLICATION_JSON)
    double ObtenerImpuesto(@PathParam("CodPais") String CodPais);

}
