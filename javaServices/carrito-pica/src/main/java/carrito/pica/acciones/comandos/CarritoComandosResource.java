package carrito.pica.acciones.comandos;

import carrito.pica.servicios.*;
import carrito.pica.repositorios.*;
import carrito.pica.dominio.*;

import javax.ws.rs.POST;
import javax.ws.rs.DELETE;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.PathParam;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;


import java.util.Collections;
import java.util.List;
import java.util.Optional;
import java.util.concurrent.TimeUnit;
import java.util.logging.Logger;

import javax.inject.Inject;

@Path("/carrito")
public class CarritoComandosResource {

    @Inject
    CarritoService carritoService;

    @Path("/producto/agregar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto AgregarProucto(ProductoDto request) {
        return carritoService.AgregarProducto(request);
    }

    @Path("/producto/quitar")
    @DELETE
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto QuitarProducto(ProductoDto request) {
        return carritoService.QuitarProducto(request);
    }

    @Path("/limpiar/{id}")
    @DELETE
    @Produces(MediaType.APPLICATION_JSON)
    public int LimpiarCarrito( @PathParam("id") int id) {
        return carritoService.LimpiarCarrito(id);
    }


}