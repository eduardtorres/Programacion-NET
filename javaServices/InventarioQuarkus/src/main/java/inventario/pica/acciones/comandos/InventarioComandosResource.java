package inventario.pica.acciones.comandos;

import inventario.pica.servicios.*;
import inventario.pica.repositorios.*;
import inventario.pica.dominio.*;

import javax.validation.Valid;
import javax.ws.rs.POST;
import javax.ws.rs.DELETE;
import javax.ws.rs.PUT;
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
    public RespuestaBaseDto AgregarInventario(InventarioDto request) {
        System.out.println("Agregado");
        return inventarioService.AgregarInventario(request);
    }

    @Path("/producto/quitar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto QuitarProducto(InventarioDto request) {
        System.out.println("Quitar "+request.id);
        return inventarioService.QuitarInventario(request);
    }
	/*//DEscargar por ID
	@Path("/descargar/{cantidad}")
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto DescargarInventario(InventarioDto request,@PathParam("cantidad") int cantidad) {
        System.out.println(" Requeste : "+request );
        System.out.println(" cantidad : " + cantidad );
        return inventarioService.DescargarInventario(request,cantidad);

    }
    */
    //DEscargar por ID
    @Path("/descargar/{id}")
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto DescargarInventario(DescargarInventario request,@PathParam("id") long id) {
        System.out.println(" Requeste : " + request.codigo );
        System.out.println(" id : " + id );
        return inventarioService.DescargarInventario(request,id);

    }

    @Path("/limpiar/{codigo}/{cantidad}")
    @PUT
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto DescargarInventarioCodigo( @PathParam("Codigo") String Codigo, @PathParam("cantidad") int Cantidad) {

        System.out.println("Hola" + Codigo);
        System.out.println("Hola 2" + Cantidad);
        return inventarioService.DescargarInventarioCodigo(Codigo,Cantidad);
    }


}