package co.com.aespica.repositorio;

import java.util.Date;
import javax.persistence.*;

@Entity
@Table(name = "Pago")
@NamedQueries({
        @NamedQuery(name = "Pago.obtenerPagoXIdPago", query = "SELECT i FROM Pago i WHERE i.Id = :Id")
})
public class Pago {
    @Id
    @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "Id")
    public int Id;

    @Column(name = "MedioPago")
    public int MedioPago;

    @Column(name = "Valor")
    public double Valor;

    @Column(name = "CodMoneda")
    public String CodMoneda;
    
    @Column(name = "NumeroTarjeta")
    public String NumeroTarjeta;
    
    @Column(name = "MesExpiracion")
    public String MesExpiracion;

    @Column(name = "AnoExpiracion")
    public String AnoExpiracion;

    @Column(name = "CodCV")
    public String CodCV;

    @Column(name = "TipoTarjeta")
    public String TipoTarjeta;

    @Column(name = "NombreTitular")
    public String NombreTitular;
      
    @Column(name = "EMail")
    public String EMail;
    
    @Column(name = "FechaPago")
    public Date FechaPago;

    @Column(name = "IndEstadoPago")
    public boolean IndEstadoPago;

    public Pago()
    {

    }

    public Pago(int _MedioPago, double _Valor, String _CodMoneda, String _NumeroTarjeta, 
                String _MesExpiracion, String _AnoExpiracion, String _CodCV, String _TipoTarjeta, 
                String _NombreTitular, String _EMail, Date _FechaPago, boolean _IndEstadoPago) 
    {
        MedioPago     = _MedioPago;
        Valor         = _Valor;
        CodMoneda     = _CodMoneda;
        NumeroTarjeta = _NumeroTarjeta;
        MesExpiracion = _MesExpiracion;
        AnoExpiracion = _AnoExpiracion;
        CodCV         = _CodCV;        
        TipoTarjeta   = _TipoTarjeta;
        NombreTitular = _NombreTitular;
        EMail         = _EMail;
        FechaPago     = _FechaPago;
        IndEstadoPago = _IndEstadoPago;
        FechaPago     = _FechaPago;
        IndEstadoPago = _IndEstadoPago;
    }

    public int getId() { return Id; }
    public int getMedioPago() { return MedioPago; }
    public double getValor() { return Valor; }
	public String getCodMoneda() { return CodMoneda;}
	public String getNumeroTarjeta() { return NumeroTarjeta;}
	public String getMesExpiracion() { return MesExpiracion;}
	public String getAnoExpiracion() { return AnoExpiracion;}
	public String getCodCV() { return CodCV;}
	public String getTipoTarjeta() { return TipoTarjeta;}
	public String getNombreTitular() { return NombreTitular;}
	public String getEMail() { return EMail;}
	public Date getFechaPago() { return FechaPago; }
    public boolean getIndEstadoPago() { return IndEstadoPago; }

}
