import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { IBuscarProductosResponse } from '../interfaces/productos.buscar.response'

import { IProducto } from '../interfaces/productos.buscar.response'

import { configuracion } from './configuracion';

@Injectable({
  providedIn: 'root'
})

export class ProductoService {

  productos : IProducto[] = [];

    constructor(
        private http: HttpClient
      ) {}    

    getProducts(busqueda:String) {
      
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }

      let serviceUrl : string = configuracion.urlServicio;

      //return this.http.get<IBuscarProductosResponse>( serviceUrl + '/producto/listado/obtener/COP/' + busqueda , httpOptions);
      return this.http.get<IProducto[]>( serviceUrl + '/producto/listado/obtener/COP/' + busqueda , httpOptions);
    }    

    getProductsOffline()
    {
      return this.productos;
    }

    persists( collection : IProducto[]  ) {
      this.productos = collection;
    }

}