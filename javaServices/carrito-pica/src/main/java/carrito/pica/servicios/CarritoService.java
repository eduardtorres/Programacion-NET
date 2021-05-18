package carrito.pica.servicios;

import carrito.pica.repositorios.*;
import carrito.pica.dominio.*;

import javax.annotation.PostConstruct;
import javax.annotation.PreDestroy;
import javax.enterprise.context.Dependent;
import javax.inject.Inject;

import javax.persistence.EntityManager;
import javax.persistence.Persistence;
import javax.transaction.Transactional;

import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.Optional;
import java.util.concurrent.TimeUnit;
import java.util.logging.Logger;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;

@Dependent
@Transactional(Transactional.TxType.SUPPORTS)
public class CarritoService
{

    @Inject
    EntityManager entityManager;

    public List<Carrito> fetchAll() {
        return entityManager
                .createNamedQuery("Carrito.findAll", Carrito.class)
                .getResultList();
    }

    public Carrito ObtenerPorUsuarioPais( String usuario , String pais ) {
        return entityManager
                .createNamedQuery("Carrito.obtenerPorUsuarioPais", Carrito.class)
                .setParameter("Usuario", usuario)
                .setParameter("Pais", pais)
                .getResultStream()
                .findFirst()
                .orElse(null);
    }

    public List<Producto> ObtenerProductos(int id)
    {
        return entityManager
                .createNamedQuery("Producto.ObtenerPorCarrito", Producto.class)
                .setParameter("CarritoId", id)
                .getResultList();     
    }

    public List<ProductoDto> ObtenerProductosDto(int id)
    {        
        return Producto.ToListDto( ObtenerProductos(id) );
    }


    public Producto ProductoExiste(ProductoDto productoDto)
    {
        return entityManager
                .createNamedQuery("Producto.ObtenerPorProducto", Producto.class)
                .setParameter("CarritoId", productoDto.carritoId)
                .setParameter("Codigo", productoDto.codigo)
                .setParameter("CodigoProveedor", productoDto.codigoProveedor)
                .getResultStream()
                .findFirst()
                .orElse(null);  
    }


    @Transactional
    public Carrito Obtener(String usuario , String pais) {
        Carrito carritoEncontrado = ObtenerPorUsuarioPais(usuario,pais);
        if( carritoEncontrado == null )
        {
            Date date = Calendar.getInstance().getTime();
            DateFormat dateFormat = new SimpleDateFormat("yyyy-mm-dd hh:mm:ss");
            String strDate = dateFormat.format(date);
            carritoEncontrado = new Carrito(0,strDate,usuario,pais);
            entityManager.persist(carritoEncontrado);
        }
        return carritoEncontrado;
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
            respuesta.mensaje = "El producto ya existe en el carrito";
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

        int retorno = entityManager.createQuery("delete from Producto where CarritoId = :CarritoId and Codigo = :Codigo and CodigoProveedor = :CodigoProveedor")
            .setParameter("CarritoId", request.carritoId)
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
        entityManager.createQuery("delete from Producto where CarritoId = :CarritoId")
            .setParameter("CarritoId", id)
            .executeUpdate();
        int retorno = entityManager.createQuery("delete from Carrito where Id = :Id")
            .setParameter("Id", id)
            .executeUpdate();
        return retorno;
    }

    public CotizacionDto CotizarOrden(CotizacionRequest request)
    {
        List<Producto> productos = ObtenerProductos( request.carritoId );
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
        List<ProductoDto> productos = ObtenerProductosDto( id );
        for( ProductoDto item : productos )
        {
            if( item.id == 10 )
                item.disponibilidad = "NODISPONIBLE";
            else
                item.disponibilidad = "DISPONIBLE";
        }
        return productos;
    }

}