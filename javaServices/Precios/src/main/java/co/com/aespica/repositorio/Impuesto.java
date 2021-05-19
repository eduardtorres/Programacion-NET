package co.com.aespica.repositorio;

import javax.persistence.*;

@Entity
@Table(name = "Impuesto")
@NamedQueries({
        @NamedQuery(name = "Impuesto.findAll", query = "SELECT i FROM Impuesto i"),
        @NamedQuery(name = "Impuesto.obtenerImpuesto", query = "SELECT i FROM Impuesto i WHERE i.CodPais = :CodPais")
})
public class Impuesto{
    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "Id")
    private int Id;

    @Column(name = "DesImpuesto")
    private String DesImpuesto;

    @Column(name = "CodPais")
    private String CodPais;

    @Column(name = "Valor")
    private double Valor;

    public Impuesto()
    {

    }

    public Impuesto(int _id, String _DesImpuesto, String _CodPais, double _Valor) {
        Id = _id;
        DesImpuesto = _DesImpuesto;
        CodPais = _CodPais;
        Valor = _Valor;
    }

    public int getId()
    {
        return Id;
    }

    public String getDesImpuesto()
    {
        return DesImpuesto;
    }

    public String getCodPais()
    {
        return CodPais;
    }

    public double getValor()
    {
        return Valor;
    }
}
