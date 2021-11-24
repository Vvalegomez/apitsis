Create Database Musica
go

use Musica
go

Create Table Sucursales
(
suc_codigo INT not null primary key,
suc_denom VARCHAR(50) not null
)

Create Table Paises
(
pais_codigo INT not null primary key,
pais_denom VARCHAR(30) not null,
)

Create Table Provincias
(
prov_codigo INT not null primary key, 
prov_denom VARCHAR(30) not null,
pais_codigo INT,
FOREIGN KEY (pais_codigo) REFERENCES PAISES(pais_codigo)
)

Create Table Ciudades
(
ciu_codigo INT not null primary key,
ciu_denom VARCHAR(30) not null,
prov_codigo INT,
FOREIGN KEY (prov_codigo) REFERENCES PROVINCIAS(prov_codigo)
)

Create Table ReportesTipos
(
reptipo_codigo INT not null primary key,
reptipo_denom VARCHAR(30) not null
)

Create Table Estados
(
esta_codigo INT not null primary key,
esta_denom VARCHAR(30) not null
)

Create Table Modelos
(
mod_codigo INT not null primary key,
mod_denom VARCHAR(30) not null,
esta_codigo INT not null,
FOREIGN KEY (esta_codigo) REFERENCES ESTADOS(esta_codigo)
)

Create Table Niveles 
(
niv_codigo INT not null primary key,
niv_denom VARCHAR(30),
esta_codigo INT not null,
FOREIGN KEY (esta_codigo) REFERENCES ESTADOS(esta_codigo)
)

Create Table Usuarios
(
usu_codigo INT not null primary key,
usu_user VARCHAR(30) not null,
usu_pass VARCHAR(30) not null,
niv_codigo INT not null,
suc_codigo INT not null,
esta_codigo INT not null,
FOREIGN KEY (suc_codigo) REFERENCES SUCURSALES(suc_codigo),
FOREIGN KEY (niv_codigo) REFERENCES NIVELES(niv_codigo),
FOREIGN KEY (esta_codigo) REFERENCES ESTADOS(esta_codigo)
)

Create Table Fabricantes
(
fab_codigo INT not null primary key,
fab_denom VARCHAR(30) not null,
fab_feccar DATE,
esta_codigo INT not null,
FOREIGN KEY (esta_codigo) REFERENCES Estados(esta_codigo)
)
 
Create Table Proveedores
(
prove_codigo INT not null primary key,
prove_denom VARCHAR(50) not null,
prove_website VARCHAR(50),
prove_telefono VARCHAR(20),
prove_mail VARCHAR(30),
prove_direccion VARCHAR(50),
prove_cp VARCHAR(5),
ciu_codigo INT not null,
esta_codigo INT not null,
FOREIGN KEY (ciu_codigo) REFERENCES Ciudades(ciu_codigo),
FOREIGN KEY (esta_codigo) REFERENCES Estados(esta_codigo)
)

Create Table Impuestos
(
imp_codigo INT not null primary key,
imp_denom VARCHAR(30) not null,
imp_valor INT not null,
esta_codigo INT not null,
FOREIGN KEY (esta_codigo) REFERENCES ESTADOS(esta_codigo)
)

Create Table Reportes
(
rep_codigo INT not null primary key,
rep_fecha DATE not null,
reptipo_codigo INT null,
rep_observ VARCHAR(200),
suc_codigo INT not null,
FOREIGN KEY (suc_codigo) REFERENCES Sucursales(suc_codigo),
FOREIGN KEY (reptipo_codigo) REFERENCES ReportesTipos(reptipo_codigo)
)

Create Table ReportesDet
(
rep_codigo INT not null primary key,
art_codigo INT not null,
cue_codigo INT not null,
rep_cantidad INT null,
rep_total INT null,
FOREIGN KEY (rep_codigo) REFERENCES Reportes(rep_codigo),
)

Create Table Cuentas
(
cue_codigo INT not null primary key,
cue_denom VARCHAR(40) not null,
cue_website VARCHAR(50),
cue_telefono VARCHAR(20),
cue_mail VARCHAR(30),
cue_direccion VARCHAR(50),
cue_cp VARCHAR(5),
ciu_codigo INT not null,
esta_codigo INT not null,
FOREIGN KEY (ciu_codigo) REFERENCES Ciudades(ciu_codigo),
FOREIGN KEY (esta_codigo) REFERENCES Estados(esta_codigo)
)

Create Table Articulos
(
art_codigo INT not null primary key,
art_denom VARCHAR(50) not null,
esta_codigo INT not null,
FOREIGN KEY (esta_codigo) REFERENCES Estados(esta_codigo)
)

Create Table ArticulosDet
(
art_codigo INT not null primary key,
art_color VARCHAR(20) null,
art_precio INT null,
fab_codigo INT not null,
suc_codigo INT not null,
prove_codigo INT,
mod_codigo INT
FOREIGN KEY (art_codigo) REFERENCES Articulos(art_codigo),
FOREIGN KEY (fab_codigo) REFERENCES Fabricantes(fab_codigo),
FOREIGN KEY (suc_codigo) REFERENCES Sucursales(suc_codigo),
FOREIGN KEY (prove_codigo) REFERENCES Proveedores(prove_codigo),
FOREIGN KEY (mod_codigo) REFERENCES Modelos(mod_codigo)
)

Create Table Reparaciones
(
repa_codigo INT not null primary key,
repa_feccar DATE not null,
repa_feccie DATE not null,
cue_codigo INT not null,
esta_codigo INT not null,
repa_observ VARCHAR(200),
FOREIGN KEY (esta_codigo) REFERENCES Estados(esta_codigo),
FOREIGN KEY (cue_codigo) REFERENCES Cuentas(cue_codigo)
)

Create Table ReparacionesDet
(
repa_codigo INT not null primary key,
art_codigo INT null,
repad_precio INT,
repad_accion VARCHAR(200)
FOREIGN KEY (repa_codigo) REFERENCES Reparaciones(repa_codigo),
FOREIGN KEY (art_codigo) REFERENCES Articulos(art_codigo)
)

Create Table Compras
(
com_codigo INT not null primary key, 
com_numerofisico VARCHAR(20),
com_observ VARCHAR(200),
com_fecha DATE,
usu_codigo INT
FOREIGN KEY (usu_codigo) REFERENCES Usuarios(usu_codigo)
)

Create Table ComprasDet
(
com_codigo INT not null primary key,
art_codigo INT not null,
imp_codigo INT,
comd_total INT
FOREIGN KEY (com_codigo) REFERENCES Compras(com_codigo),
FOREIGN KEY (art_codigo) REFERENCES Articulos(art_codigo),
FOREIGN KEY (imp_codigo) REFERENCES Impuestos(imp_codigo)
)

