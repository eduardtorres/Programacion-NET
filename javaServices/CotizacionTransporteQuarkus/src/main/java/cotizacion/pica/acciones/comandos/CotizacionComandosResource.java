package cotizacion.pica.acciones.comandos;

import cotizacion.pica.servicios.*;
import cotizacion.pica.repositorios.*;
import cotizacion.pica.dominio.*;

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

@Path("/cotizacion")
public class CotizacionComandosResource {


    @Inject
    CotizacionService cotizacionService;

    @Path("/producto/agregar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto AgregarCotizacion(CotizacionDto request) {
        System.out.println("Agregado");
        return cotizacionService.AgregarCotizacion(request);
    }

    @Path("/producto/quitar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto QuitarProducto(CotizacionDto request) {
        System.out.println("Quitar "+request.id);
        return cotizacionService.QuitarCotizacion(request);
    }
/*	//DEscargar por ID
	@Path("/descargar/{cantidad}")
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto DescargarCotizacion(CotizacionDto request,@PathParam("cantidad") int cantidad) {
        System.out.println(" Requeste : "+request );
        System.out.println(" cantidad : " + cantidad );
        return cotizacionService.DescargarCotizacion(request,cantidad);

    }*/


    @Path("/limpiar/{codigo}/{cantidad}")
    @PUT
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto DescargarCotizacionCodigo( @PathParam("Codigo") String Codigo, @PathParam("cantidad") int Cantidad) {

        System.out.println("Hola" + Codigo);
        System.out.println("Hola 2" + Cantidad);
        return cotizacionService.DescargarCotizacionCodigo(Codigo,Cantidad);
    }


}