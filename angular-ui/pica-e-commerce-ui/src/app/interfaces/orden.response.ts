export interface IOrden {
    Id : number;
    PrecioTotal: number;
    ValorImpuestos : number;
    NumeroDocumentoCliente : string;
    TipoDocumentoCliente : string;
    EmailCliente : string;
    DireccionFacturacion: string;
    CiudadFacturacion : string;
    EstadoFacturacion : string;
    PaisFacturacion : string;
    CodigoAreaFacturacion : string;
    CorreoElectronicoFacturacion : string;
    TelefonoFacturacion : string;
    DireccionEnvio : string;
    CiudadEnvio : string;
    EstadoEnvio : string;
    PaisEnvio : string;
    CodigoAreaEnvio : string;
    NombreEnvio : string;
    ApellidoEnvio : string;
    TelefonoEnvio : string;
    CarritoId : number;

    DetallesOrden : IDetalleOrden [];

    DatosPago : IDatosPago [];
}

export interface IDatosPago {
            MedioPago : number;
            CodMoneda : string;
            NumeroTarjeta: string;
            MesExpiracion: number;
            AnoExpiracion: number;
            CodCV: string;
            TipoTarjeta: string;
            NombreTitular: string;
            Email: string;
}

export interface IDetalleOrden {
    ProductoId : number;
    CodigoProducto : string;
    CantidadOrdenada : number;
    PrecioUnitario: number;
    CodigoProveedor: string;
    TipoProveedor : string;
    NombreProducto : string;
}

export interface IMedioPago {
    id : number;
    desMedioPago : string;
}

export interface IOrdenResponse {
    ordenId : number;
}