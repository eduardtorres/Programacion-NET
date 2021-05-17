package carrito.pica.repositorios;
import java.util.List;

import javax.persistence.*;

import carrito.pica.dominio.ProductoDto;

@Entity
@Table(name = "carrito")
@NamedQueries({
        @NamedQuery(name = "Carrito.findAll", query = "SELECT c FROM Carrito c"),
        @NamedQuery(name = "Carrito.obtenerPorUsuarioPais", query = "SELECT c FROM Carrito c WHERE c.Usuario = :Usuario and c.Pais = :Pais order by Id desc")
})
public class Carrito {

    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "id")
    private int Id;

    @Column(name = "fecha")
    private String Fecha;

    @Column(name = "usuario")
    private String Usuario;

    @Column(name = "pais")
    private String Pais;

    @Transient
    public List< ProductoDto > productos;

    public Carrito()
    {

    }

    public Carrito(int _id, String _fecha, String _usuario, String _pais) {
        Id = _id;
        Fecha = _fecha;
        Usuario = _usuario;
        Pais = _pais;
    }

    public int getId()
    {
        return Id;
    }

    public String getFecha()
    {
        return Fecha;
    }

    public String getUsuario()
    {
        return Usuario;
    }

    public String getPais()
    {
        return Pais;
    }

}