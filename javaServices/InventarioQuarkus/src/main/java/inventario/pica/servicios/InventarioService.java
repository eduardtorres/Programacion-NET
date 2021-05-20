package inventario.pica.servicios;

import inventario.pica.repositorios.*;
import inventario.pica.dominio.*;

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
public class InventarioService
{

    @Inject
    EntityManager entityManager;

    public List<Inventario> fetchAll() {
        return entityManager
                .createNamedQuery("Inventario.findAll", Inventario.class)
                .getResultList();
    }

    public Inventario ObtenerPorCodigoTipoPro String codigo , String tipoproveedor ) {
        return entityManager
                .createNamedQuery("Inventario.obtenerPorcodigo", Inventario.class)
                .setParameter("codigo", codigo)
                .setParameter("tipoproveedor", tipoproveedor)
                .getResultStream()
                .findFirst()
                .orElse(null);
    }

    public List<Producto> ObtenerProductos(int id)
    {
        return entityManager
                .createNamedQuery("Producto.ObtenerPorinventario", Producto.class)
                .setParameter("inventarioId", id)
                .getResultList();     
    }

    public List<Inventario> ObtenerInventario(int id)
    {        
        return Inventario.ToListDto( ObtenerInventario(id) );
    }


    public Producto InventarioExiste(Inventario inventario)
    {
        return entityManager
                .createNamedQuery("inventario.ObtenerPorid", Producto.class)
                .setParameter("Id", inventario.Id)
                .getResultStream()
                .findFirst()
                .orElse(null);  
    }


    @Transactional
    public Inventario Obtener(String codigo, String codigoProveedor, String descripcion, String disponibilidad, String fabricante, String moneda, String nombre, Double precio, int inventario, String categoria, String urlImagen, String nombreImagen, String tipoProveedor) {
        Inventario inventarioEncontrado = ObtenerPorUsuarioPais(codigo,tipoProveedor);
        if( inventarioEncontrado == null )
        {
            Date date = Calendar.getInstance().getTime();
            DateFormat dateFormat = new SimpleDateFormat("yyyy-mm-dd hh:mm:ss");
            String strDate = dateFormat.format(date);
            inventarioEncontrado = new Inventario(0,codigo,codigoProveedor,  descripcion,  disponibilidad,  fabricante,  moneda,  nombre, Double precio,  inventario,  categoria,  urlImagen,  nombreImagen,  tipoProveedor);
            entityManager.persist(inventarioEncontrado);
        }
        return inventarioEncontrado;
    }

    @Transactional
    public RespuestaBaseDto AgregarProducto(ProductoDto productoDto)
    {

        Producto productoEncontrado = ProductoExiste(productoDto);
        RespuestaBaseDto respuesta;
        if( productoEncontrado != null )
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 0;
            respuesta.mensaje = "El producto ya existe en el inventario";
        }
        else
        {
            Producto producto = new Producto();
            producto.LoadFromDto(productoDto);            
            entityManager.persist(producto);
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 100;
            respuesta.mensaje = "Producto agregado satisfactoriamente";
        }
        return respuesta;
    }

    @Transactional
    public RespuestaBaseDto QuitarProducto( ProductoDto request ) {        

        int retorno = entityManager.createQuery("delete from Producto where inventarioId = :inventarioId and Codigo = :Codigo and CodigoProveedor = :CodigoProveedor")
            .setParameter("inventarioId", request.inventarioId)
            .setParameter("Codigo", request.codigo)
            .setParameter("CodigoProveedor", request.codigoProveedor)
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
        entityManager.createQuery("delete from Producto where inventarioId = :inventarioId")
            .setParameter("inventarioId", id)
            .executeUpdate();
        int retorno = entityManager.createQuery("delete from inventario where Id = :Id")
            .setParameter("Id", id)
            .executeUpdate();
        return retorno;
    }

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

}