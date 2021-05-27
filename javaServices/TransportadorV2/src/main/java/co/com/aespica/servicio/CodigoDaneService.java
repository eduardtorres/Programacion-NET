package co.com.aespica.servicio;

import co.com.aespica.repositorio.CodigoDane;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import javax.transaction.Transactional;
import java.util.List;


@Dependent
@Transactional(Transactional.TxType.SUPPORTS)
public class CodigoDaneService {

    @Inject
    EntityManager entityManager;

    public List<CodigoDane> CodidoDaneObtener() {
        return entityManager
                .createNamedQuery("CodigoDane.ObtenerTodos", CodigoDane.class)
                .getResultList();
    }
    public List<CodigoDane> ObtenerCodidoDaneXId(String idcoddane)
    {
        return entityManager
                .createNamedQuery("CodigoDane.ObtenerxCodigoDane", CodigoDane.class)
                .setParameter("idcoddane", idcoddane)
                .getResultList();
    }

    public List<CodigoDane> ObtenerCodidoDaneXMuni(String cadena)
    {
        return entityManager
                .createNamedQuery("CodigoDane.ObtenerxMunicipio", CodigoDane.class)
                .setParameter("cadena", "%" + cadena + "%")
                .getResultList();
    }
}