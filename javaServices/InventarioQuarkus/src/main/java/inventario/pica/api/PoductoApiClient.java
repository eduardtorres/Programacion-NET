package inventario.pica.api;

import inventario.pica.dominio.*;
import org.eclipse.microprofile.rest.client.inject.RegisterRestClient;

import javax.enterprise.context.Dependent;
import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;

@Dependent
@Path("producto/")
@RegisterRestClient
public interface PoductoApiClient {
    
    @POST
    @Path("/inventario/actualizar")
    @Produces(MediaType.APPLICATION_JSON)
    @Consumes(MediaType.APPLICATION_JSON)
  //  InventarioActualizado ActulizarInventarioProducto(InventarioProductoDto inventarioProductoDto);
    int ActualizarInventarioProducto(InventarioProductoDto inventarioProductoDto);

}
