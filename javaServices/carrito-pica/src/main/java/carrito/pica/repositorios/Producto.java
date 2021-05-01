package carrito.pica.repositorios;

import javax.persistence.*;

@Entity
@Table(name = "carrito_producto")
@NamedQueries({
        @NamedQuery(name = "Producto.ObtenerPorCarrito", query = "SELECT p FROM Producto p WHERE p.CarritoId = :CarritoId order by UniqueKey")
})
public class Producto {   

        @Id
        @GeneratedValue(strategy= GenerationType.IDENTITY)
        @Column(name = "id")
        public int UniqueKey;

        @Column(name = "producto_id")
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
        
        @Column(name = "cantidad")
        public int Cantidad; 

        @Column(name = "carrito_id")
        public int CarritoId;

        public Producto()
        {

        }
        
}
