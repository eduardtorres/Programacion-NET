export interface ICliente {
    idCliente : string;
    nombre : string;
    direccion : string;
    nit : string;
    telefono : string;
    userName : string;
}

export interface IAutenticar {
    code : number,
    token : string,
    cliente : ICliente
}