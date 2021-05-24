import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';

import { ProductoService } from '../services/producto.service';
import { CarritoService } from '../services/carrito.service';
import { IProducto } from '../interfaces/carrito.response'

import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'; 

@Component({
  selector: 'app-detalle-producto',
  templateUrl: './detalle-producto.component.html',
  styleUrls: ['./detalle-producto.component.css']
})

export class DetalleProductoComponent implements OnInit {

  producto : IProducto | undefined;

  pensando : boolean = false;

  agregarForm = this.formBuilder.group({
    cantidad: ''
  });

  constructor(private route: ActivatedRoute,
    private router: Router,
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
    this.pensando = true;
    let carritoId = this.carritoService.CarritoExiste();
    if( carritoId == 0) {
      this.carritoService.ObtenerCarrito('').subscribe(data => {
        console.warn('carrito:',data.id);
        this.carritoService.persistir(data);
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

    if( item.cantidad <= 0 )
    {
      window.alert('Cantidad no valida');
      this.pensando = false;
      return;
    }

    item.carritoId = this.carritoService.CarritoExiste();
    this.carritoService.AgregarProducto(item).subscribe( data => {
      window.alert(data.mensaje);
      this.pensando = false;
    } );
  }

  verCarrito() {
    this.router.navigateByUrl('/carrito');
  }

  
}
