import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Configuracion } from './configuracion';
import { IPais } from '../interfaces/precios.response';

@Injectable({
    providedIn: 'root'
})
  
export class PaisService {

    paises : IPais[] = [];

    httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }
  
      constructor(private http: HttpClient,
          private configuracion : Configuracion) {        
      }

    obtener() {
        let serviceUrl : string = this.configuracion.urlServicio;
        let url = serviceUrl + '/precio/pais/obtener/1' ;      
        return this.http.get<IPais[]> ( url , this.httpOptions);           
    }

    persistir( paises : IPais[] ) {
        this.paises = paises;
    }

    getMonedaFromCountry(pais : string) {
        for(let item of this.paises )
        {
            if( item.codPais == pais )
                return item.codMoneda;
        }
        return 'COP';
      }
}