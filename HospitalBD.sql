create database HospitalBD
go
use HospitalBD
go
create table tbl_tipo_documento(
Id int primary key identity(1,1),
Nombre varchar(20)
)
go
create table tbl_genero(
Id int primary key identity(1,1),
Nombre varchar(10)
)
go
create table tbl_estado(
Id int primary key identity(1,1),
Nombre varchar(10)
)
go
create table tbl_paciente(
Id int primary key identity(1,1),
IdTipoIdentificacion int,
NumeroDocumento varchar(15),
Nombre varchar(100),
FechaNacimiento date,
CorreoElectronico varchar(100),
IdGenero int,
Direccion varchar(100),
NumeroTelefono varchar(10),
IdEstado int,
foreign key(IdTipoIdentificacion) references tbl_tipo_documento(Id),
foreign key(IdGenero) references tbl_genero(Id),
foreign key(IdEstado) references tbl_estado(Id),
)