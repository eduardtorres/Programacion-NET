import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class Configuracion {
    
    urlServicio : string = "https://hayi88qmck.execute-api.us-east-2.amazonaws.com/Prod"

    constructor() {        
    }

    obtenerStringAleatoria() {
      let max = 1000000000;
      let min = 100000000;
      return (Math.floor(Math.random() * (max - min + 1)) + min).toString();
    }
}