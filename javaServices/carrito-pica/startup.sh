#!/bin/bash

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pass@word" --net mynet -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2019-latest

./mvnw package

docker build -f src/main/docker/Dockerfile.jvm -t quarkus/carrito-pica-jvm .

docker run -i --net mynet --rm -p 8081:8080 quarkus/carrito-pica-jvm



#docker build . -t pica/carrito-pica-img:1.0.0
#docker run -d -p 5001:8080 --name carrito-pica pica/carrito-pica-img:1.0.0