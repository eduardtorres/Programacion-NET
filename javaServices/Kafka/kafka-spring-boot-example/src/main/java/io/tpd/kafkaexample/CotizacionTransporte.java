package io.tpd.kafkaexample;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.text.DateFormat;
import java.util.Date;

public class CotizacionTransporte {
    private final String message;

    public String getMessage() {
        return message;
    }

    public int getId_cotizacion() {
        return id_cotizacion;
    }

    public long getId_cliente() {
        return id_cliente;
    }

    public int getCod_ciudad_origen() {
        return cod_ciudad_origen;
    }

    public int getCod_ciudad_destino() {
        return cod_ciudad_destino;
    }

    public int getPeso() {
        return peso;
    }

    private final int id_cotizacion;
    private final long id_cliente;
    private final int cod_ciudad_origen;
    private final int cod_ciudad_destino;
    private final int peso;
    private final int tamano;
    private final Date fecha;

    public int getTamano() {
        return tamano;
    }

    public Date getFecha() {
        return fecha;
    }


    @Override
    public String toString() {
        return "CotizacionTransporte{" +
                "message='" + message + '\'' +
                ", id_cotizacion=" + id_cotizacion +
                ", id_cliente=" + id_cliente +
                ", cod_ciudad_origen=" + cod_ciudad_origen +
                ", cod_ciudad_destino=" + cod_ciudad_destino +
                ", peso=" + peso +
                ", tamaño=" + tamano +
                ", fecha=" + fecha +
                '}';
    }

    public CotizacionTransporte(@JsonProperty("message") final String message,
                                @JsonProperty("id_cotizacion") final int id_cotizacion,
                                @JsonProperty("id_cliente") final long id_cliente,
                                @JsonProperty("cod_ciudad_origen") final int cod_ciudad_origen,
                                @JsonProperty("cod_ciudad_destino") final int cod_ciudad_destino,
                                @JsonProperty("peso") final int peso,
                                @JsonProperty("tamaño") final int tamano,
                                @JsonProperty("fecha") final Date fecha) {
        this.message = message;
        this.id_cotizacion = id_cotizacion;
        this.id_cliente = id_cliente;
        this.cod_ciudad_origen = cod_ciudad_origen;
        this.cod_ciudad_destino = cod_ciudad_destino;
        this.peso = peso;
        this.tamano = tamano;
        this.fecha = fecha;
    }



}
