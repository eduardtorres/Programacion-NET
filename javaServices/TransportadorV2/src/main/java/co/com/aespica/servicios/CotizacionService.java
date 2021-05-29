package co.com.aespica.servicios;

import co.com.aespica.dominio.*;
import co.com.aespica.repositorio.Cotizacion;
import co.com.aespica.repositorio.Flete;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import javax.transaction.Transactional;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

@Dependent
@Transactional(Transactional.TxType.SUPPORTS)
public class CotizacionService {

    @Inject
    EntityManager entityManager;

    public List<Cotizacion> fetchAll() {
        System.out.println("Mostrar Todo");
        return entityManager
                .createNamedQuery("Cotizacion.findAll", Cotizacion.class)
                .getResultList();
    }

    public Cotizacion ObtenerPorIdTransportador( Long idTransportador ) {
        return entityManager
                .createNamedQuery("Cotizacion.ObtenerPorIdTransportador", Cotizacion.class)
                .setParameter("idTransportador", idTransportador)
           //     .setParameter("tipoproveedor", tipoproveedor)
                .getResultStream()
                .findFirst()
                .orElse(null);
    }


    public List<Cotizacion> ObtenerCotizacionID(Long id)
    {
        return entityManager
                .createNamedQuery("Producto.ObtenerPorId", Cotizacion.class)
                .setParameter("Id", id)
                .getResultList();     
    }
    public List<Cotizacion> ObtenerCotizacionICodigo(Long Id)
    {
        return entityManager
                .createNamedQuery("Producto.ObtenerPorCodigo", Cotizacion.class)
                .setParameter("Id", Id)
                .getResultList();
    }

    public List<CotizacionDto> ObtenerCotizacionDto(Long id)
    {        
        return Cotizacion.ToListDto( ObtenerCotizacion(id) );
    }
    public List<Cotizacion> ObtenerCotizacion(Long id)
    {
        return entityManager
                .createNamedQuery("Cotizacion.ObtenerPorid", Cotizacion.class)
                .setParameter("Id", id)
                .getResultList();
    }

    public Cotizacion CotizacionExiste(CotizacionDto cotizacionDto)
    {
        return entityManager
                .createNamedQuery("Cotizacion.ObtenerPorid", Cotizacion.class)
                .setParameter("Id", cotizacionDto.idTransportador)
                .getResultStream()
                .findFirst()
                .orElse(null);  
    }


    @Transactional
    public Cotizacion Obtener( Long Id,
                               Long IdTransportador,
                               Long IdCliente,
                               String CodCiudadOrigen,
                               String CodCiudadDestino,
                               Double Alto,
                               Double Ancho,
                               Double Largo,
                               Double Peso,
                               Double ValorDeclarado,
                               Boolean DestinoNacional,
                               Date FechaPeticion,
                               String Moneda,
                               Double ValorCotizacion) {
        Cotizacion cotizacionEncontrado = ObtenerPorIdTransportador(IdTransportador);
        if( cotizacionEncontrado == null )
        {
            Date date = Calendar.getInstance().getTime();
            DateFormat dateFormat = new SimpleDateFormat("yyyy-mm-dd hh:mm:ss");
            String strDate = dateFormat.format(date);
            cotizacionEncontrado = new Cotizacion(
                    Id,
                    IdTransportador,
                    IdCliente,
                    CodCiudadOrigen,
                    CodCiudadDestino,
                    Alto,
                    Ancho,
                    Largo,
                    Peso,
                    ValorDeclarado,
                    DestinoNacional,
                    FechaPeticion,
                    Moneda,
                    ValorCotizacion);
            entityManager.persist(cotizacionEncontrado);
        }
        return cotizacionEncontrado;
    }

