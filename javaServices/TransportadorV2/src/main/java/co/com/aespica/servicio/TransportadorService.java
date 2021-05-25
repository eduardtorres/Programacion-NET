package co.com.aespica.servicio;

import java.util.List;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import javax.transaction.Transactional;

import co.com.aespica.repositorio.*;
import co.com.aespica.dominio.*;


@Dependent
@Transactional(Transactional.TxType.SUPPORTS)
public class TransportadorService {

    @Inject
    EntityManager entityManager;

    public List<Transportador> TransportadorObtener() {
        return entityManager
                .createNamedQuery("Transportador.ObtenerTodos", Transportador.class)
                .getResultList();
    }
}