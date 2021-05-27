package inventario.pica.servicios;

import inventario.pica.repositorios.*;
import inventario.pica.dominio.*;
import inventario.pica.api.PoductoApiClient;
import org.eclipse.microprofile.rest.client.inject.RestClient;

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
public class InventarioService {

    @Inject
    EntityManager entityManager;

    @Inject
    @RestClient
    PoductoApiClient poductoApiClient;

    public List<Inventario> fetchAll() {
        return entityManager
                .createNamedQuery("Inventario.findAll", Inventario.class)
                .getResultList();
    }

    public Inventario ObtenerPorCodigoTipoPro( String codigo , String tipoproveedor ) {
        return entityManager
                .createNamedQuery("Inventario.ObtenerPorCodigoTipoPro", Inventario.class)
                .setParameter("codigo", codigo)
                .setParameter("tipoproveedor", tipoproveedor)
                .getResultStream()
                .findFirst()
                .orElse(null);
    }


    public List<Inventario> ObtenerInventarioID(int id)
    {
        return entityManager
                .createNamedQuery("Producto.ObtenerPorid", Inventario.class)
                .setParameter("Id", id)
                .getResultList();     
    }
    public List<Inventario> ObtenerInventarioICodigo(String Codigo)
    {
        return entityManager
                .createNamedQuery("Producto.ObtenerPorCodigo", Inventario.class)
                .setParameter("Codigo", Codigo)
                .getResultList();
    }

    public List<InventarioDto> ObtenerInventarioDto(long id)
    {        
        return Inventario.ToListDto( ObtenerInventario(id) );
    }
    public List<Inventario> ObtenerInventario(long id)
    {
        return entityManager
                .createNamedQuery("Inventario.ObtenerPorid", Inventario.class)
                .setParameter("Id", id)
                .getResultList();
    }

    public Inventario InventarioExiste(InventarioDto inventarioDto)
    {
        return entityManager
                .createNamedQuery("Inventario.ObtenerPorid", Inventario.class)
                .setParameter("Id", inventarioDto.id)
                .getResultStream()
                .findFirst()
                .orElse(null);  
    }


    @Transactional
    public Inventario Obtener( String Categoria, String Codigo, String CodigoProveedor,
                              String Descripcion, String Disponibilidad, String Fabricante,
                              int Inventario, String Moneda, String Nombre, String NombreImagen,
                              Double Precio, String TipoProveedor, String UrlImagen) {
        Inventario inventarioEncontrado = ObtenerPorCodigoTipoPro(Codigo,TipoProveedor);
        if( inventarioEncontrado == null )
        {
            Date date = Calendar.getInstance().getTime();
            DateFormat dateFormat = new SimpleDateFormat("yyyy-mm-dd hh:mm:ss");
            String strDate = dateFormat.format(date);
            inventarioEncontrado = new Inventario(0,Categoria, Codigo, CodigoProveedor, Descripcion, Fabricante,Inventario, Moneda, Nombre,Precio,TipoProveedor);
            entityManager.persist(inventarioEncontrado);
        }
        return inventarioEncontrado;
    }

