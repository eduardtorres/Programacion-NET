package cotizacion.pica.dominio;

import java.text.DateFormat;
import java.util.Date;

public class CotizacionDto {

    public Long    id;
    public Long    idTransportador;
    public Long    idCliente;
    public String  codCiudadOrigen;
    public String  codCiudadDestino;
    public Double  alto;
    public Double  ancho;
    public Double  largo;
    public Double  peso;
    public Double  valorDeclarado;
    public Boolean destinoNacional;
    public Date fechaPeticion;
    public String  moneda;

}