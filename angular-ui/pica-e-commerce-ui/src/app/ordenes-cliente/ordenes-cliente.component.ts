import { Component, OnInit } from '@angular/core';

import { IOrden } from '../interfaces/orden.response';
import { CarritoService } from '../services/carrito.service';
import { OrdenService } from '../services/orden.service';

import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'; 

@Component({
  selector: 'app-ordenes-cliente',
  templateUrl: './ordenes-cliente.component.html',
  styleUrls: ['./ordenes-cliente.component.css']
})

export class OrdenesClienteComponent implements OnInit {

  ordenes : IOrden[] = [];
  pensando : boolean = false;

  constructor(private carritoService : CarritoService,
    private ordenService : OrdenService) { 
      
    }

  ngOnInit(): void {
    this.pensando = true;
    this.ordenService.consultarOrdenesPorUsuario( this.carritoService.cliente! ).subscribe( data => {
      this.ordenes = data;
      this.pensando = false;
    });
  }

}
