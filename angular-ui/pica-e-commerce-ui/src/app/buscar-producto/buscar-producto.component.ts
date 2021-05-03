import { Component } from '@angular/core';

import { ProductService } from '../services/product.services';

import { IBuscarProductosResponse , IProducto } from '../interfaces/productos.buscar.response'

import { FormBuilder } from '@angular/forms';
import { stringify } from '@angular/compiler/src/util';

@Component({
  selector: 'app-buscar-producto',
  templateUrl: './buscar-producto.component.html',
  styleUrls: ['./buscar-producto.component.css']
})
export class BuscarProductoComponent {

  shippingCosts = this.productService.getShippingPrices();
  productos : IProducto[] = [];
  
  checkoutForm = this.formBuilder.group({
    name: ''
  });

  constructor(
    private productService : ProductService,
    private formBuilder: FormBuilder ) { 

  }

  share() {
    window.alert('The product has been shared!');
  }

  showData() {
  }

  onSubmit(): void {
    // Process checkout data here
    console.warn('Your order has been submitted', this.checkoutForm.value);    
    const busqueda = this.checkoutForm.get('name')?.value;
    this.productService.getProducts(busqueda).subscribe( data => {
      this.productos = data.productos
    } );

  }  

}


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/