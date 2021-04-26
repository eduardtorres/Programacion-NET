package carrito.pica;

import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import java.util.Collections;
import java.util.List;
import java.util.Optional;
import java.util.concurrent.TimeUnit;
import java.util.logging.Logger;


import javax.inject.Inject;

@Path("/get-all")
public class CarritoResource {

    @Inject
    CarritoService carritoService;

    @POST
    @Produces(MediaType.APPLICATION_JSON)
    public List<Carrito> getAll() {
        return carritoService.fetchAll();
    }
}