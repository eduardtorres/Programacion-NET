package inventario.pica.repositorios;

import javax.persistence.*;
import inventario.pica.dominio.InventarioDto;

import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "Inventario")
@NamedQueries({
        @NamedQuery(name = "Inventario.findAll", query = "SELECT i FROM Inventario i"),
        @NamedQuery(name = "Inventario.ObtenerPorCodigoTipoPro", query = "SELECT i FROM Inventario i WHERE i.Codigo = :codigo and i.TipoProveedor = :tipoproveedor order by Id desc"),
        @NamedQuery(name = "Inventario.ObtenerPorid", query = "SELECT p FROM Inventario p WHERE p.Id = :Id"),
        @NamedQuery(name = "Inventario.ObtenerPorCodigo", query = "SELECT p FROM Inventario p WHERE p.Codigo = :Codigo")

})
public class Inventario {


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "Id")
    public long Id;
    @Column(name = "Categoria", nullable = false)
    public String Categoria;
    @Column(name = "Codigo", nullable = false)
    public String Codigo;
    @Column(name = "CodigoProveedor", nullable = false)
    public String CodigoProveedor;
    @Column(name = "Descripcion", nullable = false)
    public String Descripcion;
    @Column(name = "Disponibilidad", nullable = false)
    public String Disponibilidad;
    @Column(name = "Fabricante", nullable = false)
    public String Fabricante;
    @Column(name = "Inventario", nullable = false)
    public int Inventario;
    @Column(name = "Moneda", nullable = false)
    public String Moneda;
    @Column(name = "Nombre", nullable = false)
    public String Nombre;
    @Column(name = "NombreImagen", nullable = false)
    public String NombreImagen;
    @Column(name = "Precio", nullable = false)
    public Double Precio;
    @Column(name = "TipoProveedor", nullable = false)
    public String TipoProveedor;
    @Column(name = "UrlImagen", nullable = false)
    public String UrlImagen;


    public Inventario()
    {

    }

    public Inventario(long _Id, String _Categoria, String _Codigo, String _CodigoProveedor,
                      String _Descripcion, String _Disponibilidad, String _Fabricante,
                      int _Inventario, String _Moneda, String _Nombre, String _NombreImagen,
                      Double _Precio, String _TipoProveedor, String _UrlImagen)
    {
        Id              = _Id;
        Categoria       = _Categoria;
        Codigo          = _Codigo;
        CodigoProveedor = _CodigoProveedor;
        Descripcion     = _Descripcion;
        Disponibilidad  = _Disponibilidad;
        Fabricante      = _Fabricante;
        Inventario      = _Inventario;
        Moneda          = _Moneda;
        Nombre          = _Nombre;
        NombreImagen    = _NombreImagen;
        Precio          = _Precio;
        TipoProveedor   = _TipoProveedor;
        UrlImagen       = _UrlImagen;
    }

    public long   getId() { return Id; }
    public String getCategoria() { return Categoria; }
    public String getCodigo() { return Codigo; }
    public String getCodigoProveedor() { return CodigoProveedor; }
    public String getDescripcion() { return Descripcion; }
    public String getDisponibilidad() { return Disponibilidad; }
    public String getFabricante() { return Fabricante; }
    public int    getInventario() { return Inventario; }
    public String getMoneda() { return Moneda; }
    public String getNombre() { return Nombre; }
    public String getNombreImagen() { return NombreImagen; }
    public Double getPrecio() { return Precio; }
    public String getTipoProveedor() { return TipoProveedor; }
    public String getUrlImagen() { return UrlImagen; }

    public void LoadFromDto(InventarioDto inventarioDto)
    {
        Id              = inventarioDto.id             ;
        Categoria       = inventarioDto.categoria      ;
        Codigo          = inventarioDto.codigo         ;
        CodigoProveedor = inventarioDto.codigoProveedor;
        Descripcion     = inventarioDto.descripcion    ;
        Disponibilidad  = inventarioDto.disponibilidad ;
        Fabricante      = inventarioDto.fabricante     ;
        Inventario      = inventarioDto.inventario     ;
        Moneda          = inventarioDto.moneda         ;
        Nombre          = inventarioDto.nombre         ;
        NombreImagen    = inventarioDto.nombreImagen   ;
        Precio          = inventarioDto.precio         ;
        TipoProveedor   = inventarioDto.tipoProveedor  ;
        UrlImagen       = inventarioDto.urlImagen      ;

    }
    public InventarioDto ToDto()
    {
        InventarioDto response = new InventarioDto();

        response.id              = Id;
        response.categoria       = Categoria;
        response.codigo          = Codigo;
        response.codigoProveedor = CodigoProveedor;
        response.descripcion     = Descripcion;
        response.disponibilidad  = Disponibilidad;
        response.fabricante      = Fabricante;
        response.inventario      = Inventario;
        response.moneda          = Moneda;
        response.nombre          = Nombre;
        response.nombreImagen    = NombreImagen;
        response.precio          = Precio;
        response.tipoProveedor   = TipoProveedor;
        response.urlImagen       = UrlImagen;

        return response;
    }

    public static List<InventarioDto> ToListDto( List<Inventario> originalList )
    {
        List<InventarioDto> newList = new ArrayList<InventarioDto>();
        for( Inventario item : originalList )
        {
            newList.add(item.ToDto());
        }
        return newList;
    }
}
