package co.com.aespica.repositorio;

import javax.persistence.*;

@Entity
@Table(name = "Transportador")
@NamedQueries({
        @NamedQuery(name = "Transportador.ObtenerTodos", query = "SELECT t FROM Transportador t"),
        @NamedQuery(name = "Transportador.ObtenerId", query = "SELECT t FROM Transportador t WHERE t.Id = :id "),
        @NamedQuery(name = "Transportador.ObtenerNombre", query = "SELECT t FROM Transportador t WHERE t.Nombre = :nombre "),
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

    @Column(name = "FactorFlete")
    public Double FactorFlete;

    public Transportador()
    {

    }

    public Transportador(String _Nombre, String _EMail, String _Direccion, String _Telefono, boolean _Estado, Double _FactorFlete)
    {
        Nombre    = _Nombre;
        EMail     = _EMail;
        Direccion = _Direccion;
        Telefono  = _Telefono;
        Estado    = _Estado;
        FactorFlete  = _FactorFlete;
    }

    public int getId() { return Id;}
    public String getNombre() { return Nombre;}
    public String getEMail() { return EMail;}
    public String getDireccion() { return Direccion;}
    public String getTelefono() { return Telefono;}
    public boolean getEstado() { return Estado;}    
    public Double getFactorFlete() { return FactorFlete;}

}
