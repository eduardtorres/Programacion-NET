package carrito.pica;
import javax.persistence.*;

@Entity
@Table(name = "carrito" , schema = "carrito" )
@NamedQueries({
        @NamedQuery(name = "Carrito.findAll", query = "SELECT c FROM Carrito c"),
        @NamedQuery(name = "Carrito.findById", query = "SELECT c FROM Carrito c WHERE c.id = :id")
})
public class Carrito {

    @Id
    @Column(name = "id")
    private int Id;

    @Column(name = "fecha")
    private String Fecha;

    @Column(name = "usuario")
    private String Usuario;

    public Carrito()
    {

    }

    public Carrito(int _id, String _fecha, String _usuario) {
        Id = _id;
        Fecha = _fecha;
        Usuario = _usuario;
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
}