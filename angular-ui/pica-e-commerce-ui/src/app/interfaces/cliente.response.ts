export interface ICliente {
    idCliente : number;
    nombre : string;
    direccion : string;
    nit : string;
    telefono : string;
    userName : string;
    password : string;
}

export interface IAutenticar {
    code : number,
    token : string,
    cliente : ICliente
}