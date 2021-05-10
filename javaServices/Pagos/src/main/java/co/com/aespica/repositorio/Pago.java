package co.com.aespica.repositorio;

import javax.persistence.*;

@Entity
@Table(name = "Pago")
@NamedQueries({
        @NamedQuery(name = "Pago.obtenerPagoXID", query = "SELECT i FROM Pago i"),
        @NamedQuery(name = "Pago.obtenerPagoXCodCarrito", query = "SELECT i FROM Pago i WHERE i.CodCarrito = :CodCarrito")
})
public class Pago {
    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "Id")
    private int Id;

    @Column(name = "CodCarrito")
    private int CodCarrito;

    @Column(name = "Valor")
    private double Valor;

    @Column(name = "FechaPago")
    private Date FechaPago;

    @Column(name = "IndEstadoPago")
    private bool IndEstadoPago;

    public Pago()
    {

    }

    public Pago(int _id, String _CodMoneda, String _DesMoneda, double _ValUSD, double _ValUSD) {
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
        return CodCarrito;
    }

    public String getDesMoneda()
    {
        return Valor;
    }

    public double getValUSD()
    {
        return ValUSD;
    }
}
