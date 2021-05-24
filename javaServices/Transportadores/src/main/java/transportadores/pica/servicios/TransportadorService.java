package transportadores.pica.servicios;

import transportadores.pica.dominio.RespuestaBaseDto;
import transportadores.pica.dominio.TransportadorDto;
import transportadores.pica.repositorios.Transportador;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;

import javax.persistence.EntityManager;
import javax.transaction.Transactional;

import java.util.Date;
import java.util.List;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;

@Dependent
@Transactional(Transactional.TxType.SUPPORTS)
public class TransportadorService {

    @Inject
    EntityManager entityManager;

    public List<Transportador> fetchAll() {
        return entityManager
                .createNamedQuery("Transportador.findAll", Transportador.class)
                .getResultList();
    }


    public List<Transportador> ObtenerTransportadorID(long idTransportador)
    {
        return entityManager
                .createNamedQuery("Transportador.ObtenerPorid", Transportador.class)
                .setParameter("idTransportador", idTransportador)
                .getResultList();     
    }

    public Transportador TransportadorExiste(TransportadorDto transportadorDto)
    {
        return entityManager
                .createNamedQuery("Transportador.ObtenerPorid", Transportador.class)
                .setParameter("idTransportador", transportadorDto.idTransportador)
                .getResultStream()
                .findFirst()
                .orElse(null);  
    }


    @Transactional
    public RespuestaBaseDto AgregarTransportador(TransportadorDto transportadorDto)
    {

        Transportador TransportadorEncontrado = TransportadorExiste(transportadorDto);
        RespuestaBaseDto respuesta;
        if( TransportadorEncontrado != null )
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 0;
            respuesta.mensaje = "El Transportador ya existe en el Transportador";
        }
        else
        {
            Transportador Transportador = new Transportador();
            Transportador.LoadFromDto(transportadorDto);
            entityManager.persist(Transportador);
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 100;
            respuesta.mensaje = "Transportador agregado satisfactoriamente";
        }
        return respuesta;
    }


    @Transactional
    public RespuestaBaseDto QuitarTransportador( TransportadorDto request ) {

        int retorno = entityManager.createQuery("delete from Transportador where idTransportador = :idTransportador ")
            .setParameter("idTransportador", request.idTransportador)
            .executeUpdate();

        RespuestaBaseDto respuesta;

        if( retorno >= 1 )
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 100;
            respuesta.mensaje = "Transportador quitado satisfactoriamente";    
        }
        else
        {
            respuesta = new RespuestaBaseDto();
            respuesta.codigo = 0;
            respuesta.mensaje = "Transportador no existe:" + request.nombreTransportador ;
        }

        return respuesta;
    }


}