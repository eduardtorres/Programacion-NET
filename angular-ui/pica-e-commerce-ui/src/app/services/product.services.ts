import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { IBuscarProductosResponse } from '../interfaces/productos.buscar.response'

@Injectable({
  providedIn: 'root'
})

export class ProductService {

    constructor(
        private http: HttpClient
      ) {}    

    getShippingPrices() {
      return this.http.get<{type: string, price: number}[]>('/assets/shipping.json');
    }    

    getProducts(busqueda:String) {
      
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }

      return this.http.get<IBuscarProductosResponse>('http://localhost:5000/producto/listado/obtener/' + busqueda , httpOptions);
      
    }    


}