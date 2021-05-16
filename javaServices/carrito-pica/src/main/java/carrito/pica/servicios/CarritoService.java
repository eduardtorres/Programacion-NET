package carrito.pica.servicios;

import org.eclipse.microprofile.config.inject.ConfigProperty;

import carrito.pica.repositorios.*;
import carrito.pica.dominio.*;

import javax.annotation.PostConstruct;
import javax.annotation.PreDestroy;
import javax.enterprise.context.Dependent;
import javax.inject.Inject;

import javax.persistence.EntityManager;
import javax.persistence.Persistence;
import javax.transaction.Transactional;

import com.amazonaws.services.lambda.runtime.events.CloudFrontEvent.Request;

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

    public Producto ProductoExisteEnCarrito(ProductoDto productoDto)
    {
        return entityManager
                .createNamedQuery("Producto.ObtenerPorProducto", Producto.class)
                .setParameter("CarritoId", productoDto.CarritoId)
                .setParameter("Codigo", productoDto.Codigo)
                .setParameter("CodigoProveedor", productoDto.CodigoProveedor)
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
        else
        {
            carritoEncontrado.productos = ObtenerProductos( carritoEncontrado.getId() );
        }
        return carritoEncontrado;
    }

    @Transactional
    public RespuestaBaseDto AgregarProducto(ProductoDto productoDto)
    {

        Producto productoEncontrado = ProductoExisteEnCarrito(productoDto);
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
            producto.Cantidad = productoDto.Cantidad;
            producto.CarritoId = productoDto.CarritoId;
            producto.Categoria = productoDto.Categoria;
            producto.Codigo = productoDto.Codigo;
            producto.CodigoProveedor = productoDto.CodigoProveedor;
            producto.Descripcion = productoDto.Descripcion;
            producto.Fabricante = productoDto.Fabricante;
            producto.Id = productoDto.Id;
            producto.Nombre = productoDto.Nombre;
            producto.Precio = productoDto.Precio;
            producto.Moneda = productoDto.Moneda;
            producto.TipoProveedor = productoDto.TipoProveedor;    
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
            .setParameter("CarritoId", request.CarritoId)
            .setParameter("Codigo", request.Codigo)
            .setParameter("CodigoProveedor", request.CodigoProveedor)
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
            respuesta.mensaje = "Producto no existe:" + request.Codigo ;    
        }

        return respuesta;
    }

    @Transactional
    public int LimpiarCarrito(int id) {
        entityManager.createQuery("delete from Producto where CarritoId = :CarritoId")
            .setParameter("CarritoId", id)
            .executeUpdate();
        int retorno = entityManager.createQuery("delete from Carrito where Id = :Id")
            .setParameter("Id", id)
            .executeUpdate();
        return retorno;
    }

}