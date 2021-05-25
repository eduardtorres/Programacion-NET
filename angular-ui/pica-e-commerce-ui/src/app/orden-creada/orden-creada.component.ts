import { Component, OnInit } from '@angular/core';
import { IDetalleOrden, IOrden } from '../interfaces/orden.response';
import { OrdenService } from '../services/orden.service';

@Component({
  selector: 'app-orden-creada',
  templateUrl: './orden-creada.component.html',
  styleUrls: ['./orden-creada.component.css']
})
export class OrdenCreadaComponent implements OnInit {

  orden : IOrden | undefined;
  detalles : IDetalleOrden [] = [];

  constructor(  private ordenService : OrdenService ) { }

  ngOnInit(): void {

    this.orden = this.ordenService.ordenCreada;
    this.detalles = this.orden?.detallesOrden!;

  }

}
