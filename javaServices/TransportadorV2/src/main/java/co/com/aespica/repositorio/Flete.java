package co.com.aespica.repositorio;

import javax.persistence.*;

@Entity
@Table(name = "Flete")
@NamedQueries({
        @NamedQuery(name = "Flete.ObtenerTodos", query = "SELECT t FROM Flete t WHERE t.EstadoFlete = 1"),
        @NamedQuery(name = "Flete.ObtenerxDepartamento", query = "SELECT t FROM Flete t WHERE t.IdDaneDepartamento = :iddanedepartamento")
})
public class Flete {
    @Id
    // @GeneratedValue(strategy= GenerationType.IDENTITY)
    @Column(name = "IdDaneDepartamento")
    public String IdDaneDepartamento;

    @Column(name = "FactorOrigen")
    public Double FactorOrigen;

    @Column(name = "FactorDestino")
    public Double FactorDestino;

    @Column(name = "FactorSocial")
    public Double FactorSocial;
    @Column(name = "FactorTipoCarga")
    public Double FactorTipoCarga;
    @Column(name = "FactorTipoTransporte")
    public Double FactorTipoTransporte;
    @Column(name = "FactorInternacional")
    public Double FactorInternacional;
    @Column(name = "FactorValorCarga")
    public Double FactorValorCarga;
    @Column(name = "EstadoFlete")
    public Boolean EstadoFlete;

    public Flete() {

    }

    public Flete(String _IdDaneDepartamento,
                 Double _FactorOrigen,
                 Double _FactorDestino,
                 Double _FactorSocial,
                 Double _FactorTipoCarga,
                 Double _FactorTipoTransporte,
                 Double _FactorInternacional,
                 Double _FactorValorCarga,
                 Boolean _EstadoFlete) {
        IdDaneDepartamento = _IdDaneDepartamento;
        FactorOrigen = _FactorOrigen;
        FactorDestino = _FactorDestino;
        FactorSocial = _FactorSocial;
        FactorTipoCarga = _FactorTipoCarga;
        FactorTipoTransporte = _FactorTipoTransporte;
        FactorInternacional = _FactorInternacional;
        FactorValorCarga = _FactorValorCarga;
        EstadoFlete = _EstadoFlete;
    }

    public String getIdDaneDepartamento() {
        return IdDaneDepartamento;
    }

    public Double getFactorOrigen() {
        return FactorOrigen;
    }

    public Double getFactorDestino() {
        return FactorDestino;
    }

    public Double getFactorSocial() {
        return FactorSocial;
    }

    public Double getFactorTipoCarga() {
        return FactorTipoCarga;
    }

    public Double getFactorTipoTransporte() {
        return FactorTipoTransporte;
    }

    public Double getFactorInternacional() {
        return FactorInternacional;
    }

    public Double getFactorValorCarga() {
        return FactorValorCarga;
    }

    public Boolean getEstadoFlete() {
        return EstadoFlete;
    }

}
