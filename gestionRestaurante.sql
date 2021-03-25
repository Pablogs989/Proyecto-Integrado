CREATE DATABASE Gestion_Restaurante DEFAULT CHARACTER SET UTF8;

USE Gestion_Restaurante;

CREATE TABLE empleado (
nombre VARCHAR(45) NOT NULL,
passwd INT NOT NULL,
tipoEmpleado INT NOT NULL,
PRIMARY KEY (nombre));

CREATE TABLE codigosDescuento (
idCodigo VARCHAR(45) NOT NULL,
PRIMARY KEY (idCodigo));

CREATE TABLE productos (
nombre VARCHAR(45) NOT NULL,
precio DOUBLE(4,2) NOT NULL,
tipoProducto VARCHAR(10) NOT NULL,
PRIMARY KEY (nombre));

CREATE TABLE clientes (
tlf VARCHAR(9) NOT NULL,
nombre VARCHAR(45) NOT NULL,
calle VARCHAR(45) NOT NULL,
bloque CHAR,
escalera CHAR,
portal VARCHAR(4) NOT NULL,
piso VARCHAR(3),
puerta VARCHAR(4) NOT NULL,
PRIMARY KEY (tlf));

CREATE TABLE pedidos (
numPedido INT NOT NULL,
nomCamarero VARCHAR(45) NOT NULL,
productos VARCHAR(45) NOT NULL,
fecha DATETIME NOT NULL,
precio DOUBLE(6,2) NOT NULL,
codDesc VARCHAR(45),
PRIMARY KEY (numPedido),
FOREIGN KEY (nomCamarero) REFERENCES empleado (nombre),
FOREIGN KEY (codDesc) REFERENCES codigosDescuento (idCodigo),
FOREIGN KEY (productos) REFERENCES productos (nombre));

CREATE TABLE sala (
numPedido INT NOT NULL,
mesa INT NOT NULL,
PRIMARY KEY (numPedido),
FOREIGN KEY (numPedido) REFERENCES pedidos (numPedido));

CREATE TABLE llevar (
numPedido INT NOT NULL,
nomCliente VARCHAR(45) NOT NULL,
numTlf VARCHAR(9) NOT NULL,
PRIMARY KEY (numPedido),
FOREIGN KEY (numPedido) REFERENCES pedidos (numPedido));

CREATE TABLE domicilio (
numPedido INT NOT NULL,
clienteTLF VARCHAR(9) NOT NULL,
PRIMARY KEY (numPedido),
FOREIGN KEY (numPedido) REFERENCES pedidos (numPedido),
FOREIGN KEY (clienteTLF) REFERENCES clientes (tlf));