package co.com.aespica.repositorio;

import javax.persistence.*;

@Entity
@Table(name = "MediosPago")
@NamedQueries({
        @NamedQuery(name = "MediosPago.obtenerListaPago", query = "SELECT i FROM MediosPago i"),
        @NamedQuery(name = "MediosPago.obtenerMedioPago", query = "SELECT i FROM MediosPago i WHERE i.Id = :Id")
})
public class MediosPago {
    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "Id")
    private int Id;

    @Column(name = "DesMedioPago")
    private String DesMedioPago;

    @Column(name = "IndEstadoMedioPago")
    private boolean IndEstadoMedioPago;

    public MediosPago()
    {

    }

    public MediosPago(int _id, String _DesMedioPago, boolean _IndEstadoMedioPago) {
        Id = _id;
        DesMedioPago = _DesMedioPago;
        IndEstadoMedioPago = _IndEstadoMedioPago;
    }

    public int getId()
    {
        return Id;
    }
    public String getDesMedioPago()
    {
        return DesMedioPago;
    }
    public boolean getIndEstadoMedioPago() { return IndEstadoMedioPago; }

}
