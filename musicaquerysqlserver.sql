create database Musica;
use Musica;

create table Usuarios (
IdUsuario int NOT NULL identity Primary Key,
NombreUsuario varchar(30),
CategoriaUsuario varchar(30),
ContraseñaUsuario varchar(60),
IdSucursal_FK int)

create table Compras(
IdCompra int not null identity primary key,
NumeroCompra int,
Descripcion varchar(600),
FechaCompra date,
IdUsuario_FK int,
IdImpuesto_FK int,
IdProveedor_FK int)

create table Fabricantes(
IdFabricante int not null identity primary key,
NombreFabricante varchar(60),
EstadoFabricante varchar(20),
FechaInicio date,
FechaFin date);

Create Table Productos(
IdProducto int not null identity primary key,
NombreProducto varchar(60),
ModeloProducto varchar(30),
ColorProducto varchar(20),
CantidadProducto int,
EstadoProducto varchar(20),
PrecioProducto int,
NumeroSerie varchar(60),
IdFabricante_FK int,
IdProveedor_FK int,
IdReporte_FK int,
IdSucursal_FK int)
--FOREIGN KEY (IdFabricante_FK) REFERENCES Fabricantes(IdFabricante),
--FOREIGN KEY (IdProveedor_FK) REFERENCES Proveedores(IdProveedor),
--FOREIGN KEY (IdReporte_FK) REFERENCES Reportes(IdReporte),
--FOREIGN KEY (IdSucursal_FK) REFERENCES Sucursal(IdSucursal));

Create Table Proveedores(
IdProveedor int not null identity primary key,
NombreEmpresa varchar(60),
SitioWeb varchar (100),
Telefono varchar (30),
NombreContacto varchar(60),
ApellidoContacto varchar(60),
Email varchar(60),
Calle varchar(60),
CP varchar(10));

Create Table Sucursal(
IdSucursal int not null identity primary key,
NombreSucursal varchar(60));

Create Table Impuestos(
IdImpuesto int not null identity primary key,
NombreImpuesto varchar(60),
ValorImpuesto int);

Create Table Reportes(
IdReporte int not null identity primary key,
FechaReporte date,
TipoReporte varchar (20));

Create Table Reparaciones(
IdReparacion int not null identity primary key,
EstadoReparacion varchar(20),
Descripcion varchar(600),
AccionRealizar varchar(30),
ManoDeObra int,
Precio int,
IdProductoRep_FK int,
IdUsuario_FK int)
--FOREIGN KEY (IdProductoRep_FK) REFERENCES ProductoReparacion(IdProductoRep),
--FOREIGN KEY (IdUsuario_FK) REFERENCES Usuario(IdUsuario));

create table ProductoReparacion(
IdProductoRep int not null identity primary key,
DniCliente varchar(10),
ProductoReparacion varchar(20),
FabricanteReparacion varchar(20),
ModeloProducto varchar(30),
EstadoIngreso varchar(20),
NumeroSerie varchar(60),
FechaIngreso date,
FechaEgreso date);

create table Ciudad(
IdCiudad int not null identity primary key,
NombreCiudad varchar(30));

-------------------------------------FOREIGN KEYS------------------------------------------------
ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuarios_Sucursal
foreign key (IdSucursal_FK)
references Sucursal(IdSucursal)

ALTER TABLE Compras
ADD CONSTRAINT FK_Usuarios_Compras
foreign key (IdUsuario_FK)
references Usuarios(IdUsuario)

ALTER TABLE Compras
ADD CONSTRAINT FK_Impuestos_Compras
foreign key (IdImpuesto_FK)
references Impuestos(IdImpuesto)

ALTER TABLE Compras
ADD CONSTRAINT FK_Proveedores_Compras
foreign key (IdProveedor_FK)
references Proveedores(IdProveedor)

ALTER TABLE Productos
ADD CONSTRAINT FK_Fabricantes_Productos
foreign key (IdFabricante_FK)
references Fabricantes(IdFabricante)

ALTER TABLE Productos
ADD CONSTRAINT FK_Proveedores_Productos
foreign key (IdProveedor_FK)
references Proveedores(IdProveedor)

ALTER TABLE Productos
ADD CONSTRAINT FK_Reportes_Compras
foreign key (IdReporte_FK)
references Reportes(IdReporte)

ALTER TABLE Productos
ADD CONSTRAINT FK_Sucursal_Compras
foreign key (IdSucursal_FK)
references Sucursal(IdSucursal)

ALTER TABLE Reparaciones
ADD CONSTRAINT FK_ProductoRep_Compras
foreign key (IdProductoRep_FK)
references ProductoReparacion(IdProductoRep)

ALTER TABLE Reparaciones
ADD CONSTRAINT FK_Usuario_Compras
foreign key (IdUsuario_FK)
references Usuarios(IdUsuario)

