import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FormBuilder } from '@angular/forms';
import { CarritoService } from '../services/carrito.service';
import { ClienteService } from '../services/cliente.service';

import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'; 

@Component({
  selector: 'app-login-cliente',
  templateUrl: './login-cliente.component.html',
  styleUrls: ['./login-cliente.component.css']
})

export class LoginClienteComponent implements OnInit {

  pensando : boolean = false;

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private carritoService : CarritoService,
    private clienteService : ClienteService ) { }

  loginForm = this.formBuilder.group({
    email: '',
    password: ''
  });

  ngOnInit(): void {
  }

  onLoginSubmit() {
    this.pensando = true;
    const email = this.loginForm.get('email')?.value;
    const password = this.loginForm.get('password')?.value;
    this.clienteService.autenticar( email, password ).subscribe( data => {
      if( data.code == 1 )
      {
        this.carritoService.ObtenerCarrito(email).subscribe(data2 => {
          this.pensando = false;
          console.warn('carrito:',data2.id);
          this.carritoService.persistir( data2 );
          this.router.navigateByUrl('/');
        });
        this.carritoService.persistirCliente(data.cliente);
      }
      else
      {
        window.alert("Usuario/Password Invalido");
        this.pensando = false;
      }
    });
  }

}
