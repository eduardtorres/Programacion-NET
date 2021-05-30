package proveedor.pagos.com.co.Accion.Comandos;


import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.core.MediaType;

import proveedor.pagos.com.co.Dominios.Pago;
import proveedor.pagos.com.co.Dominios.Respuesta;

@Path("/ProveedorPagos")
public class ProveedorPagos {

    @Path("/ProcesarPago")
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Respuesta RealizarPago(Pago pago) {
        Respuesta respuesta= new Respuesta();
        if (pago.TipoTarjeta.equals("MC")) {
            respuesta.codRespuesta=0;
        } else{
            respuesta.codRespuesta=1;
        }
        return respuesta;
    }
}