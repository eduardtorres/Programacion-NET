import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
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
    private router: Router,
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
      if(data)
      {
      if( data.idCliente > 0 )
      {
        window.alert('Regstro exitoso , proceda al login');
        this.router.navigateByUrl('/login');
      }
      else
      {
        window.alert('Ocurrio un error durante el registro');
      }
    }
    else{
      window.alert('Ocurrio un error durante el registro');
    }
    },    
    error => {
      window.alert('Ocurrio un error durante el registro');
    });

  }

}
