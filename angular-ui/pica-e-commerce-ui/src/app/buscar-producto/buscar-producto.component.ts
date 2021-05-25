import { Component , OnInit } from '@angular/core';

import { ProductoService } from '../services/producto.service';

import { IProducto } from '../interfaces/carrito.response'

import { FormBuilder } from '@angular/forms';

import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'; 
import { CarritoService } from '../services/carrito.service';
import { ICliente } from '../interfaces/cliente.response';

@Component({
  selector: 'app-buscar-producto',
  templateUrl: './buscar-producto.component.html',
  styleUrls: ['./buscar-producto.component.css']
})
export class BuscarProductoComponent implements OnInit {

  productos : IProducto[] = [];
  cliente : ICliente | undefined ;
  pensando : boolean = false;
  
  busquedaForm = this.formBuilder.group({
    filtro: ''
  });

  constructor(
    private productoService : ProductoService,
    private carritoService : CarritoService,
    private formBuilder: FormBuilder
     ) { 

  }

  onSubmit(): void {
    // Process checkout data here
    //console.warn('Your order has been submitted', this.checkoutForm.value);    
    const busqueda = this.busquedaForm.get('filtro')?.value;
    this.BuscarProductos( busqueda );
  }

  ngOnInit(): void {
    this.BuscarProductos( 'all' );
    this.cliente = this.carritoService.cliente;
  }

  BuscarProductos( filtro : string ) {
    this.pensando = true;
    this.productoService.getProducts(filtro).subscribe( data => {
      this.productos = data;
      this.productoService.persists( data );
      this.pensando = false;
    } );
  }

  onCountryChange( value : string ) {
    this.carritoService.actualizarPais(value);
  }

}


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/