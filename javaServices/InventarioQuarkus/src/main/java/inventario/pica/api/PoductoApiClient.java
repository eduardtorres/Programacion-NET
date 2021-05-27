package inventario.pica.api;

import inventario.pica.dominio.InventarioProductoDto;
import org.eclipse.microprofile.rest.client.inject.RegisterRestClient;

import javax.enterprise.context.Dependent;
import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;

@Dependent
@RegisterRestClient
public interface PoductoApiClient {
    
    @Path("/producto/inventario/actualizar/{Id}")
    @POST
    @Produces(MediaType.APPLICATION_JSON)
    @Consumes(MediaType.APPLICATION_JSON)
   // double ObtenerImpuesto(@PathParam("Id") long Id);
    String ActulizarInventarioProducto(InventarioProductoDto inventarioProductoDto);

}
