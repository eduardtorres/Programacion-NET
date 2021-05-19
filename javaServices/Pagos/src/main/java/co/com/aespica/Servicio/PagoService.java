package co.com.aespica.Servicio;

import java.util.List;
import java.util.Calendar;
import java.util.Date;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import javax.transaction.Transactional;

import co.com.aespica.repositorio.Pago;
import co.com.aespica.repositorio.MediosPago;
import co.com.aespica.dominio.PagoDTO;


@Dependent
@Transactional(Transactional.TxType.SUPPORTS)
public class PagoService {

    @Inject
    EntityManager entityManager;

    public List<MediosPago> ObtenerListaMediosPago() {
        return entityManager
                .createNamedQuery("MediosPago.obtenerListaPago", MediosPago.class)
                .getResultList();
    }

    public MediosPago ObtenerMedioPago(int Id) {
        return entityManager
                .createNamedQuery("MediosPago.obtenerMedioPago", MediosPago.class)
                .setParameter("Id", Id)
                .getSingleResult();
    }

    public Pago ObtenerPagoXIdPago(int Id) {
        return entityManager
                .createNamedQuery("Pago.obtenerPagoXIdPago", Pago.class)
                .setParameter("Id", Id)
                .getSingleResult();
    }

    @Transactional
    public int RealizarPago(PagoDTO pagoDto)
    {
        Pago pago = new Pago();
        pago.MedioPago = pagoDto.MedioPago;
        pago.Valor = pagoDto.Valor;

        pago.CodMoneda     = pagoDto.CodMoneda;
        pago.NumeroTarjeta = pagoDto.NumeroTarjeta;
        pago.MesExpiracion = pagoDto.MesExpiracion;
        pago.AnoExpiracion = pagoDto.AnoExpiracion;
        pago.CodCV         = pagoDto.CodCV;
        pago.TipoTarjeta   = pagoDto.TipoTarjeta;
        pago.NombreTitular = pagoDto.NombreTitular;
        pago.EMail         = pagoDto.EMail;
        
        Date date = Calendar.getInstance().getTime();
        pago.FechaPago = date;
        pago.IndEstadoPago = false;//En Proceso
        entityManager.persist(pago);
        return pago.getId();
    }
}