package co.com.aespica.Servicio;

import java.util.List;
import java.util.Calendar;
import java.util.Date;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import javax.transaction.Transactional;

import org.eclipse.microprofile.rest.client.inject.RestClient;

import co.com.aespica.repositorio.*;
import co.com.aespica.dominio.*;


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

    @Inject
    @RestClient
    ProveedorPagoService proveedorPagoService;
    @Transactional
    public int RealizarPago(PagoDTO pagoDto)
    {

        Pago pago = new Pago();
        pago.MedioPago = pagoDto.MedioPago;
        pago.Valor = pagoDto.Valor;

        pago.CodMoneda     = pagoDto.CodMoneda;
        pago.NumeroTarjeta = pagoDto.NumeroTarjeta;
        pago.MesExpiracion = Integer.toString(pagoDto.MesExpiracion);
        pago.AnoExpiracion = Integer.toString(pagoDto.AnoExpiracion);
        pago.CodCV         = pagoDto.CodCV;
        pago.TipoTarjeta   = pagoDto.TipoTarjeta;
        pago.NombreTitular = pagoDto.NombreTitular;
        pago.EMail         = pagoDto.EMail;
        
        Date date = Calendar.getInstance().getTime();
        pago.FechaPago = date;

        //Llamado a servicio de pago proveedor
        RespuestaProveedorPago respuestaProveedorPago= proveedorPagoService.ejecutarPagoProveedor(pagoDto);
        int resp=0;        
        // Responde 0 siempre que se envie 'MC' en TipoTarjeta, indicando que no es valido el pago.
        if (respuestaProveedorPago.codRespuesta==0){
            pago.IndEstadoPago = false;//En Proceso
            entityManager.persist(pago);
            resp=0;
        } else{
            pago.IndEstadoPago = true;//En Proceso
            entityManager.persist(pago);
            resp=pago.getId();
        }
        //se devuelve el id del pago cuando la respuesta del pago es 1.
        return resp;
        
    }
}