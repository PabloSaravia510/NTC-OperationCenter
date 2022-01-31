use master
GO

create database NTC_OperationCenter
go

use NTC_OperationCenter
go

CREATE TABLE TB_EQUIPO (
Id_Equipo int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_USUARIO(
Id_Usuario  int primary key identity(1,1) not null,
Nombres varchar(250) not null,
Apellidos varchar(250) not null,
Username varchar(16) not null,
Password varchar(8) not null,
Id_Categoria int not null,
Id_Equipo int not null
)

CREATE TABLE TB_CATEGORIA (
Id_Categoria int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_SOLICITUD(
Id_Solicitud int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_ESTADO(
Id_Estado int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO


CREATE TABLE TB_ACCESOAPLICATIVOS(
Id_AccesoApp int primary key identity(1,1) not null,
Id_Equipo int not null,
Id_Usuario int not null,
Id_Solicitud int not null,
Estado varchar(50) not null,
tk_referencia varchar(50)  null,
Descripcion varchar (500) not null,
Id_Responsable int not null
)
GO

create table TB_RESPONSABLE(
Id_Responsable int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO


/* -----------------PASES A PRODUCCION--------------- */
--- AREA = EQUIPO   SOLICITANTE = USUARIO

CREATE TABLE TB_TIPO_PASE(   
Id_TpPase int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_ORIGEN(    
Id_Origen int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_SISTEMA(  
Id_Sistema int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

/*--------*/
CREATE TABLE TB_SERVIDOR_DEV(
Id_ServidorDev int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_TIPO_OBJ(
Id_TpObj int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_PROYECTO( -----tipoProyecto
Id_Proyecto int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO


CREATE TABLE TB_RUTA_PASE(
Id_RT_Pase int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO


CREATE TABLE TB_DETALLE_PASES_PRODUCCION(
ID_Det_PaseProduc int primary key identity(1,1) not null,
Id_RT_Pase int not null,
Id_ServidorDev int not null,
Id_TpObj int not null,
Id_Proyecto int not null,
Servidor_Dest varchar(25) not null
)
GO

/*--------*/

CREATE TABLE TB_APROBADORES( 
Id_Aprobador int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_PROVEEDOR(   
Id_Proveedor int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_PASES_PRODUCCION(
Id_PasesProduc int primary key identity(1,1) not null,
Id_TpPase int not null,
Id_Origen  int not null,
Tk_referencia varchar (50) not null,
Id_Equipo int not null,
Id_Proveedor int not null,
Id_Usuario int not null,
Id_Sistema int not null,
ID_Det_PaseProduc int not null,
Modulo_Sistema varchar(550) not null,
Motivo  varchar(550) not null,
Fec_Solicitud datetime not null,
Fec_Ejecucion datetime not null,
Hora_Ejecucion datetime not null,
Observaciones varchar(600) not null,
Id_Aprobador int not null,
Id_Responsable int not null
)
GO

/* -----------------GESTION ACCESOS--------------- */
CREATE TABLE TB_SOLICITANTE_GA(
Id_Solicitante_GA int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_AREA_GA(
Id_Area_GA int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_SEDE_GA(
Id_Sede_GA int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_SERVICIO_GA(
Id_Servicio_GA int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO


CREATE TABLE TB_APROBADORES_GA( 
Id_Aprobadores_GA int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_TIPO_GA( 
Id_Tipo_GA int primary key identity(1,1) not null,
Descripcion varchar(50) not null
)
GO

CREATE TABLE TB_GESTION_ACCESOS(
Id_GestionAcceso int primary key identity(1,1) not null,
FechaHora datetime not null,
Id_Solicitante_GA int not null,
NombreUsuario varchar(250) not null,
Id_Area_GA int not null,
Id_Sede_GA int not null,
Id_Servicio_GA int not null,
DetalleSolicitud varchar(500) not null,
Id_Aprobadores_GA int not null,
Id_Tipo_GA int not null,
ReferenciaTK varchar(50)  not null,
Id_Responsable int not null,
Username varchar(50) not null,
PerfilSimilar varchar(50) not null,
Observaciones varchar(500) not null
)
GO


---------------------------CONSTRAINT----------------------------------
ALTER TABLE TB_ACCESOAPLICATIVOS
ADD CONSTRAINT FK_Acceso_Equipo FOREIGN KEY (Id_Equipo) REFERENCES TB_EQUIPO(Id_Equipo);

ALTER TABLE TB_ACCESOAPLICATIVOS
ADD CONSTRAINT FK_Acceso_Solicitud FOREIGN KEY (Id_Solicitud) REFERENCES TB_SOLICITUD(Id_Solicitud);

ALTER TABLE TB_ACCESOAPLICATIVOS
ADD CONSTRAINT FK_Acceso_Usuario FOREIGN KEY (Id_Usuario) REFERENCES TB_USUARIO(Id_Usuario);


/* --------------------------- */
ALTER TABLE TB_PASES_PRODUCCION
ADD CONSTRAINT FK_PaseProduc_TpPase FOREIGN KEY (Id_TpPase) REFERENCES TB_TIPO_PASE(Id_TpPase);

ALTER TABLE TB_PASES_PRODUCCION
ADD CONSTRAINT FK_PaseProduc_Origen FOREIGN KEY (Id_Origen) REFERENCES TB_ORIGEN(Id_Origen);

ALTER TABLE TB_PASES_PRODUCCION
ADD CONSTRAINT FK_PaseProduc_Equipo FOREIGN KEY (Id_Equipo) REFERENCES TB_EQUIPO(Id_Equipo);

ALTER TABLE TB_PASES_PRODUCCION
ADD CONSTRAINT FK_PaseProduc_Proveedor FOREIGN KEY (Id_Proveedor) REFERENCES TB_PROVEEDOR(Id_Proveedor);

ALTER TABLE TB_PASES_PRODUCCION
ADD CONSTRAINT FK_PaseProduc_Sistema FOREIGN KEY (Id_Sistema) REFERENCES TB_SISTEMA(Id_Sistema);

ALTER TABLE TB_PASES_PRODUCCION
ADD CONSTRAINT FK_PaseProduc_Aprobador FOREIGN KEY (Id_Aprobador) REFERENCES TB_APROBADORES(Id_Aprobador);

ALTER TABLE [dbo].[TB_PASES_PRODUCCION]
ADD CONSTRAINT FK_PaseProduc_Responsable FOREIGN KEY (Id_Responsable) REFERENCES TB_RESPONSABLE(Id_Responsable);

ALTER TABLE [TB_PASES_PRODUCCION]
ADD CONSTRAINT FK_PaseProduc_Usuario FOREIGN KEY (Id_Usuario) REFERENCES TB_USUARIO(Id_Usuario);

ALTER TABLE [TB_PASES_PRODUCCION]
ADD CONSTRAINT FK_PaseProduc_DetPaseProduc FOREIGN KEY (ID_Det_PaseProduc) REFERENCES TB_DETALLE_PASES_PRODUCCION(ID_Det_PaseProduc);

/* --------------------------- */
ALTER TABLE TB_USUARIO
ADD CONSTRAINT FK_Usu_Cate FOREIGN KEY (Id_Categoria) REFERENCES TB_CATEGORIA(Id_Categoria);

ALTER TABLE TB_USUARIO
ADD CONSTRAINT FK_Usu_Equipo FOREIGN KEY (Id_Equipo) REFERENCES TB_EQUIPO(Id_Equipo);


/* --------------------------- */
ALTER TABLE TB_GESTION_ACCESOS
ADD CONSTRAINT FK_Gestion_Solicitante FOREIGN KEY (Id_Solicitante_GA) REFERENCES TB_SOLICITANTE_GA(Id_Solicitante_GA);

ALTER TABLE TB_GESTION_ACCESOS
ADD CONSTRAINT FK_Gestion_Area FOREIGN KEY (Id_Area_GA) REFERENCES TB_AREA_GA(Id_Area_GA);

ALTER TABLE TB_GESTION_ACCESOS
ADD CONSTRAINT FK_Gestion_Sede FOREIGN KEY (Id_Sede_GA) REFERENCES TB_SEDE_GA(Id_Sede_GA);

ALTER TABLE TB_GESTION_ACCESOS
ADD CONSTRAINT FK_Gestion_Servicio FOREIGN KEY (Id_Servicio_GA) REFERENCES TB_SERVICIO_GA(Id_Servicio_GA);

ALTER TABLE TB_GESTION_ACCESOS
ADD CONSTRAINT FK_Gestion_Aprobadores FOREIGN KEY (Id_Aprobadores_GA) REFERENCES TB_APROBADORES_GA(Id_Aprobadores_GA);

ALTER TABLE TB_GESTION_ACCESOS
ADD CONSTRAINT FK_Gestion_Tipo FOREIGN KEY (Id_Tipo_GA) REFERENCES TB_TIPO_GA(Id_Tipo_GA);

ALTER TABLE TB_GESTION_ACCESOS
ADD CONSTRAINT FK_Gestion_Responsable FOREIGN KEY (Id_Responsable) REFERENCES TB_RESPONSABLE(Id_Responsable);

