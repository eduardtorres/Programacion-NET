package co.com.aespica.repositorio;

import javax.persistence.*;

@Entity
@Table(name = "Transportador")
@NamedQueries({
        @NamedQuery(name = "Transportador.ObtenerTodos", query = "SELECT t FROM Transportador t")
})
public class Transportador {
    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "Id")
    public int Id;

    @Column(name = "Nombre")
    public String Nombre;
    
    @Column(name = "EMail")
    public String EMail;

    @Column(name = "Direccion")
    public String Direccion;
    
    @Column(name = "Telefono")
    public String Telefono;
    
    @Column(name = "Estado")
    public boolean Estado;

    public Transportador()
    {

    }

    public Transportador(String _Nombre, String _EMail, String _Direccion, String _Telefono, boolean _Estado) 
    {
        Nombre    = _Nombre;
        EMail     = _EMail;
        Direccion = _Direccion;
        Telefono  = _Telefono;
        Estado    = _Estado;
    }

    public int getId() { return Id;}
    public String getNombre() { return Nombre;}
    public String getEMail() { return EMail;}
    public String getDireccion() { return Direccion;}
    public String getTelefono() { return Telefono;}
    public boolean getEstado() { return Estado;}    

}
