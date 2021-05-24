# Building stage
FROM maven:3.6.2-jdk-11-slim AS builder
WORKDIR /build
COPY pom.xml .
COPY ./src ./src
RUN mvn clean package -Dmaven.test.skip=true

# Shrinking stage
FROM openjdk:11.0.6-jdk-slim-buster AS shrinking
WORKDIR /shrink
COPY --from=builder /build/target/transportadores-pica-1.0.0-SNAPSHOT.jar  .
RUN jlink --no-header-files --no-man-pages --add-modules $(jdeps --print-module-deps transportadores-pica-1.0.0-SNAPSHOT.jar),jdk.unsupported,jdk.management,java.sql,java.rmi,java.naming,java.desktop,java.security.jgss --output jvm

# Running stage
FROM debian:stretch-slim
WORKDIR /app
COPY --from=builder /build/target/transportadores-pica-1.0.0-SNAPSHOT.jar ./transportadores-pica.jar
#COPY --from=builder /build/target/lib ./lib
COPY --from=shrinking /shrink/jvm ./jvm
EXPOSE 8080
USER 1001
ENTRYPOINT ["jvm/bin/java", "-jar", "transportadores-pica.jar"]