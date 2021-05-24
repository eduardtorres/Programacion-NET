package transportadores.pica.repositorios;

import javax.persistence.*;
import transportadores.pica.dominio.TransportadorDto;

import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "Transportador")
@NamedQueries({
        @NamedQuery(name = "Transportador.findAll", query = "SELECT p FROM Transportador p WHERE p.estadoTransportador = 1"),
        @NamedQuery(name = "Transportador.ObtenerPorid", query = "SELECT p FROM Transportador p WHERE p.idTransportador = :idTransportador")
})
public class Transportador {

    @Id
   // @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idTransportador")
    public long idTransportador;
    @Column(name = "nombreTransportador;", nullable = false)
    public String nombreTransportador;
    @Column(name = "emailTransportador", nullable = false)
    public String emailTransportador;
    @Column(name = "direccionTransportador", nullable = false)
    public String direccionTransportador;
    @Column(name = "telefono", nullable = false)
    public String telefono;
    @Column(name = "estadoTransportador", nullable = false)
    public String estadoTransportador;

    public Transportador()
    {

    }

    public Transportador(long    _idTransportador,
                         String  _nombreTransportador,
                         String  _emailTransportador,
                         String  _direccionTransportador,
                         String  _telefono,
                         String _estadoTransportador)
    {
        idTransportador         = _idTransportador;
        nombreTransportador     = _nombreTransportador;
        emailTransportador      = _emailTransportador;
        direccionTransportador  = _direccionTransportador;
        telefono                 = _telefono;
        estadoTransportador     = _estadoTransportador;

    }

    public long    getid_transportador() { return idTransportador; }
    public String  getnombreTransportador() { return nombreTransportador; }
    public String  getemailTransportador() { return emailTransportador; }
    public String  getdireccion_transporta() { return direccionTransportador; }
    public String  gettelefono() { return telefono; }
    public String getestadoTransportador() { return estadoTransportador; }


    public void LoadFromDto(TransportadorDto transportadorDto)
    {
        idTransportador                     = transportadorDto.idTransportador                    ;
        nombreTransportador                 = transportadorDto.nombreTransportador                ;
        emailTransportador                  = transportadorDto.emailTransportador                 ;
        direccionTransportador              = transportadorDto.direccionTransportador             ;
        telefono                             = transportadorDto.telefono                            ;
        estadoTransportador                 = transportadorDto.estadoTransportador                ;

    }
    public TransportadorDto ToDto()
    {
        TransportadorDto response = new TransportadorDto();

        response.idTransportador                      = idTransportador         ;
        response.nombreTransportador                  = nombreTransportador     ;
        response.emailTransportador                   = emailTransportador      ;
        response.direccionTransportador               = direccionTransportador  ;
        response.telefono                              = telefono                 ;
        response.estadoTransportador                  = estadoTransportador     ;

        return response;
    }

    public static List<TransportadorDto> ToListDto(List<Transportador> originalList )
    {
        List<TransportadorDto> newList = new ArrayList<TransportadorDto>();
        for( Transportador item : originalList )
        {
            newList.add(item.ToDto());
        }
        return newList;
    }
}
