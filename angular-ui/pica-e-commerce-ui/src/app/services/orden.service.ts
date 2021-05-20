import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { IMedioPago } from '../interfaces/orden.response'

import { configuracion } from './configuracion';

@Injectable({
    providedIn: 'root'
})
  
export class OrdenService {
  
    httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }

    constructor(private http: HttpClient) {        
    }

    consultarMedios() {
        let serviceUrl : string = configuracion.urlServicio;
        let url = serviceUrl + '/pago/medios/obtener' ;      
        return this.http.get<IMedioPago[]> ( url , this.httpOptions);            
    }

}