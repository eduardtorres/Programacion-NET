import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { BuscarProductoComponent } from './buscar-producto/buscar-producto.component';
import { DetalleProductoComponent } from './detalle-producto/detalle-producto.component';
import { LoginClienteComponent } from './login-cliente/login-cliente.component';
import { DetalleCarritoComponent } from './detalle-carrito/detalle-carrito.component';
import { PagarOrdenComponent } from './pagar-orden/pagar-orden.component';
import { RegistroClienteComponent } from './registro-cliente/registro-cliente.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { OrdenCreadaComponent } from './orden-creada/orden-creada.component';
import { OrdenesClienteComponent } from './ordenes-cliente/ordenes-cliente.component'; 

@NgModule({
  imports: [
    FormsModule,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: BuscarProductoComponent },
      { path: 'productos/:id', component: DetalleProductoComponent },
      { path: 'login', component: LoginClienteComponent },
      { path: 'carrito', component: DetalleCarritoComponent },
      { path: 'pagar', component: PagarOrdenComponent },
      { path: 'registro', component: RegistroClienteComponent },
      { path: 'orden-creada', component: OrdenCreadaComponent },
      { path: 'ordenes-cliente', component: OrdenesClienteComponent }
    ]),
    BrowserAnimationsModule,
    MatProgressSpinnerModule
  ],
  declarations: [
    AppComponent,
    TopBarComponent,
    BuscarProductoComponent,
    DetalleProductoComponent,
    LoginClienteComponent,
    DetalleCarritoComponent,
    PagarOrdenComponent,
    RegistroClienteComponent,
    OrdenCreadaComponent,
    OrdenesClienteComponent
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/