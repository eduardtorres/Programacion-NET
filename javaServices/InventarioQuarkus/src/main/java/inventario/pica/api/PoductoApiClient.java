package inventario.pica.api;

import inventario.pica.dominio.InventarioActualizado;
import inventario.pica.dominio.InventarioProductoDto;
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
    @Produces(MediaType.TEXT_PLAIN)
    @Consumes(MediaType.APPLICATION_JSON)
  //  InventarioActualizado ActulizarInventarioProducto(InventarioProductoDto inventarioProductoDto);
    String ActulizarInventarioProducto(InventarioProductoDto inventarioProductoDto);

}
