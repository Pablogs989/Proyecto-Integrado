
CREATE DATABASE Gestion_Restaurante DEFAULT CHARACTER SET UTF8;

USE Gestion_Restaurante;


CREATE TABLE mesas
(nMesa INT NOT NULL,
PRIMARY KEY (nMesa));

CREATE TABLE empleado
(nombre VARCHAR(45) NOT NULL,
passwd VARCHAR(5) NOT NULL,
tipoEmpleado INT NOT NULL,
PRIMARY KEY (nombre));

CREATE TABLE codigosdescuento
(idCodigo VARCHAR(45) NOT NULL,
porcentaje INT NOT NULL,
PRIMARY KEY (idCodigo));

CREATE TABLE entrantes 
(nombre VARCHAR(45) NOT NULL,
precio DOUBLE(4,2) NOT NULL,
PRIMARY KEY (nombre));

CREATE TABLE bebidas
(nombre VARCHAR(45) NOT NULL,
precio DOUBLE(4,2) NOT NULL,
PRIMARY KEY (nombre));

CREATE TABLE postres
(nombre VARCHAR(45) NOT NULL,
precio DOUBLE(4,2) NOT NULL,
PRIMARY KEY (nombre));

CREATE TABLE clientes
(tlf VARCHAR(9) NOT NULL,
nombre VARCHAR(45) NOT NULL,
calle VARCHAR(45) NOT NULL,
bloque CHAR,
escalera CHAR,
portal VARCHAR(4) NOT NULL,
piso VARCHAR(3),
puerta VARCHAR(4),
PRIMARY KEY (tlf));

CREATE TABLE pizzas
(idPizza INT NOT NULL AUTO_INCREMENT,
sabor VARCHAR(45) NOT NULL,
tamanyo VARCHAR(45) NOT NULL,
masa VARCHAR(45) NOT NULL,
PRIMARY KEY (idPizza));

CREATE TABLE pedidos
(numPedido INT NOT NULL,
nomCamarero VARCHAR(45) NOT NULL,
fecha DATETIME NOT NULL,
precio DOUBLE(6,2) NOT NULL,
codDesc VARCHAR(45),
cancelado BOOL NOT NULL,
PRIMARY KEY (numPedido),
FOREIGN KEY (nomCamarero) REFERENCES empleado (nombre),
FOREIGN KEY (codDesc) REFERENCES codigosDescuento (idCodigo));

CREATE TABLE pizza_pedido
(idPizza INT,
nPedido INT,
FOREIGN KEY (idPizza) REFERENCES pizzas (idPizza),
FOREIGN KEY (nPedido) REFERENCES pedidos (numPedido));

CREATE TABLE entrante_pedido
(nomEntrante VARCHAR(45),
nPedido INT,
FOREIGN KEY (nomEntrante) REFERENCES entrantes (nombre),
FOREIGN KEY (nPedido) REFERENCES pedidos (numPedido));

CREATE TABLE postre_pedido
(nomPostre VARCHAR(45),
nPedido INT,
FOREIGN KEY (nomPostre) REFERENCES postres (nombre),
FOREIGN KEY (nPedido) REFERENCES pedidos (numPedido));

CREATE TABLE bebida_pedido
(nomBebida VARCHAR(45),
nPedido INT,
FOREIGN KEY (nomBebida) REFERENCES bebidas (nombre),
FOREIGN KEY (nPedido) REFERENCES pedidos (numPedido));

CREATE TABLE sala 
(numPedido INT NOT NULL,
mesa INT NOT NULL,
PRIMARY KEY (numPedido),
FOREIGN KEY (numPedido) REFERENCES pedidos (numPedido),
FOREIGN KEY (mesa) REFERENCES mesas (nMesa));

CREATE TABLE llevar 
(numPedido INT NOT NULL,
nomCliente VARCHAR(45) NOT NULL,
numTlf VARCHAR(9) NOT NULL,
PRIMARY KEY (numPedido),
FOREIGN KEY (numPedido) REFERENCES pedidos (numPedido));

CREATE TABLE domicilio
(numPedido INT NOT NULL,
clienteTLF VARCHAR(9) NOT NULL,
PRIMARY KEY (numPedido),
FOREIGN KEY (numPedido) REFERENCES pedidos (numPedido),
FOREIGN KEY (clienteTLF) REFERENCES clientes (tlf));