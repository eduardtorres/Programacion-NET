package co.com.aespica.repositorio;

import javax.persistence.*;

@Entity
@Table(name = "CodigoDane")
@NamedQueries({
        @NamedQuery(name = "CodigoDane.ObtenerTodos", query = "SELECT t FROM CodigoDane t"),
        @NamedQuery(name = "CodigoDane.ObtenerxCodigoDane", query = "SELECT t FROM CodigoDane t WHERE t.idCodDane = :idcoddane"),
        @NamedQuery(name = "CodigoDane.ObtenerxMunicipio", query = "SELECT t FROM CodigoDane t WHERE t.municipioDepartameto LIKE :cadena")
})
public class CodigoDane {
    @Id
   // @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "idCodDane")
    public String idCodDane;

    @Column(name = "municipioDepartameto")
    public String municipioDepartameto;

    public CodigoDane()
    {

    }

    public CodigoDane(String _idCodDane, String _municipioDepartameto)
    {
        idCodDane    = _idCodDane;
        municipioDepartameto     = _municipioDepartameto;
            }

    public String getidCodDane() { return idCodDane;}
    public String getmunicipioDepartameto() { return municipioDepartameto;}
}
