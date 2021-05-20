import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { IProducto } from '../interfaces/carrito.response'

import { configuracion } from './configuracion';
import { CarritoService } from './carrito.service';

@Injectable({
  providedIn: 'root'
})

export class ProductoService {

  productos : IProducto[] = [];

    constructor(private http: HttpClient,
        private carritoService : CarritoService
      ) {}    

    getProducts(busqueda:String) {
      
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }

      let serviceUrl : string = configuracion.urlServicio;
      let moneda : string = this.getMonedaFromCountry();
      return this.http.get<IProducto[]>( serviceUrl + '/producto/listado/obtener/' + moneda + '/' + busqueda , httpOptions);
    }    

    getProductsOffline()
    {
      return this.productos;
    }

    persists( collection : IProducto[]  ) {
      this.productos = collection;
    }

    getMonedaFromCountry() {
      let pais = this.carritoService.pais;
      if( pais == 'COL' )
        return 'COP';
      else if ( pais == 'CHL' )
        return 'CLP';
      else
        return '';
    }

}