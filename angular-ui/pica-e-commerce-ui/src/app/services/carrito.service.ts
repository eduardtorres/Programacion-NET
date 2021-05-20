import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { IRespuesta, ICarrito, IProducto, ICotizar } from '../interfaces/carrito.response'

import { configuracion } from './configuracion';

@Injectable({
  providedIn: 'root'
})

export class CarritoService {

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  carrito : ICarrito | undefined;

    constructor(
        private http: HttpClient
      ) {}    

    AgregarProducto(producto: IProducto) {
      
      let serviceUrl : string = configuracion.urlServicio;

      //return this.http.get<IBuscarProductosResponse>( serviceUrl + '/producto/listado/obtener/COP/' + busqueda , httpOptions);
      return this.http.post<IRespuesta>( 
          serviceUrl + '/carrito/producto/agregar',
          producto,
          this.httpOptions);
    }    

    CarritoExiste() {
      if( this.carrito == undefined )
      {
        return 0;
      }
      else
      {
        return this.carrito.id;
      }
    }

    ObtenerCarrito(newEmail : string) {
      let pais = 'COL';
      let usuario = '';
      if( newEmail == '' )
      {
        if( this.carrito === undefined  )
        {
          let max = 1000000000;
          let min = 100000000;
          usuario =  (Math.floor(Math.random() * (max - min + 1)) + min).toString();
        }
        else
        {
          usuario = this.carrito?.usuario;
        }
      }
      else
      {
        usuario = newEmail;
      }

      let serviceUrl : string = configuracion.urlServicio;
      let url = serviceUrl + '/carrito/obtener/' + usuario + '/' + pais ;      

      return this.http.get<ICarrito> ( url , this.httpOptions);
    }

    persists( carrito : ICarrito ) {
      this.carrito = carrito;
    }

    quitarProducto(producto : IProducto) {

      let serviceUrl : string = configuracion.urlServicio;

      return this.http.post<IRespuesta>( 
        serviceUrl + '/carrito/producto/quitar',
        producto,
        this.httpOptions);
    }

    consultarProductos() {
      let serviceUrl : string = configuracion.urlServicio;
      let url = serviceUrl + '/carrito/productos/consultar/' + this.CarritoExiste().toString() ;      
      return this.http.get<IProducto[]> ( url , this.httpOptions);            
    }

    cotizar() {
      let request = {
        carritoId : this.CarritoExiste()
      };
      let serviceUrl : string = configuracion.urlServicio;
      let url = serviceUrl + '/carrito/orden/cotizar' ;      
      return this.http.post<ICotizar> ( url , request , this.httpOptions);            
    }

}