    @Transactional
    public RespuestaBaseDto AgregarInventario(InventarioDto inventarioDto)
    {

        Inventario inventarioEncontrado = InventarioExiste(inventarioDto);
        RespuestaBaseDto respuesta;
        if( inventarioEncontrado != null )
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 0;
            respuesta.mensaje = "El inventario ya existe en el inventario";
        }
        else
        {
            Inventario inventario = new Inventario();
            inventario.LoadFromDto(inventarioDto);
            entityManager.persist(inventario);
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 100;
            respuesta.mensaje = "Inventario agregado satisfactoriamente";
        }
        return respuesta;
    }
 /*   @Transactional
    public RespuestaBaseDto ActualizarInventarioProducto(InventarioDto inventarioDto, long ID)
    {
        Inventario inventarioActualizado = InventarioService.
        Inventario inventarioEncontrado = InventarioExiste(inventarioDto);
        RespuestaBaseDto respuesta;
        if( inventarioEncontrado != null )
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 0;
            respuesta.mensaje = "El inventario ya existe en el inventario";
        }
        else
        {
            Inventario inventario = new Inventario();
            inventario.LoadFromDto(inventarioDto);
            entityManager.persist(inventario);
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 100;
            respuesta.mensaje = "Inventario agregado satisfactoriamente";
        }
        return respuesta;
    }
*/
    @Transactional
    public RespuestaBaseDto DescargarInventario(DescargarInventario descargarInventario, long id)
    {
        int retorno = 0;

        System.out.println(" Descargar codigo : " + descargarInventario.codigo);
        System.out.println(" Descargar CantidadOrdenada : " + descargarInventario.CantidadOrdenada);
        System.out.println(" Descargar codigoProveedor : " + descargarInventario.codigoProveedor);
        System.out.println(" Descargar tipoProveedor : " + descargarInventario.tipoProveedor);

        if (descargarInventario.tipoProveedor.equals("Local")) {

            System.out.println(" proveedor local ");

            retorno = entityManager.createQuery("UPDATE Inventario e SET e.Inventario = e.Inventario - :cantidad " +
                    "WHERE e.Id = :id")
                    .setParameter("cantidad", descargarInventario.CantidadOrdenada)
                    .setParameter("id", id)
                    .executeUpdate();
            //llamar Actualizar

          //  String inventarioActualProdcuto = poductoApiClient.ActulizarInventarioProducto(InventarioProductoDto);
           // double impuestosPorc = poductoApiClient.ObtenerImpuesto(carrito.getPais());
        }
        else
        {
            retorno = entityManager.createQuery("UPDATE Inventario e SET e.Inventario = e.Inventario - :cantidad "
                    + "WHERE e.Codigo = :codigo")
                    .setParameter("cantidad", descargarInventario.CantidadOrdenada)
                    .setParameter("codigo", descargarInventario.codigo)
                    //          .setParameter("CodigoProveedor", request.codigoProveedor)
                    .executeUpdate();

        }
        RespuestaBaseDto respuesta;

        if( retorno >= 1 )
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 1;
            respuesta.mensaje = "Producto Descargado satisfactoriamente" + retorno;
        }
        else
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 0;
            respuesta.mensaje = "Producto no existe:" + descargarInventario +" "+ retorno ;
        }
        return respuesta;

    }

    @Transactional
    public RespuestaBaseDto QuitarInventario( InventarioDto request ) {

  //      int retorno = entityManager.createQuery("delete from Producto where Id = :Id and Codigo = :Codigo and CodigoProveedor = :CodigoProveedor")
        int retorno = entityManager.createQuery("delete from Inventario where Id = :Id ")
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
            respuesta.mensaje = "Producto no existe:" + request.codigo ;    
        }

        return respuesta;
    }

    @Transactional
    public int Limpiar(int id) {
        entityManager.createQuery("delete from Producto where Id = :Id")
            .setParameter("Id", id)
            .executeUpdate();
        int retorno = entityManager.createQuery("delete from inventario where Id = :Id")
            .setParameter("Id", id)
            .executeUpdate();
        return retorno;
    }
/*
    public CotizacionDto CotizarOrden(CotizacionRequest request)
    {
        List<Producto> productos = ObtenerProductos( request.inventarioId );
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
        List<ProductoDto> Inventarios = ObtenerInventarioDto( id );
        for( ProductoDto item : productos )
        {
            if( item.id == 10 )
                item.disponibilidad = "NODISPONIBLE";
            else
                item.disponibilidad = "DISPONIBLE";
        }
        return productos;
    }

    private   ObtenerInventarioDto(int id) {
    }
*/
@Transactional
public RespuestaBaseDto DescargarInventarioCodigo( String Codigo , int cantidad ) {
    RespuestaBaseDto respuesta;

    System.out.println("Holaaaa "+ Codigo);
    System.out.println("Holaaaa "+ cantidad);

    //consultar inventario actual
        respuesta = new RespuestaBaseDto();
        respuesta.codigo = 0;
        respuesta.mensaje = "El inventario ya existe en el inventario";

    return respuesta;
}
}