package cotizacion.pica.servicios;

import cotizacion.pica.repositorios.*;
import cotizacion.pica.dominio.*;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;

import javax.persistence.EntityManager;
import javax.transaction.Transactional;

import java.util.Date;
import java.util.List;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;

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

    public Cotizacion ObtenerPorCodigoTipoPro( Long Id ) {
        return entityManager
                .createNamedQuery("Cotizacion.ObtenerPorCodigoTipoPro", Cotizacion.class)
                .setParameter("Id", Id)
           //     .setParameter("tipoproveedor", tipoproveedor)
                .getResultStream()
                .findFirst()
                .orElse(null);
    }


    public List<Cotizacion> ObtenerCotizacionID(Long id)
    {
        return entityManager
                .createNamedQuery("Producto.ObtenerPorid", Cotizacion.class)
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
                .setParameter("Id", cotizacionDto.id)
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
                               String Moneda) {
        Cotizacion cotizacionEncontrado = ObtenerPorCodigoTipoPro(Id);
        if( cotizacionEncontrado == null )
        {
            Date date = Calendar.getInstance().getTime();
            DateFormat dateFormat = new SimpleDateFormat("yyyy-mm-dd hh:mm:ss");
            String strDate = dateFormat.format(date);
            cotizacionEncontrado = new Cotizacion(                    IdTransportador,
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
                    Moneda);
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
/*
    @Transactional
    public RespuestaBaseDto DescargarCotizacion(CotizacionDto cotizacionDto, int cantidad)
    {
        int retorno = 0;

        System.out.println(" Descargar ID : "+cotizacionDto.id);

        if (cotizacionDto.tipoProveedor == "Local") {
             retorno = entityManager.createQuery("UPDATE Cotizacion e SET e.Cotizacion = e.Cotizacion - :cantidad "
                    + "WHERE e.Id = :id")
                    .setParameter("id", cotizacionDto.id)
                    .setParameter("cantidad", cantidad)
                    //          .setParameter("CodigoProveedor", request.codigoProveedor)
                    .executeUpdate();
        }
        else
        {
             retorno = entityManager.createQuery("UPDATE Cotizacion e SET e.Cotizacion = e.Cotizacion - :cantidad "
                    + "WHERE e.Codigo = :codigo")
                    .setParameter("codigo", cotizacionDto.codigo )
                    .setParameter("cantidad", cantidad)
                    //          .setParameter("CodigoProveedor", request.codigoProveedor)
                    .executeUpdate();
        }
        RespuestaBaseDto respuesta;

        if( retorno >= 1 )
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 100;
            respuesta.mensaje = "Producto Descargado satisfactoriamente";
        }
        else
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 0;
            respuesta.mensaje = "Producto no existe:" + cotizacionDto ;
        }
        return respuesta;

    }
*/
    @Transactional
    public RespuestaBaseDto QuitarCotizacion( CotizacionDto request ) {

  //      int retorno = entityManager.createQuery("delete from Producto where Id = :Id and Codigo = :Codigo and CodigoProveedor = :CodigoProveedor")
        int retorno = entityManager.createQuery("delete from Cotizacion where Id = :Id ")
            .setParameter("Id", request.id)
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
            respuesta.mensaje = "Producto no existe:" + request.id ;
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
/*
    public CotizacionDto CotizarOrden(CotizacionRequest request)
    {
        List<Producto> productos = ObtenerProductos( request.cotizacionId );
        double suma = 0;
        for( Producto item : productos )
        {
            suma = suma + item.Precio;
        }
        CotizacionDto response = new CotizacionDto();
        response.Neto = suma;
        response.Transporte = 0;
        response.Impuestos = 0;
        response.Total = ( response.Neto + response.Transporte + response.Impuestos );
        return response;
    }

    public List<ProductoDto> Disponibilidad(int id)
    {
        List<ProductoDto> Cotizacions = ObtenerCotizacionDto( id );
        for( ProductoDto item : productos )
        {
            if( item.id == 10 )
                item.disponibilidad = "NODISPONIBLE";
            else
                item.disponibilidad = "DISPONIBLE";
        }
        return productos;
    }

    private   ObtenerCotizacionDto(int id) {
    }
*/
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