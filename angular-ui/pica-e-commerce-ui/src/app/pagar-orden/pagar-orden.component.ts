import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

import { CarritoService } from '../services/carrito.service';
import { OrdenService } from '../services/orden.service';

import { ICotizar, IProducto } from '../interfaces/carrito.response'
import { IDatosPago, IDetalleOrden, IMedioPago, IOrden } from '../interfaces/orden.response'
import { ICliente } from '../interfaces/cliente.response';

import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'; 

@Component({
  selector: 'app-pagar-orden',
  templateUrl: './pagar-orden.component.html',
  styleUrls: ['./pagar-orden.component.css']
})

export class PagarOrdenComponent implements OnInit {

  cotizar: ICotizar | undefined;

  medios: IMedioPago[] = [];

  mostrarCC : boolean = false;

  pensando : boolean = false;

  informacionForm = this.formBuilder.group({
    NombreEnvio: new FormControl(),
    ApellidoEnvio: new FormControl(),
    DireccionEnvio: new FormControl(),
    TelefonoEnvio: new FormControl(),
    CiudadEnvio: new FormControl(),
    CodigoAreaEnvio: new FormControl(),
    medios: new FormControl(),
    CCtitular: new FormControl(),
    CCtipo: new FormControl(),
    CCnumero: new FormControl(),
    CCvencimiento: new FormControl(),
    CCV: new FormControl()
  });

  facturacionForm = this.formBuilder.group({
    NumeroDocumentoCliente: new FormControl(),
    TelefonoFacturacion: new FormControl(),
    DireccionFacturacion: new FormControl(),
    CorreoElectronicoFacturacion: new FormControl()
  });

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private carritoService : CarritoService,
    private ordenService : OrdenService) {    
  }

  ngOnInit(): void {

    this.pensando = true;

    this.carritoService.cotizar().subscribe( data => {  
      this.cotizar = data;
    });

    this.ordenService.consultarMedios().subscribe( data => {
      this.medios = data;
      this.pensando = false;
    });

    if( this.carritoService.cliente != undefined )
    {
      let cliente : ICliente = this.carritoService.cliente;
      this.facturacionForm.patchValue({  
        NumeroDocumentoCliente : cliente.nit,
        TelefonoFacturacion : cliente.telefono,
        DireccionFacturacion : cliente.direccion,
        CorreoElectronicoFacturacion : cliente.userName
        });
    }

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

  pagarOrden() {

    let NombreEnvio = this.informacionForm.get('NombreEnvio')?.value;
    let ApellidoEnvio = this.informacionForm.get('ApellidoEnvio')?.value;
    let DireccionEnvio = this.informacionForm.get('DireccionEnvio')?.value;
    let TelefonoEnvio = this.informacionForm.get('TelefonoEnvio')?.value;
    let CiudadEnvio = this.informacionForm.get('CiudadEnvio')?.value;
    let CodigoAreaEnvio = this.informacionForm.get('CodigoAreaEnvio')?.value;
    let medios = this.informacionForm.get('medios')?.value;
    let CCtitular = this.informacionForm.get('CCtitular')?.value;
    let CCtipo = this.informacionForm.get('CCtipo')?.value;
    let CCnumero = this.informacionForm.get('CCnumero')?.value;
    let CCvencimiento = this.informacionForm.get('CCvencimiento')?.value;
    let CCV = this.informacionForm.get('CCV')?.value;

    let NumeroDocumentoCliente = this.facturacionForm.get('NumeroDocumentoCliente')?.value;
    let TelefonoFacturacion = this.facturacionForm.get('TelefonoFacturacion')?.value;
    let DireccionFacturacion = this.facturacionForm.get('DireccionFacturacion')?.value;
    let CorreoElectronicoFacturacion = this.facturacionForm.get('CorreoElectronicoFacturacion')?.value;

    let cotizar : ICotizar = this.cotizar!;
    let productos : IProducto [] = this.carritoService.productos;
    let detalles : IDetalleOrden [] = [];
    let datospago : IDatosPago [] = [];

    let datopago : IDatosPago = {
      anoExpiracion : 25,
      codCV : CCV,
      codMoneda : cotizar.moneda ,
      email : CorreoElectronicoFacturacion ,
      medioPago : Number(medios),
      mesExpiracion : 1,
      nombreTitular : CCtitular,
      numeroTarjeta : CCnumero,
      tipoTarjeta : CCtipo
    }
    datospago.push(datopago);

    for( let item of productos ) {
      let detalle : IDetalleOrden = {
        cantidadOrdenada : item.cantidad,
        codigoProducto : item.codigo,
        codigoProveedor : item.codigoProveedor,
        nombreProducto : item.nombre,
        precioUnitario : item.precio,
        productoId : item.id,
        tipoProveedor : item.tipoProveedor
      };
      detalles.push(detalle);
    }

    let fullOrden : IOrden = {      
      apellidoEnvio : ApellidoEnvio,
      carritoId : this.carritoService.CarritoExiste(),
      ciudadEnvio : CiudadEnvio,
      ciudadFacturacion : CiudadEnvio,
      codigoAreaEnvio : CodigoAreaEnvio,
      codigoAreaFacturacion : CodigoAreaEnvio,
      correoElectronicoFacturacion : CorreoElectronicoFacturacion,
      datosPago : datospago,
      detallesOrden : detalles,
      direccionEnvio : DireccionEnvio,
      direccionFacturacion : DireccionFacturacion,
      emailCliente : CorreoElectronicoFacturacion,
      estadoEnvio : CiudadEnvio,
      estadoFacturacion : CiudadEnvio,
      id : 0,
      nombreEnvio : NombreEnvio,
      numeroDocumentoCliente : NumeroDocumentoCliente,
      paisEnvio : this.carritoService.pais,
      paisFacturacion : this.carritoService.pais,
      precioTotal : cotizar.total,
      telefonoEnvio : TelefonoEnvio,
      telefonoFacturacion : TelefonoFacturacion,
      tipoDocumentoCliente : 'CC',
      valorImpuestos : cotizar.impuesto,
      
      estado : '',
      fechaCreacion : ''
    }

    this.pensando = true;
    this.ordenService.colocarOrden( fullOrden ).subscribe( data=> {        
      if( data.ordenId > 0 ) {
        this.carritoService.limpiar().subscribe(datalimpiar => {});
        fullOrden.id = data.ordenId;
        this.ordenService.persistir( fullOrden );
        this.router.navigateByUrl('/orden-creada');
      }
      this.pensando = false;
    },
    error => {
      window.alert( 'Ocurrio un error al guardar la orden' );
      this.pensando = false;
    }
    );

  }

}
