import { Component , OnInit } from '@angular/core';

import { ProductoService } from '../services/producto.service';

import { IProducto } from '../interfaces/carrito.response'

import { FormBuilder } from '@angular/forms';

import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'; 
import { CarritoService } from '../services/carrito.service';
import { ICliente } from '../interfaces/cliente.response';
import { IPais } from '../interfaces/precios.response';
import { PaisService } from '../services/pais.service';

@Component({
  selector: 'app-buscar-producto',
  templateUrl: './buscar-producto.component.html',
  styleUrls: ['./buscar-producto.component.css']
})
export class BuscarProductoComponent implements OnInit {

  productos : IProducto[] = [];
  paises : IPais[] = [];
  cliente : ICliente | undefined ;
  pensando : boolean = false;
  nrSelect : string = 'COL';

  busquedaForm = this.formBuilder.group({
    filtro: ''
  });

  constructor(
    private formBuilder: FormBuilder,
    private productoService : ProductoService,
    private carritoService : CarritoService,
    private paisService : PaisService
     ) { 

  }

  onSubmit(): void {
    // Process checkout data here
    //console.warn('Your order has been submitted', this.checkoutForm.value);    
    this.BuscarProductos();
  }

  ngOnInit(): void {
    this.BuscarProductos();
    this.cliente = this.carritoService.cliente;

    this.paisService.obtener().subscribe(data => {  
      this.paisService.persistir( data );
      this.paises = data;
    });
  }

  BuscarProductos() {

    let busqueda = this.busquedaForm.get('filtro')?.value;

    if( busqueda == '' ) {
      busqueda = 'all'
    }

    this.pensando = true;
    this.productoService.getProducts(busqueda).subscribe( data => {
      this.productos = data;
      this.productoService.persists( data );
      this.pensando = false;
    } );
  }

  onCountryChange( value : string ) {
    this.carritoService.actualizarPais(value);
    this.BuscarProductos();
  }

}


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/