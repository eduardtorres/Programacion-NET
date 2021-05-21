import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { configuracion } from './configuracion';

import { IAutenticar, ICliente } from '../interfaces/cliente.response';

@Injectable({
    providedIn: 'root'
})
  
export class ClienteService {
  
    httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }

    constructor(private http: HttpClient) {        
    }

    autenticar( email : string , password : string ) {      
        let request = {
          userName : email,
          password : password
        };
        let serviceUrl : string = configuracion.urlServicio;
        let url = serviceUrl + '/cliente/autenticar' ;      
        return this.http.post<IAutenticar> ( url , request , this.httpOptions);            
    }

    registrar( request : ICliente ) {
        let serviceUrl : string = configuracion.urlServicio;
        let url = serviceUrl + '/cliente/registrar' ;      
        return this.http.post<ICliente> ( url , request , this.httpOptions);                    
    }

}