package co.com.aespica.repositorio;

import javax.persistence.*;

@Entity
@Table(name = "Pais")
@NamedQueries({
        @NamedQuery(name = "Pais.Obtener", query = "SELECT p FROM Pais p WHERE p.IndEstado = :IndEstado")
})
public class Pais{
    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "Id")
    private int Id;

    @Column(name = "CodPais")
    private String CodPais;

    @Column(name = "DesPais")
    private String DesPais;

    @Column(name = "IndEstado")
    private boolean IndEstado;

    public Pais()
    {

    }

    public Pais(int _id, String _CodPais, String _DesPais, boolean _IndEstado) {
        Id = _id;
        CodPais = _CodPais;
        DesPais = _DesPais;
        IndEstado = _IndEstado;
    }

    public int getId(){ return Id; }
    public String getCodPais(){ return CodPais; }
    public String getDesPais(){ return DesPais; }
    public boolean getIndEstado(){ return IndEstado; }
}
