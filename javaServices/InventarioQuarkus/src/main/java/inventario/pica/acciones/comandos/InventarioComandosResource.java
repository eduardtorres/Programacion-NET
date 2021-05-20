package inventario.pica.acciones.comandos;

import inventario.pica.servicios.*;
import inventario.pica.repositorios.*;
import inventario.pica.dominio.*;

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

@Path("/inventario")
public class InventarioComandosResource {

    @Inject
    InventarioService inventarioService;

    @Path("/producto/agregar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto AgregarProucto(ProductoDto request) {
        return inventarioService.AgregarProducto(request);
    }

    @Path("/producto/quitar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto QuitarProducto(ProductoDto request) {
        return inventarioService.QuitarProducto(request);
    }

    @Path("/limpiar/{id}")
    @DELETE
    @Produces(MediaType.APPLICATION_JSON)
    public int Limpiarinventario( @PathParam("id") int id) {
        return inventarioService.Limpiar(id);
    }


}