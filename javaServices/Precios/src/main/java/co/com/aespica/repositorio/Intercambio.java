package co.com.aespica.repositorio;

import javax.persistence.*;

@Entity
@Table(name = "Intercambio")
@NamedQueries({
        @NamedQuery(name = "Intercambio.findAll", query = "SELECT i FROM Intercambio i"),
        @NamedQuery(name = "Intercambio.obtenerTasaIntercambio", query = "SELECT i FROM Intercambio i WHERE i.CodMoneda = :CodMoneda")
})
public class Intercambio {
    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "Id")
    private int Id;

    @Column(name = "CodMoneda")
    private String CodMoneda;

    @Column(name = "DesMoneda")
    private String DesMoneda;

    @Column(name = "ValUSD")
    private double ValUSD;

    public Intercambio()
    {

    }

    public Intercambio(int _id, String _CodMoneda, String _DesMoneda, double _ValUSD) {
        Id = _id;
        CodMoneda = _CodMoneda;
        DesMoneda = _DesMoneda;
        ValUSD = _ValUSD;
    }

    public int getId()
    {
        return Id;
    }

    public String getCodMoneda()
    {
        return CodMoneda;
    }

    public String getDesMoneda()
    {
        return DesMoneda;
    }

    public double getValUSD()
    {
        return ValUSD;
    }
}
