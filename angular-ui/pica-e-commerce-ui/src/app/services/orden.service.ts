import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { IMedioPago, IOrden, IOrdenResponse } from '../interfaces/orden.response'

import { Configuracion } from './configuracion';
import { ICliente } from '../interfaces/cliente.response';

@Injectable({
    providedIn: 'root'
})
  
export class OrdenService {
  
    ordenCreada : IOrden | undefined;

    httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }

    constructor(private http: HttpClient,
        private configuracion : Configuracion) {        
    }

    consultarMedios() {
        let serviceUrl : string = this.configuracion.urlServicio;
        let url = serviceUrl + '/pago/medios/obtener' ;      
        return this.http.get<IMedioPago[]> ( url , this.httpOptions);            
    }

    colocarOrden(orden : IOrden) {
        let serviceUrl : string = this.configuracion.urlServicio;
        let url = serviceUrl + '/orden/colocar' ;      
        return this.http.post<IOrdenResponse>( 
          url,
          orden,
          this.httpOptions);
      }
    
    persistir( orden : IOrden ) {
        this.ordenCreada = orden;
    }

    consultarOrdenesPorUsuario( cliente : ICliente ) {
        let serviceUrl : string = this.configuracion.urlServicio;
        let url = serviceUrl + '/orden/ordenes_cliente/' + cliente.userName ;      
        return this.http.get<IOrden[]>( 
          url,
          this.httpOptions);
    }
}