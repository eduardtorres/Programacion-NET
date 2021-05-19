package co.com.aespica.Servicio;

import java.util.List;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import javax.transaction.Transactional;


import co.com.aespica.repositorio.Intercambio;
import co.com.aespica.repositorio.Impuesto;


@Dependent
@Transactional(Transactional.TxType.SUPPORTS)
public class IntercambioService {

    @Inject
    EntityManager entityManager;

    public List<Intercambio> fetchAll() {
        return entityManager
                .createNamedQuery("Intercambio.findAll", Intercambio.class)
                .getResultList();
    }

    public Intercambio getById(String CodMoneda) {
        return entityManager
                .createNamedQuery("Intercambio.obtenerTasaIntercambio",Intercambio.class)
                .setParameter("CodMoneda", CodMoneda)
                .getSingleResult();
    }

    public List<Impuesto> getByIdImpuesto(String CodPais) {
        return entityManager
                .createNamedQuery("Impuesto.obtenerImpuesto",Impuesto.class)
                .setParameter("CodPais", CodPais)
                .getResultList();
    }

    public double getByIdImpuestoTotal(String CodPais) {
        
        List<Impuesto> Impuestos= entityManager
        .createNamedQuery("Impuesto.obtenerImpuesto",Impuesto.class)
        .setParameter("CodPais", CodPais)
        .getResultList();

        int sumaTotal=0;
        for (int i=0; i <=Impuestos.size()-1;i++){
            Impuesto impuestoTemp= Impuestos.get(i);
            sumaTotal+= impuestoTemp.getValor();
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