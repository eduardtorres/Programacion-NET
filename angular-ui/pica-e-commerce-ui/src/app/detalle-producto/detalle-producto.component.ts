import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder } from '@angular/forms';

import { ProductoService } from '../services/producto.service';
import { CarritoService } from '../services/carrito.service';

import { IProducto } from '../interfaces/carrito.response'

@Component({
  selector: 'app-detalle-producto',
  templateUrl: './detalle-producto.component.html',
  styleUrls: ['./detalle-producto.component.css']
})

export class DetalleProductoComponent implements OnInit {

  producto : IProducto | undefined;

  agregarForm = this.formBuilder.group({
    cantidad: ''
  });

  constructor(private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private productoService : ProductoService,
    private carritoService : CarritoService) { 
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const IdFromRoute = Number(routeParams.get('id'));
    const productos = this.productoService.getProductsOffline();
    this.producto = productos.find(x => x.id === IdFromRoute);    
  }

  onAgregarSubmit() {
    let carritoId = this.carritoService.CarritoExiste();
    if( carritoId == 0) {
      this.carritoService.ObtenerCarrito('').subscribe(data => {
        console.warn('carrito:',data.id);
        this.carritoService.persists(data);
        this.AgregarProducto();
      });
    }
    else {
      this.AgregarProducto();
    }
  }

  AgregarProducto() {

    let item : IProducto = this.producto!;
    const cantidad = this.agregarForm.get('cantidad')?.value;
    item.cantidad = Number(cantidad);
    item.carritoId = this.carritoService.CarritoExiste();

    console.warn('producto:',item);

    this.carritoService.AgregarProducto(item).subscribe( data => {
      window.alert(data.mensaje);
    } );

  }

  
}
