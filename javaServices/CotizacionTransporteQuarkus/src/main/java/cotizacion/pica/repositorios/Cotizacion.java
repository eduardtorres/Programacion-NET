package cotizacion.pica.repositorios;

import javax.persistence.*;
import java.util.Date;

import cotizacion.pica.dominio.CotizacionDto;

import java.text.DateFormat;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "Cotizacion")
@NamedQueries({
        @NamedQuery(name = "Cotizacion.findAll", query = "SELECT i FROM Cotizacion i"),
        @NamedQuery(name = "Cotizacion.ObtenerPorCodigoTipoPro", query = "SELECT i FROM Cotizacion i WHERE i.IdTransportador = :IdTransportador order by Id desc"),
        @NamedQuery(name = "Cotizacion.ObtenerPorid", query = "SELECT p FROM Cotizacion p WHERE p.Id = :Id"),
        @NamedQuery(name = "Cotizacion.ObtenerPorCodigo", query = "SELECT p FROM Cotizacion p WHERE p.IdCliente = :IdCliente order by Id desc")

})
public class Cotizacion {


    @Id
   // @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "Id")
    public Long Id;
    @Column(name = "IdTransportador", nullable = false)
    public Long IdTransportador;
    @Column(name = "IdCliente", nullable = false)
    public Long IdCliente;
    @Column(name = "CodCiudadOrigen", nullable = false)
    public String CodCiudadOrigen;
    @Column(name = "CodCiudadDestino", nullable = false)
    public String CodCiudadDestino;
    @Column(name = "Alto", nullable = false)
    public Double Alto;
    @Column(name = "Ancho", nullable = false)
    public Double Ancho;
    @Column(name = "Largo", nullable = false)
    public Double Largo;
    @Column(name = "Peso", nullable = false)
    public Double Peso;
    @Column(name = "ValorDeclarado", nullable = false)
    public Double ValorDeclarado;
    @Column(name = "DestinoNacional", nullable = false)
    public Boolean DestinoNacional;
    @Column(name = "FechaPeticion", nullable = false)
    public Date FechaPeticion;
    @Column(name = "Moneda", nullable = false)
    public String Moneda;


    public Cotizacion()
    {

    }

    public Cotizacion(Long _IdTransportador,
                      Long _IdCliente,
                      String _CodCiudadOrigen,
                      String _CodCiudadDestino,
                      Double _Alto,
                      Double _Ancho,
                      Double _Largo,
                      Double _Peso,
                      Double _ValorDeclarado,
                      Boolean _DestinoNacional,
                      Date _FechaPeticion,
                      String _Moneda)
    {
            //    Id              = _Id;
                IdTransportador = _IdTransportador;
                IdCliente       = _IdCliente;
                CodCiudadOrigen = _CodCiudadOrigen;
                CodCiudadDestino = _CodCiudadDestino;
                Alto            = _Alto;
                Ancho           = _Ancho;
                Largo           = _Largo;
                Peso            = _Peso;
                ValorDeclarado  = _ValorDeclarado;
                DestinoNacional = _DestinoNacional;
                FechaPeticion   = _FechaPeticion;
                Moneda          = _Moneda;

    }

    public Cotizacion(Long Id, Long IdTransportador, Long IdCliente, String CodCiudadOrigen, String CodCiudadDestino, Double Alto, Double Ancho, Double Largo, Double Peso, Double ValorDeclarado, Boolean DestinoNacional, Date FechaPeticion, String Moneda) {
    }

    public Long   getId() { return Id; }
    public Long   getIdTransportador() { return IdTransportador; }
    public Long   getIdCliente() { return IdCliente; }
    public String getCodCiudadOrigen() { return CodCiudadOrigen; }
    public String getCodCiudadDestino() { return CodCiudadDestino; }
    public Double getAlto() { return Alto; }
    public Double getAncho() { return Ancho; }
    public Double getLargo() { return Largo; }
    public Double getPeso() { return Peso; }
    public Double getValorDeclarado() { return ValorDeclarado; }
    public Boolean getDestinoNacional() { return DestinoNacional; }
    public Date getFechaPeticion() { return FechaPeticion; }
    public String getMoneda() { return Moneda; }


    public void LoadFromDto(CotizacionDto cotizacionDto)
    {
        Id               = cotizacionDto.id;
        IdTransportador  = cotizacionDto.idTransportador;
        IdCliente        = cotizacionDto.idCliente;
        CodCiudadOrigen  = cotizacionDto.codCiudadOrigen;
        CodCiudadDestino = cotizacionDto.codCiudadDestino;
        Alto             = cotizacionDto.alto;
        Ancho            = cotizacionDto.ancho;
        Largo            = cotizacionDto.largo;
        Peso             = cotizacionDto.peso;
        ValorDeclarado   = cotizacionDto.valorDeclarado;
        DestinoNacional  = cotizacionDto.destinoNacional;
        FechaPeticion    = cotizacionDto.fechaPeticion;
        Moneda           = cotizacionDto.moneda;

    }
    public CotizacionDto ToDto()
    {
        CotizacionDto response = new CotizacionDto();

        response.id               = Id               ;
        response.idTransportador  = IdTransportador  ;
        response.idCliente        = IdCliente        ;
        response.codCiudadOrigen  = CodCiudadOrigen  ;
        response.codCiudadDestino = CodCiudadDestino ;
        response.alto             = Alto             ;
        response.ancho            = Ancho            ;
        response.largo            = Largo            ;
        response.peso             = Peso             ;
        response.valorDeclarado   = ValorDeclarado   ;
        response.destinoNacional  = DestinoNacional  ;
        response.fechaPeticion    = FechaPeticion    ;


        return response;
    }

    public static List<CotizacionDto> ToListDto( List<Cotizacion> originalList )
    {
        List<CotizacionDto> newList = new ArrayList<CotizacionDto>();
        for( Cotizacion item : originalList )
        {
            newList.add(item.ToDto());
        }
        return newList;
    }
}
