package inventario.pica.repositorios;

import javax.persistence.*;
import inventario.pica.dominio.InventarioDto;

import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "inventario")
@NamedQueries({
        @NamedQuery(name = "inventario.findAll", query = "SELECT c FROM inventario c"),
        @NamedQuery(name = "inventario.obtenerPorcodigo", query = "SELECT c FROM inventario c WHERE c.codigo = :codigo and c.tipoproveedor = :tipoproveedor order by Id desc"),
        @NamedQuery(name = "inventario.ObtenerPorid", query = "SELECT p FROM inventario p WHERE p.Id = :ID order by UniqueKey")


})
public class Inventario {


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "unique_key")
    public long Id;
    @Column(name = "codigo", nullable = false)
    public String Codigo;
    @Column(name = "codigoProveedor", nullable = false)
    public String CodigoProveedor;
    @Column(name = "descripcion", nullable = false)
    public String Descripcion;
    @Column(name = "disponibilidad", nullable = false)
    public String Disponibilidad;
    @Column(name = "fabricante", nullable = false)
    public String Fabricante;
    @Column(name = "moneda", nullable = false)
    public String Moneda;
    @Column(name = "nombre", nullable = false)
    public String Nombre;
    @Column(name = "precio", nullable = false)
    public Double Precio;
    @Column(name = "inventario", nullable = false)
    public int Inventario;

    @Column(name = "categoria", nullable = false)
    public String Categoria;

    @Column(name = "urlImagen", nullable = false)
    public String UrlImagen;

    @Column(name = "nombreImagen", nullable = false)
    public String NombreImagen;
    @Column(name = "tipoProveedor", nullable = false)
    public String TipoProveedor;
    //OVERRRIDE

    @Override
    public String toString() {
        return "Inventario{" +
                "id=" + Id +
                ", codigo='" + Codigo + '\'' +
                ", codigoProveedor='" + CodigoProveedor + '\'' +
                ", descripcion='" + Descripcion + '\'' +
                ", disponibilidad='" + Disponibilidad + '\'' +
                ", fabricante='" + Fabricante + '\'' +
                ", moneda='" + Moneda + '\'' +
                ", nombre='" + Nombre + '\'' +
                ", precio=" + Precio +
                ", inventario=" + Inventario +
                ", categoria='" + Categoria + '\'' +
                ", urlImagen='" + UrlImagen + '\'' +
                ", nombreImagen='" + NombreImagen + '\'' +
                ", tipoProveedor='" + TipoProveedor + '\'' +
                '}';
    }

    //OVERRRIDE


    //Constructor

    public InventarioDto ToDto()
    {
        InventarioDto response = new InventarioDto();
        response.id = id;
        response.codigo = codigo;
        response.codigoProveedor = codigoProveedor;
        response.descripcion = descripcion;
        response.disponibilidad = disponibilidad;
        response.fabricante = fabricante;
        response.moneda = moneda;
        response.nombre = nombre;
        response.precio = precio;
        response.inventario = Inventario;
        response.categoria = categoria;
        response.urlImagen = urlImagen;
        response.nombreImagen = nombreImagen;
        response.tipoProveedor = tipoProveedor;

        return response;
    }

    public void LoadFromDto(InventarioDto inventarioDto)
    {
        Id = inventarioDto.id;
        Codigo = inventarioDto.codigo;
        CodigoProveedor = inventarioDto.codigoProveedor;
        Descripcion = inventarioDto.descripcion;
        Disponibilidad = inventarioDto.disponibilidad;
        Fabricante = inventarioDto.fabricante;
        Moneda = inventarioDto.moneda;
        Nombre = inventarioDto.nombre;
        Precio = inventarioDto.precio;
        Inventario = inventarioDto.inventario;
        Categoria = inventarioDto.categoria;
        UrlImagen = inventarioDto.urlImagen;
        NombreImagen = inventarioDto.nombreImagen;
        TipoProveedor = inventarioDto.tipoProveedor;

    }

    public static List<InventarioDto> ToListDto(List<Inventario> originalList )
    {
        List<InventarioDto> newList = new ArrayList<InventarioDto>();
        for( Inventario item : originalList )
        {
            newList.add(item.ToDto());
        }
        return newList;
    }


}