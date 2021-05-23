import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Configuracion } from './configuracion';

import { IRespuesta, ICarrito, IProducto, ICotizar } from '../interfaces/carrito.response'
import { ICliente } from '../interfaces/cliente.response';
import { IOrden , IOrdenResponse } from '../interfaces/orden.response';

@Injectable({
  providedIn: 'root'
})

export class CarritoService {

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  pais : string = 'COL';
  usuario : string = '';
  carrito : ICarrito | undefined;
  cliente : ICliente | undefined;
  productos : IProducto [] = [];

    constructor(
        private http: HttpClient,
        private configuracion : Configuracion
      ) {}    

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

    persistir( _carrito : ICarrito ) {
      this.carrito = _carrito;
    }

    actualizarPais( _pais : string ) {
      this.pais = _pais;
    }

    persistirCliente( _cliente : ICliente ) {
      this.cliente = _cliente;
    }

    persistirProductos( _productos : IProducto [] ) {
      this.productos = _productos;
    }

    ObtenerCarrito(newEmail : string) {
      if( newEmail == '' )
      {
        if( this.usuario == '')
        {
          this.usuario = this.configuracion.obtenerStringAleatoria();
        }
      }
      else
      {
        this.usuario = newEmail;
      }
      let serviceUrl : string = this.configuracion.urlServicio;
      let url = serviceUrl + '/carrito/obtener/' + this.usuario + '/' + this.pais ;      
      return this.http.get<ICarrito> ( url , this.httpOptions);
    }

    limpiar() {
      let serviceUrl : string = this.configuracion.urlServicio;
      let url = serviceUrl + '/carrito/limpiar/' + this.CarritoExiste().toString() ;      
      return this.http.delete<number> ( url , this.httpOptions);            
    }

    AgregarProducto(producto: IProducto) {      
      let serviceUrl : string = this.configuracion.urlServicio;
      return this.http.post<IRespuesta>( 
          serviceUrl + '/carrito/producto/agregar',
          producto,
          this.httpOptions);
    }    

    quitarProducto(producto : IProducto) {
      let serviceUrl : string = this.configuracion.urlServicio;
      return this.http.post<IRespuesta>( 
        serviceUrl + '/carrito/producto/quitar',
        producto,
        this.httpOptions);
    }

    consultarProductos() {
      let serviceUrl : string = this.configuracion.urlServicio;
      let url = serviceUrl + '/carrito/productos/consultar/' + this.CarritoExiste().toString() ;      
      return this.http.get<IProducto[]> ( url , this.httpOptions);            
    }

    cotizar() {
      let request = {
        carritoId : this.CarritoExiste()
      };
      let serviceUrl : string = this.configuracion.urlServicio;
      let url = serviceUrl + '/carrito/orden/cotizar' ;      
      return this.http.post<ICotizar> ( url , request , this.httpOptions);            
    }
}