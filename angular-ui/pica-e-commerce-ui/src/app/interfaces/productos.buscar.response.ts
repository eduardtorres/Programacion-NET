
export interface  IProducto  {
        id : number;
        codigo : string;
        nombre : string;
        precio : number;
    }

export interface IBuscarProductosResponse {
    productos : IProducto[];
}