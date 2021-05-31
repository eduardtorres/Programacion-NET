export interface IOrden {
    id : number;
    precioTotal: number;
    valorImpuestos : number;
    numeroDocumentoCliente : string;
    tipoDocumentoCliente : string;
    emailCliente : string;
    direccionFacturacion: string;
    ciudadFacturacion : string;
    estadoFacturacion : string;
    paisFacturacion : string;
    codigoAreaFacturacion : string;
    correoElectronicoFacturacion : string;
    telefonoFacturacion : string;
    direccionEnvio : string;
    ciudadEnvio : string;
    estadoEnvio : string;
    paisEnvio : string;
    codigoAreaEnvio : string;
    nombreEnvio : string;
    apellidoEnvio : string;
    telefonoEnvio : string;
    carritoId : number;

    detallesOrden : IDetalleOrden [];

    datosPago : IDatosPago [];

    estado : string;
    fechaCreacion : string;
}

export interface IDatosPago {
            medioPago : number;
            codMoneda : string;
            numeroTarjeta: string;
            mesExpiracion: number;
            anoExpiracion: number;
            codCV: string;
            tipoTarjeta: string;
            nombreTitular: string;
            email: string;
}

export interface IDetalleOrden {
    productoId : number;
    codigoProducto : string;
    cantidadOrdenada : number;
    precioUnitario: number;
    codigoProveedor: string;
    tipoProveedor : string;
    nombreProducto : string;
    ordenProveedorId : number;
}

export interface IMedioPago {
    id : number;
    desMedioPago : string;
}

export interface IOrdenResponse {
    ordenId : number;
}

export interface ITransportador {
    id : number;
    nombre : string;
}

export interface IMunicipio {
    idCodDane : string;
    municipioDepartameto : string;
}

export interface IBuscarOrdenResponse {
    codigo : number;
    mensaje : string;
    ordenesByCliente : IOrden[];
}