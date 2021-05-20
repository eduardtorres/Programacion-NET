import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

import { CarritoService } from '../services/carrito.service';

import { IProducto } from '../interfaces/carrito.response'

@Component({
  selector: 'app-detalle-carrito',
  templateUrl: './detalle-carrito.component.html',
  styleUrls: ['./detalle-carrito.component.css']
})

export class DetalleCarritoComponent implements OnInit {

  productos : IProducto [] = [];

  constructor(
    private router: Router,
    private carritoService : CarritoService) { 

  }

  ngOnInit(): void {
    this.consultarProductos();
  }

  consultarProductos() {
    this.carritoService.consultarProductos().subscribe( data => {
      this.productos = data;
      this.carritoService.persistirProductos(data);
    } );
  }

  quitarProducto(item : IProducto) {
    this.carritoService.quitarProducto(item).subscribe( data => {
      this.consultarProductos();
    } );
  }

  pagar() {
    this.router.navigateByUrl('/pagar');
    //this.router.navigate(['/root/child', crisis.id]);
  }

}
