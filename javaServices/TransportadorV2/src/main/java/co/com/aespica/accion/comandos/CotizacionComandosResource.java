package co.com.aespica.accion.comandos;

import co.com.aespica.dominio.*;
import co.com.aespica.repositorio.*;
import co.com.aespica.servicios.*;

import javax.inject.Inject;
import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;

@Path("/transportador")
public class CotizacionComandosResource {


    @Inject
    CotizacionService cotizacionService;

    @Path("/envio/agregar")
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
    public RespuestaBaseDto QuitarProducto(CotizacionDto cotizacionDto) {
        System.out.println("Quitar "+ cotizacionDto.idTransportador);
        return cotizacionService.QuitarCotizacion(cotizacionDto);
    }

    @Path("/limpiar/{codigo}/{cantidad}")
    @PUT
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto DescargarCotizacionCodigo( @PathParam("Codigo") String Codigo, @PathParam("cantidad") int Cantidad) {

        System.out.println("Hola" + Codigo);
        System.out.println("Hola 2" + Cantidad);
        return cotizacionService.DescargarCotizacionCodigo(Codigo,Cantidad);
    }


}