    @Transactional
    public RespuestaBaseDto AgregarCotizacion(CotizacionDto cotizacionDto)
    {

        Cotizacion cotizacionEncontrado = CotizacionExiste(cotizacionDto);
        RespuestaBaseDto respuesta;
        if( cotizacionEncontrado != null )
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 0;
            respuesta.mensaje = "El cotizacion ya existe en el cotizacion";
        }
        else
        {
            Cotizacion cotizacion = new Cotizacion();
            cotizacion.LoadFromDto(cotizacionDto);
            entityManager.persist(cotizacion);
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 100;
            respuesta.mensaje = "Cotizacion agregado satisfactoriamente";
        }
        return respuesta;
    }
    @Transactional
    public RespuestaBaseDto QuitarCotizacion( CotizacionDto request ) {

  //      int retorno = entityManager.createQuery("delete from Producto where Id = :Id and Codigo = :Codigo and CodigoProveedor = :CodigoProveedor")
        int retorno = entityManager.createQuery("delete from Cotizacion where Id = :Id ")
            .setParameter("Id", request.idTransportador)
  //          .setParameter("Codigo", request.codigo)
  //          .setParameter("CodigoProveedor", request.codigoProveedor)
            .executeUpdate();

            RespuestaBaseDto respuesta;

        if( retorno >= 1 )
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 100;
            respuesta.mensaje = "Producto quitado satisfactoriamente";    
        }
        else
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 0;
            respuesta.mensaje = "Producto no existe:" + request.idTransportador ;
        }

        return respuesta;
    }

    @Transactional
    public int Limpiar(int id) {
        entityManager.createQuery("delete from Producto where Id = :Id")
            .setParameter("Id", id)
            .executeUpdate();
        int retorno = entityManager.createQuery("delete from cotizacion where Id = :Id")
            .setParameter("Id", id)
            .executeUpdate();
        return retorno;
    }
    @Transactional
    public RespuestaCotizacionDto obtenerFlete(CotizacionDto cotizacionDto)
    {
       // Object ValoresOrigen = new FleteDto();
       // Object ValoresDestino = new FleteDto();
        String departamentoOrigen = cotizacionDto.codCiudadOrigen.substring(0,2);
        String departamentoDestino = cotizacionDto.codCiudadDestino.substring(0,2);
        Flete ValoresOrigen = ObtenerFleteID(departamentoOrigen);
        Flete ValoresDestino = ObtenerFleteID(departamentoDestino);

        double valorCotizacion = 0;

        //Simulacion Flete
        //se obtiene el valor de ogigen por destino
        valorCotizacion = ValoresOrigen.FactorOrigen * ValoresDestino.FactorDestino;
        cotizacionDto.valorCotizacion = valorCotizacion + (ValoresOrigen.FactorOrigen +ValoresOrigen.FactorSocial  + ValoresOrigen.FactorTipoTransporte
                + (ValoresOrigen.FactorValorCarga * cotizacionDto.valorDeclarado) +
                (ValoresOrigen.FactorTipoCarga * (cotizacionDto.alto * cotizacionDto.ancho * cotizacionDto.largo ) ) + (ValoresOrigen.FactorTipoTransporte * cotizacionDto.peso));

                //Guarda cotizacion
        Cotizacion cotizacion = new Cotizacion();
        cotizacion.LoadFromDto(cotizacionDto);
        entityManager.persist(cotizacion);
        RespuestaCotizacionDto respuesta = new RespuestaCotizacionDto();
        respuesta.codigo = 1;
        respuesta.mensaje = "Cotizacion Generada Corectamente " + cotizacionDto.valorCotizacion;
        respuesta.valorCotizacion = cotizacionDto.valorCotizacion;
        //

       return respuesta;
    }


    public Flete ObtenerFleteID(String codDane) {
        return entityManager
                .createNamedQuery("Flete.ObtenerxDepartamento", Flete.class)
                .setParameter("iddanedepartamento", codDane)
                .getSingleResult();
    }
@Transactional
public RespuestaBaseDto DescargarCotizacionCodigo( String Codigo , int cantidad ) {
    RespuestaBaseDto respuesta;

    System.out.println("Holaaaa "+ Codigo);
    System.out.println("Holaaaa "+ cantidad);

    //consultar cotizacion actual
        respuesta = new RespuestaBaseDto();
        respuesta.codigo = 0;
        respuesta.mensaje = "El cotizacion ya existe en el cotizacion";

    return respuesta;
}
}