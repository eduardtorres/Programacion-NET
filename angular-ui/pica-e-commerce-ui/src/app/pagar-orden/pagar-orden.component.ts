import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';

import { CarritoService } from '../services/carrito.service';
import { OrdenService } from '../services/orden.service';

import { ICotizar } from '../interfaces/carrito.response'
import { IMedioPago } from '../interfaces/orden.response'



@Component({
  selector: 'app-pagar-orden',
  templateUrl: './pagar-orden.component.html',
  styleUrls: ['./pagar-orden.component.css']
})

export class PagarOrdenComponent implements OnInit {

  cotizar: ICotizar | undefined;

  medios: IMedioPago[] = [];

  mostrarCC : boolean = false;

  informacionForm = this.formBuilder.group({
    nombre: new FormControl(),
    direccion: new FormControl(),
    telefono: new FormControl(),
    medios: new FormControl(),
    numero: new FormControl(),
    vencimiento: new FormControl(),
    ccv: new FormControl()
  });

  constructor(private formBuilder: FormBuilder,
    private carritoService : CarritoService,
    private ordenService : OrdenService) {    
  }

  ngOnInit(): void {

    this.carritoService.cotizar().subscribe( data => {  
      this.cotizar = data;
    });

    this.ordenService.consultarMedios().subscribe( data => {
      this.medios = data;
    });

  }

  onMediosChange( value : any ) {
    if( value == '2' )
    {
      this.mostrarCC = true;
    }
    else
    {
      this.mostrarCC = false;
    }
  }

}
