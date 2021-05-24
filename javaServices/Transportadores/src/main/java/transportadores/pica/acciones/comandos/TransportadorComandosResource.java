package transportadores.pica.acciones.comandos;

import transportadores.pica.servicios.*;
import transportadores.pica.dominio.*;
import transportadores.pica.dominio.RespuestaBaseDto;
import transportadores.pica.dominio.TransportadorDto;
import transportadores.pica.servicios.TransportadorService;

import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;


import javax.inject.Inject;

@Path("/transportador")
public class TransportadorComandosResource {


    @Inject
    TransportadorService transportadorService;

    @Path("/transportador/agregar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto Agregartransportador(TransportadorDto request) {
        System.out.println("Agregado");
        return transportadorService.AgregarTransportador(request);
    }

    @Path("/quitar")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public RespuestaBaseDto QuitarProducto(TransportadorDto request) {
        System.out.println("Quitar "+request.idTransportador);
        return transportadorService.QuitarTransportador(request);
    }

}