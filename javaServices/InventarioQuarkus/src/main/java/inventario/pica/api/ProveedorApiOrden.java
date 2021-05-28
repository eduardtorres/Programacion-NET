package inventario.pica.api;

import org.eclipse.microprofile.rest.client.inject.RegisterRestClient;

import javax.enterprise.context.Dependent;
import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;
import inventario.pica.dominio.*;

@Dependent
@Path("proveedor/")
@RegisterRestClient
public interface ProveedorApiOrden {

    @POST
    @Path("/orden/colocar/{Id}")
    @Produces(MediaType.APPLICATION_JSON)
    @Consumes(MediaType.APPLICATION_JSON)
    RespuestaOrdenProveedor ColocaOrdenProveedor(ProveedorOrdenDto proveedorOrdenDto);

}
