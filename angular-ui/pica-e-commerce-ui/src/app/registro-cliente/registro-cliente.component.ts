import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ICliente } from '../interfaces/cliente.response';
import { ClienteService } from '../services/cliente.service';

@Component({
  selector: 'app-registro-cliente',
  templateUrl: './registro-cliente.component.html',
  styleUrls: ['./registro-cliente.component.css']
})
export class RegistroClienteComponent implements OnInit {
  
  registroForm = this.formBuilder.group({
    nombre: '',
    direccion: '',
    nit: '',
    telefono: '',
    email: '',
    password: ''
  });

  constructor(private formBuilder: FormBuilder,
    private clienteService: ClienteService) { 
  }

  ngOnInit(): void {

  }

  onRegistroSubmit() : void {

    let nombre = this.registroForm.get('nombre')?.value;
    let direccion = this.registroForm.get('direccion')?.value;
    let nit = this.registroForm.get('nit')?.value;
    let telefono = this.registroForm.get('telefono')?.value;
    let email = this.registroForm.get('email')?.value;
    let password = this.registroForm.get('password')?.value;

    let cliente : ICliente = {
      idCliente : 0,
      nombre : nombre,
      direccion : direccion,
      nit : nit,
      telefono : telefono,
      userName : email,
      password : password
    }

    this.clienteService.registrar( cliente ).subscribe(data=>{
      if( data.idCliente > 0 )
      {
        window.alert('Regstro exitoso');
      }
      else
      {
        window.alert('Ocurrio un error durante el registro');
      }
    });

  }

}
