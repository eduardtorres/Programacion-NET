import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { IProducto } from '../interfaces/carrito.response'

import { Configuracion } from './configuracion';
import { CarritoService } from './carrito.service';
import { PaisService } from './pais.service';

@Injectable({
  providedIn: 'root'
})

export class ProductoService {

  productos : IProducto[] = [];

    constructor(private http: HttpClient,
        private carritoService : CarritoService,
        private paisService : PaisService,
        private configuracion : Configuracion
      ) {}    

    getProducts(busqueda:string) {
      
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }

      let serviceUrl : string = this.configuracion.urlServicio;
      let moneda : string = this.paisService.getMonedaFromCountry( this.carritoService.pais );
      return this.http.get<IProducto[]>( serviceUrl + '/producto/listado/obtener/' + moneda + '/' + busqueda , httpOptions);
    }    

    getProductsOffline()
    {
      return this.productos;
    }

    persists( collection : IProducto[]  ) {
      this.productos = collection;
    }

}