import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ProductoService } from '../services/producto.services';

import { IProducto } from '../interfaces/productos.buscar.response'

@Component({
  selector: 'app-detalle-producto',
  templateUrl: './detalle-producto.component.html',
  styleUrls: ['./detalle-producto.component.css']
})

export class DetalleProductoComponent implements OnInit {

  producto : IProducto | undefined;

  constructor(private route: ActivatedRoute,
    private productoService : ProductoService) { 

  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const IdFromRoute = Number(routeParams.get('id'));
    const productos = this.productoService.getProductsOffline();

    this.producto = productos.find(x => x.id === IdFromRoute);

  }

}
