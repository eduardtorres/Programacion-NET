package co.com.aespica.repositorio;

import org.hibernate.type.BooleanType;

import javax.persistence.*;

@Entity
@Table(name = "MediosPago")
@NamedQueries({
        @NamedQuery(name = "MediosPago.findAll", query = "SELECT i FROM MediosPago i"),
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
    private bool IndEstadoMedioPago;

    public MediosPago()
    {

    }

    public MediosPago(int _id, String _DesMedioPago, String _IndEstadoMedioPago) {
        Id = _id;
        DesImpuesto = _DesMedioPago;
        CodPais = _IndEstadoMedioPago;
    }

    public int getId()
    {
        return Id;
    }
    public String getDesMedioPago()
    {
        return DesMedioPago;
    }
    public bool getIndEstadoMedioPago() { return IndEstadoMedioPago; }

}
