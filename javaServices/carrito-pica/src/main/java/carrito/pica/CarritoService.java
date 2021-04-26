package carrito.pica;

import org.eclipse.microprofile.config.inject.ConfigProperty;

import javax.annotation.PostConstruct;
import javax.annotation.PreDestroy;
import javax.enterprise.context.Dependent;
import javax.inject.Inject;

import javax.persistence.EntityManager;
import javax.transaction.Transactional;

import java.util.Collections;
import java.util.List;
import java.util.Optional;
import java.util.concurrent.TimeUnit;
import java.util.logging.Logger;
import java.util.ArrayList;

@Dependent
@Transactional(Transactional.TxType.SUPPORTS)
public class CarritoService
{

    @Inject
    EntityManager entityManager;

    public List<Carrito> fetchAll() {
        return entityManager
                .createNamedQuery("Carrito.findAll", Carrito.class)
                .getResultList();
    }


    // public List<Carrito> fetchAll2() {
    //     List<Carrito> lista = new ArrayList<Carrito>();
    //     lista.add( new Carrito(1,"None") );
    //     return lista;
    // }


}