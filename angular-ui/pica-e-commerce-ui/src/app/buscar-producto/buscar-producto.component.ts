import { Component } from '@angular/core';

import { ProductoService } from '../services/producto.services';

import { IBuscarProductosResponse , IProducto } from '../interfaces/productos.buscar.response'

import { FormBuilder } from '@angular/forms';

import { stringify } from '@angular/compiler/src/util';

import {Router} from '@angular/router';

@Component({
  selector: 'app-buscar-producto',
  templateUrl: './buscar-producto.component.html',
  styleUrls: ['./buscar-producto.component.css']
})
export class BuscarProductoComponent {

  productos : IProducto[] = [];
  
  checkoutForm = this.formBuilder.group({
    name: ''
  });

  constructor(
    private productoService : ProductoService,
    private formBuilder: FormBuilder,
    private router: Router
     ) { 

  }

  share() {
    window.alert('The product has been shared!');
  }

  navigatetoUrl() {
    this.router.navigateByUrl('/login');
    //this.router.navigate(['/root/child', crisis.id]);
  }

  onSubmit(): void {
    // Process checkout data here
    console.warn('Your order has been submitted', this.checkoutForm.value);    
    const busqueda = this.checkoutForm.get('name')?.value;
    this.productoService.getProducts(busqueda).subscribe( data => {
      this.productos = data
      this.productoService.persists( data );
    } );
  }  

}


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/