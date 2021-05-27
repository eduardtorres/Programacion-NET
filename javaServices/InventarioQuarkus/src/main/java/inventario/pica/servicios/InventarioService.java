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
    @Inject
    @RestClient
    PoductoApiClient poductoApiClient;
    @Transactional
    public int ActualizaInventarioProducto(InventarioProductoDto inventarioProductoDto)
    {
        int  resp=0;
        //consulta inventario actual
        System.out.println("ID del producto que se consutal para informar "+ inventarioProductoDto.id);
        Inventario inventarioActual = InventarioActualizado(inventarioProductoDto);

        if ( inventarioActual != null )
        {
            //Llamado a servicio de producto

            System.out.println("Llama al productos "+ inventarioProductoDto.id);
            inventarioProductoDto.inventario = Integer.valueOf(inventarioActual.Inventario);
            System.out.println("nuevo inventario "+ inventarioProductoDto.inventario);
            //  InventarioActualizado inventarioActualizado = poductoApiClient.ActulizarInventarioProducto(inventarioProductoDto );
            String  Respuesta = poductoApiClient.ActulizarInventarioProducto(inventarioProductoDto );
            System.out.println("RESPUESTA  "  + Respuesta);
        }
        else {
            System.out.println("Inventario no disponible");
        }
        return resp;
    }

    public Inventario ObtenerInventarioID(long id)
    {
        return entityManager
                .createNamedQuery("Inventario.ObtenerPorid", Inventario.class)
                .setParameter("Id", id)
                .getSingleResult();
    }
    public List<Inventario> ObtenerInventarioICodigo(String Codigo)
    {
        return entityManager
                .createNamedQuery("Inventario.ObtenerPorCodigo", Inventario.class)
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
    public Inventario InventarioActualizado(InventarioProductoDto inventarioProductoDto)
    {
        return entityManager
                .createNamedQuery("Inventario.ObtenerPorid", Inventario.class)
                .setParameter("Id", Long.valueOf(inventarioProductoDto.id))
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

    @Transactional
    public RespuestaBaseDto DescargarInventario(DescargarInventario descargarInventario, long id) {
        int retorno = 0;
        int valida = 0;
        RespuestaBaseDto respuesta;
        respuesta = new RespuestaBaseDto();

        System.out.println(" Descargar codigo : " + descargarInventario.codigo);
        System.out.println(" Descargar CantidadOrdenada : " + descargarInventario.CantidadOrdenada);
        System.out.println(" Descargar codigoProveedor : " + descargarInventario.codigoProveedor);
        System.out.println(" Descargar tipoProveedor : " + descargarInventario.tipoProveedor);

        Inventario inventarioaActualizar = ObtenerInventarioID(id);

        if (descargarInventario.tipoProveedor.equals("Local")) {
            if (descargarInventario.tipoProveedor.equals(inventarioaActualizar.TipoProveedor)) {
                if (descargarInventario.CantidadOrdenada > 0) {
                    if ((inventarioaActualizar.Inventario - descargarInventario.CantidadOrdenada) >= 0) {
                        valida = 0;
                    } else {
                        valida = 1;
                        respuesta.mensaje = "La Cantidad solicitada supera el Stock del inventario " + inventarioaActualizar.Inventario + " cantidad solicitada "+descargarInventario.CantidadOrdenada;
                    }
                } else {
                    valida = 1;
                    respuesta.mensaje = "La cantidad solicitada es un valor negativo " + descargarInventario.CantidadOrdenada;
                }
            } else {
                valida = 1;
                respuesta.mensaje = "El tipo de proveedor no es consitente con el de la base de datos " + descargarInventario.tipoProveedor + " y " +inventarioaActualizar.TipoProveedor;
            }
        } else {

            valida = 2;
            respuesta.mensaje = "Prodcuto Externo " + retorno;
        }

        if (valida == 0) {

            System.out.println(" proveedor local ");

            retorno = entityManager.createQuery("UPDATE Inventario e SET e.Inventario = e.Inventario - :cantidad " +
                    "WHERE e.Id = :id")
                    .setParameter("cantidad", descargarInventario.CantidadOrdenada)
                    .setParameter("id", id)
                    .executeUpdate();
            //llamar Actualizar

            int intId = Integer.valueOf((int) id);
            Object inventarioProductoDto = new InventarioProductoDto();
            ((InventarioProductoDto) inventarioProductoDto).id = intId;
            ((InventarioProductoDto) inventarioProductoDto).inventario = 0;

            int inventarioActual = ActualizaInventarioProducto((InventarioProductoDto) inventarioProductoDto);

            if (retorno >= 1) {

                respuesta.codigo = 1;
                respuesta.mensaje = "Inventario Descargado y Stock de Producto Actualizado " + retorno;
            } else {

                respuesta.codigo = 0;
                respuesta.mensaje = "Producto no existe:" + descargarInventario + " " + retorno;
            }

        } else {
            if (valida == 2) {
                respuesta.codigo = 0;
                System.out.println("DEBE IR A PROVEEDOR");
            }
            /*
            retorno = entityManager.createQuery("UPDATE Inventario e SET e.Inventario = e.Inventario - :cantidad "
                    + "WHERE e.Codigo = :codigo")
                    .setParameter("cantidad", descargarInventario.CantidadOrdenada)
                    .setParameter("codigo", descargarInventario.codigo)
                    //          .setParameter("CodigoProveedor", request.codigoProveedor)
                    .executeUpdate();
            */

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