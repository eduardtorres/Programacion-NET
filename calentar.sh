#!/bin/bash
echo "mock productos"
curl https://nox60j22ea.execute-api.us-east-2.amazonaws.com/dev/catalog/products
echo "mock procesar pago"
curl -XPOST https://lyij8v9c2a.execute-api.us-east-2.amazonaws.com/Prod/ProveedorPagos/ProcesarPago -d "{}"
echo "broker"
curl -XPOST https://hayi88qmck.execute-api.us-east-2.amazonaws.com/Prod/broker/orden/colocar -d "{}"
echo "Precio"
curl https://hayi88qmck.execute-api.us-east-2.amazonaws.com/Prod/precio/tasa/obtener/COP
echo "Pago"
curl https://hayi88qmck.execute-api.us-east-2.amazonaws.com/Prod/pago/medios/obtener
echo "Productos"
curl https://hayi88qmck.execute-api.us-east-2.amazonaws.com/Prod/producto/listado/obtener/CLP/o
echo "Carrito"
curl https://hayi88qmck.execute-api.us-east-2.amazonaws.com/Prod/carrito/get/all
echo "Clientes"
curl https://hayi88qmck.execute-api.us-east-2.amazonaws.com/Prod/cliente/listar
echo "Ordenes"
curl https://hayi88qmck.execute-api.us-east-2.amazonaws.com/Prod/orden