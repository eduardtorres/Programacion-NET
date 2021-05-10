package co.com.aespica.Servicio;

import java.util.List;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import javax.transaction.Transactional;


import co.com.aespica.repositorio.Pago;
import co.com.aespica.repositorio.MediosPago;


@Dependent
@Transactional(Transactional.TxType.SUPPORTS)
public class IntercambioService {

    @Inject
    EntityManager entityManager;

    public List<Pago> fetchAll() {
        return entityManager
                .createNamedQuery("Intercambio.findAll", Pago.class)
                .getResultList();
    }

    public Pago getById(String CodMoneda) {
        return entityManager
                .createNamedQuery("Intercambio.obtenerTasaIntercambio", Pago.class)
                .setParameter("CodMoneda", CodMoneda)
                .getSingleResult();
    }

    public List<MediosPago> getByIdImpuesto(String CodPais) {
        return entityManager
                .createNamedQuery("Impuesto.obtenerImpuesto", MediosPago.class)
                .setParameter("CodPais", CodPais)
                .getResultList();
    }

    public double getByIdImpuestoTotal(String CodPais) {
        
        List<MediosPago> Impuestos= entityManager
        .createNamedQuery("Impuesto.obtenerImpuesto", MediosPago.class)
        .setParameter("CodPais", CodPais)
        .getResultList();

        int sumaTotal=0;
        for (int i=0; i <=Impuestos.size()-1;i++){
            MediosPago mediosPagoTemp = Impuestos.get(i);
            sumaTotal+= mediosPagoTemp.getValor();
        }
        return sumaTotal;
    }
    
    //No se usa
    @Transactional
    public int eliminarTasaIntercambio(int id) {
        entityManager.createQuery("DELETE FROM Intercambio WHERE Id = :id")
            .setParameter("id", id)
            .executeUpdate();
        int retorno = entityManager.createQuery("DELETE FROM Intercambio WHERE CarritoId = :id")
            .setParameter("id", id)
            .executeUpdate();
        return retorno;
    }

}