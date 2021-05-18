package carrito.pica.repositorios;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;

import carrito.pica.dominio.ProductoDto;

@Entity
@Table(name = "carrito_producto")
@NamedQueries({
        @NamedQuery(name = "Producto.ObtenerPorCarrito", query = "SELECT p FROM Producto p WHERE p.CarritoId = :CarritoId order by UniqueKey"),
        @NamedQuery(name = "Producto.ObtenerPorProducto", query = "SELECT p FROM Producto p WHERE p.CarritoId=:CarritoId and p.Codigo=:Codigo and p.CodigoProveedor=:CodigoProveedor")
})

public class Producto {   

        @Id
        @GeneratedValue(strategy= GenerationType.IDENTITY)
        @Column(name = "unique_key")
        public int UniqueKey;

        @Column(name = "id")
        public int Id;

        @Column(name = "producto_codigo")
        public String Codigo;

        @Column(name = "producto_fabricante")
        public String Fabricante;        

        @Column(name = "producto_tipo_proveedor")
        public String TipoProveedor;
        
        @Column(name = "producto_codigo_proveedor")
        public String CodigoProveedor;
        
        @Column(name = "producto_nombre")
        public String Nombre;
        
        @Column(name = "producto_descripcion")        
        public String Descripcion;        

        @Column(name = "producto_categoria")
        public String Categoria;        
        
        @Column(name = "precio")
        public double Precio;

        @Column(name = "moneda")
        public String Moneda;                

        @Column(name = "cantidad")
        public int Cantidad; 

        @Column(name = "carrito_id")
        public int CarritoId;

        public Producto()
        {

        }

        public ProductoDto ToDto()
        {
            ProductoDto response = new ProductoDto();
            response.cantidad = Cantidad;
            response.carritoId = CarritoId;
            response.categoria = Categoria;
            response.codigo = Codigo;
            response.codigoProveedor = CodigoProveedor;
            response.descripcion = Descripcion;
            response.fabricante = Fabricante;
            response.id = Id;
            response.moneda = Moneda;
            response.nombre = Nombre;
            response.precio = Precio;
            response.tipoProveedor = TipoProveedor;
            response.uniqueKey = UniqueKey;

            return response;
        }        

        public void LoadFromDto(ProductoDto productoDto)
        {
                Cantidad = productoDto.cantidad;
                CarritoId = productoDto.carritoId;
                Categoria = productoDto.categoria;
                Codigo = productoDto.codigo;
                CodigoProveedor = productoDto.codigoProveedor;
                Descripcion = productoDto.descripcion;
                Fabricante = productoDto.fabricante;
                Id = productoDto.id;
                Nombre = productoDto.nombre;
                Precio = productoDto.precio;
                Moneda = productoDto.moneda;
                TipoProveedor = productoDto.tipoProveedor;  
        }
        
        public static List<ProductoDto> ToListDto( List<Producto> originalList )
        {
                List<ProductoDto> newList = new ArrayList<ProductoDto>();
                for( Producto item : originalList )
                {
                        newList.add(item.ToDto());
                }
                return newList;
        }
}
