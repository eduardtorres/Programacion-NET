import { Component } from '@angular/core';

import { ProductService } from '../services/product.services';

import { IBuscarProductosResponse , IProducto } from '../interfaces/productos.buscar.response'

@Component({
  selector: 'app-buscar-producto',
  templateUrl: './buscar-producto.component.html',
  styleUrls: ['./buscar-producto.component.css']
})
export class BuscarProductoComponent {

  shippingCosts = this.productService.getShippingPrices();
  productos : IProducto[] = [];
  
  constructor(private productService : ProductService ) { 

  }

  share() {
    window.alert('The product has been shared!');
  }

  showData() {
    this.productService.getProducts().subscribe( data => {
      this.productos = data.productos
    } );
  }

}


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/