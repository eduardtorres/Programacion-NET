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
            response.Cantidad = Cantidad;
            response.CarritoId = CarritoId;
            response.Categoria = Categoria;
            response.Codigo = Codigo;
            response.CodigoProveedor = CodigoProveedor;
            response.Descripcion = Descripcion;
            response.Fabricante = Fabricante;
            response.Id = Id;
            response.Moneda = Moneda;
            response.Nombre = Nombre;
            response.Precio = Precio;
            response.TipoProveedor = TipoProveedor;
            response.UniqueKey = UniqueKey;

            return response;
        }        

        public void LoadFromDto(ProductoDto productoDto)
        {
                Cantidad = productoDto.Cantidad;
                CarritoId = productoDto.CarritoId;
                Categoria = productoDto.Categoria;
                Codigo = productoDto.Codigo;
                CodigoProveedor = productoDto.CodigoProveedor;
                Descripcion = productoDto.Descripcion;
                Fabricante = productoDto.Fabricante;
                Id = productoDto.Id;
                Nombre = productoDto.Nombre;
                Precio = productoDto.Precio;
                Moneda = productoDto.Moneda;
                TipoProveedor = productoDto.TipoProveedor;  
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
