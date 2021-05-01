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

    public List<Producto> ObtenerProductosPorCarrito(int id)
    {
        return entityManager
                .createNamedQuery("Producto.ObtenerPorCarrito", Producto.class)
                .setParameter("CarritoId", id)
                .getResultList();     
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
            carritoEncontrado.productos = ObtenerProductosPorCarrito( carritoEncontrado.getId() );
        }
        return carritoEncontrado;
    }

    @Transactional
    public int AgregarProducto(ProductoDto productoDto)
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
        producto.TipoProveedor = productoDto.TipoProveedor;

        entityManager.persist(producto);
        return producto.UniqueKey;

    }

    @Transactional
    public int QuitarProducto( int UniqueKey )
    {        
        Producto producto = entityManager.find( Producto.class , UniqueKey);
        if( producto != null )
        {
            entityManager.remove(producto);
            entityManager.flush();
            entityManager.clear();
            return 1;
        } 
        else
        {
            return 0;
        }
    }

    @Transactional
    public int LimpiarCarrito(int id) {
        entityManager.createQuery("delete from Producto where CarritoId = :id")
            .setParameter("id", id)
            .executeUpdate();
        int retorno = entityManager.createQuery("delete from Carrito where Id = :id")
            .setParameter("id", id)
            .executeUpdate();
        return retorno;
    }

}