
export interface  IProducto  {
        id : number;
        codigo : string;
        nombre : string;
        categoria : string;
        urlImagen : string;
        descripcion : string;
        disponibilidad : string;
        precio : number;
        moneda : string;
        cantidad : number;
        tipoProveedor : string;
        codigoProveedor : string;
        fabricante : string;
        carritoId : number;
    }


export interface ICarrito {
    id : number;
    pais : string;
    usuario : string;
}

export interface IRespuesta {
    codigo : number;
    mensaje : string;
}

export interface ICotizar {
    unidades : number;
    neto : number;
    impuesto : number;
    transporte : number;
    total : number;
    moneda : string;
}