/*------------------------------------------------------------------------------------*/

/* Script para reinicio de Indentity

DBCC CHECKIDENT (TB_RESPONSABLE, RESEED, 0)

*/------------------------------------------------------------------------------------*/

/*--------------------------------------INSERT---------------------------------------- */

--insert into TB_CATEGORIA values ('ADMINISTRATIVO')
--insert into TB_CATEGORIA values ('OPERADOR')
--insert into TB_CATEGORIA values ('SOPORTE')
--GO

--insert into TB_EQUIPO values ('NTC')
--insert into TB_USUARIO values ('JAVIER','ZULEN','JZULEN','123',1,1)
--GO

--INSERT INTO TB_RESPONSABLE values ('POR DEFINIR')
--GO

/*------------------------------------------------------------------------------------*/


/*------------------------------- SRI -----------------------------------------------------*/
CREATE PROCEDURE SP_ActualizarUsuarios
@idUsuario int,
@nombres varchar(250),
@apellidos varchar(250),
@username varchar(16),
@pwd varchar(8),
@idCategoria int,
@idEquipo int
AS
	update  [dbo].[TB_USUARIO]
	set Nombres = @nombres,
		Apellidos = @apellidos,
		Username = @username,
		Password = @pwd,
		Id_Categoria=@idCategoria,
		Id_Equipo = @idEquipo
	where Id_Usuario=@idUsuario
GO

CREATe PROCEDURE SP_EliminarUsuarios
@idUsuario int
AS
	delete from [dbo].[TB_USUARIO]
	where Id_Usuario=@idUsuario
GO


CREATE  PROCEDURE SP_InsertarUsuarios
@nombres varchar(250),
@apellidos varchar(250),
@username varchar(16),
@pwd varchar(8),
@idCategoria int,
@idEquipo int
AS
	insert into  [dbo].[TB_USUARIO] (Nombres,Apellidos,Username,Password, Id_Categoria,Id_Equipo)
	values (@nombres,@apellidos,@username,@pwd,@idCategoria,@idEquipo)
GO

CREATE  PROCEDURE SP_BuscarUsuarios
@idUsuario int
AS
	select Id_Usuario,Nombres,Apellidos,Username,Password,Id_Categoria,Id_Equipo
	from [dbo].[TB_USUARIO] 
	where Id_Usuario = @idUsuario
GO


CREATE PROCEDURE SP_ListarUsuarios
AS
	select Id_Usuario,Nombres,Apellidos,Username, c.Descripcion as Descripcion, e.Descripcion as Descripcion
	from [dbo].[TB_USUARIO] u 
	inner join TB_CATEGORIA c on c.Id_Categoria = u.Id_Categoria
	inner join TB_EQUIPO e on e.Id_Equipo = u.Id_Equipo
GO



CREATE  PROCEDURE SP_Login
@username varchar(16),
@pwd varchar(8)
AS
	select Id_Usuario,Nombres,Apellidos,Username,Password,Id_Categoria,u.Id_Equipo as Id_Equipo,e.Descripcion
	from [dbo].[TB_USUARIO] u
	inner join TB_EQUIPO e on e.Id_Equipo = u.Id_Equipo
	where Username = @username and Password =@pwd 
GO

/*------------------------------------------------------------------------------------*/
CREATE PROCEDURE SP_ListarCategorias
AS
	select Id_Categoria,Descripcion
	from TB_CATEGORIA 
GO

/*------------------------------------------------------------------------------------*/


CREATE PROCEDURE SP_ActualizarEquipo
@idEquipo int,
@descripcion varchar(50)
AS
	update TB_EQUIPO 
	set Descripcion = @descripcion
	where Id_Equipo=@idEquipo
GO

CREATe PROCEDURE SP_EliminarEquipo
@idEquipo int
AS
	delete from TB_EQUIPO
	where Id_Equipo=@idEquipo
GO


CREATE  PROCEDURE SP_InsertarEquipo
@descripcion varchar(50)
AS
	insert into TB_EQUIPO (Descripcion)
	values (@descripcion)
GO



CREATE  PROCEDURE SP_BuscarEquipo
@idEquipo int
AS
	select Id_Equipo,Descripcion
	from TB_EQUIPO
	where Id_Equipo = @idEquipo
GO


CREATE PROCEDURE SP_ListarEquipo
AS
	select Id_Equipo,Descripcion
	from TB_EQUIPO
GO

/*------------------------------------------------------------------------------------*/

CREATE  PROCEDURE SP_ListarSolicitante
AS
	select Id_Usuario,Nombres,Apellidos,e.Descripcion AS Descripcion
	from TB_USUARIO u
	inner join TB_EQUIPO e on e.Id_Equipo = u.Id_Equipo
	WHERE Id_Categoria = 3

GO

CREATE  PROCEDURE SP_ListarcboSolicitante
AS
	select Id_Usuario,concat(Nombres,' ',Apellidos) as Nombres
	from TB_USUARIO 

GO

/*------------------------------------------------------------------------------------*/

CREATE  PROCEDURE SP_ListarSolicitud
AS
	select Id_Solicitud,Descripcion
	from TB_SOLICITUD
GO

CREATE PROCEDURE SP_InsertarSolicitud
@descripcion varchar(50)
AS
	insert into TB_SOLICITUD(Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarSolicitud
@idSolicitud int,
@descripcion varchar(50)
AS
	update TB_SOLICITUD
	set Descripcion=@descripcion
	where Id_Solicitud=@idSolicitud
GO

CREATE PROCEDURE SP_EliminarSolicitud
@idSolicitud int
AS
	delete from TB_SOLICITUD
	where Id_Solicitud=@idSolicitud
GO
CREATE  PROCEDURE SP_BuscarSolicitud
@idSolicitud int
AS
	select Id_Solicitud,Descripcion
	from TB_SOLICITUD
	where Id_Solicitud=@idSolicitud
GO

/*------------------------------------------------------------------------------------*/

CREATE  PROCEDURE SP_ListarResponsable
AS
	select Id_Responsable,Descripcion
	from TB_RESPONSABLE
GO

CREATE PROCEDURE SP_InsertarResponsable
@descripcion varchar(50)
AS
	insert into TB_RESPONSABLE(Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarResponsable
@idResponsable int,
@descripcion varchar(50)
AS
	update TB_RESPONSABLE
	set Descripcion=@descripcion
	where Id_Responsable=@idResponsable
GO

CREATE PROCEDURE SP_EliminarResponsable
@idResponsable int
AS
	delete from TB_RESPONSABLE
	where Id_Responsable=@idResponsable
GO
CREATE  PROCEDURE SP_BuscarResponsable
@idResponsable int
AS
	select Id_Responsable,Descripcion
	from TB_RESPONSABLE
	where Id_Responsable=@idResponsable
GO

/*------------------------------------------------------------------------------------*/
CREATE  PROCEDURE SP_ListarAccesoApp
AS
	select  Id_AccesoApp,
			e.Descripcion as Equipo,
			so.Descripcion as Solicitud,
			a.Estado as Estado,
			[tk_referencia],
			a.[Descripcion]as Descripcion,
			r.Descripcion as Responsable,
			CONCAT(u.Nombres,' ',u.Apellidos) as Usuario
	from TB_ACCESOAPLICATIVOS a 
	inner join TB_EQUIPO e on e.Id_Equipo=a.Id_Equipo
	left join TB_SOLICITUD so on so.Id_Solicitud=a.Id_Solicitud
	left join TB_RESPONSABLE r on r.Id_Responsable = a.Id_Responsable
	left join TB_USUARIO u on u.Id_Usuario = a.Id_Usuario
GO


CREATE PROCEDURE SP_InsertarAccesoApp
@idequipo int,
@idsolicitud int,
@tk_referencia varchar(50),
@Descripcion varchar(500),
@idusuario int
AS 
	insert into TB_ACCESOAPLICATIVOS([Id_Equipo],Id_Usuario,[Id_Solicitud],Estado,[tk_referencia],[Descripcion],[Id_Responsable])
	values (@idequipo,@idusuario,@idsolicitud,'OPEN',@tk_referencia,@Descripcion,1)
GO

CREATE  PROCEDURE SP_ActualizarAccesoAppAdmin
@idAccesoApp int,
@idequipo int,
@idsolicitud int,
@tk_referencia varchar(50),
@Descripcion varchar(500),
@idresponsable int,
@idusuario int
AS
	update TB_ACCESOAPLICATIVOS
	set 
	Id_Equipo = @idequipo,
	Id_Usuario = @idusuario,
	Id_Solicitud = @idsolicitud,
	Estado = 'CLOSE',
	[tk_referencia] = @tk_referencia,
	[Descripcion] = @Descripcion,
	[Id_Responsable] = @idresponsable
	where Id_AccesoApp=@idAccesoApp
GO

CREATE  PROCEDURE SP_ActualizarAccesoApp
@idAccesoApp int,
@idresponsable int
AS
	update TB_ACCESOAPLICATIVOS
	set 
	Estado = 'CLOSE',
	[Id_Responsable] = @idresponsable
	where Id_AccesoApp=@idAccesoApp
GO


CREATE PROCEDURE SP_EliminarAccesoApp
@idAccesoApp int
AS
	delete from TB_ACCESOAPLICATIVOS
	where Id_AccesoApp=@idAccesoApp
GO

CREATE PROCEDURE SP_BuscarAccesoApp
@idAccesoApp int
AS
	select  a.Id_AccesoApp as Id_AccesoApp,
			e.Id_Equipo as Equipo,
			so.Id_Solicitud as Solicitud,
			a.Estado as Estado,
			[tk_referencia],
			a.[Descripcion]as Descripcion,
			r.Id_Responsable as Responsable,
			u.Id_Usuario as Usuario
	from TB_ACCESOAPLICATIVOS a 
	inner join TB_EQUIPO e on e.Id_Equipo=a.Id_Equipo
	inner join TB_SOLICITUD so on so.Id_Solicitud=a.Id_Solicitud
	inner join TB_RESPONSABLE r on r.Id_Responsable = a.Id_Responsable
	inner join TB_USUARIO u on u.Id_Usuario = a.Id_Usuario
	where a.Id_AccesoApp=@idAccesoApp
GO

CREATE  PROCEDURE SP_BuscarEquipoxUsuario
@IDUSUARIO INT
AS
		SELECT distinct E.Id_Equipo AS Id_Equipo,E.Descripcion AS Descripcion
		FROM TB_EQUIPO E 
		INNER JOIN TB_USUARIO U ON U.Id_Equipo = E.Id_Equipo
		WHERE U.Id_Usuario = @IDUSUARIO
GO

CREATE  PROCEDURE SP_BuscarSolicitantexUsuario
@IDUSUARIO INT
AS
		SELECT Id_Usuario AS Id_Solicitante, CONCAT(Nombres,' ',Apellidos) AS Solicitante
		FROM TB_USUARIO s
		WHERE Id_Usuario = @IDUSUARIO
GO

/*-------------------------------PASES A PRODUCCION-----------------------------------------------------*/
/*------------------------------------------------------------------------------------*/

CREATE  PROCEDURE SP_ListarTipoPase
AS
	select Id_TpPase,Descripcion
	from TB_TIPO_PASE
GO

CREATE PROCEDURE SP_InsertarTipoPase
@descripcion varchar(50)
AS
	insert into TB_TIPO_PASE(Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarTipoPase
@idTipoPase int,
@descripcion varchar(50)
AS
	update TB_TIPO_PASE
	set Descripcion=@descripcion
	where Id_TpPase=@idTipoPase
GO

CREATE PROCEDURE SP_EliminarTipoPase
@idTipoPase int
AS
	delete from TB_TIPO_PASE
	where Id_TpPase=@idTipoPase
GO
CREATE  PROCEDURE SP_BuscarTipoPase
@idTipoPase int
AS
	select Id_TpPase,Descripcion
	from TB_TIPO_PASE
	where Id_TpPase=@idTipoPase
GO

/*------------------------------------------------------------------------------------*/

CREATE  PROCEDURE SP_ListarOrigen
AS
	select [Id_Origen],Descripcion
	from TB_ORIGEN
GO

CREATE PROCEDURE SP_InsertarOrigen
@descripcion varchar(50)
AS
	insert into TB_ORIGEN(Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarOrigen
@idOrigen int,
@descripcion varchar(50)
AS
	update TB_ORIGEN
	set Descripcion=@descripcion
	where Id_Origen=@idOrigen
GO

CREATE PROCEDURE SP_EliminarOrigen
@idOrigen int
AS
	delete from TB_ORIGEN
	where Id_Origen=@idOrigen
GO
CREATE  PROCEDURE SP_BuscarOrigen
@idOrigen int
AS
	select Id_Origen,Descripcion
	from TB_ORIGEN
	where Id_Origen=@idOrigen
GO

/*------------------------------------------------------------------------------------*/


CREATE  PROCEDURE SP_ListarSistema
AS
	select Id_Sistema,Descripcion
	from TB_SISTEMA
GO

CREATE PROCEDURE SP_InsertarSistema
@descripcion varchar(50)
AS
	insert into TB_SISTEMA(Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarSistema
@idSistema int,
@descripcion varchar(50)
AS
	update TB_SISTEMA
	set Descripcion=@descripcion
	where Id_Sistema=@idSistema
GO

CREATE PROCEDURE SP_EliminarSistema
@idSistema int
AS
	delete from TB_SISTEMA
	where Id_Sistema=@idSistema
GO
CREATE  PROCEDURE SP_BuscarSistema
@idSistema int
AS
	select Id_Sistema,Descripcion
	from TB_SISTEMA
	where Id_Sistema=@idSistema
GO



/*------------------------------------------------------------------------------------*/

CREATE  PROCEDURE SP_ListarAprobadores
AS
	select Id_Aprobador,Descripcion
	from TB_APROBADORES
GO


CREATE PROCEDURE SP_InsertarAprobadores
@descripcion varchar(50)
AS
	insert into TB_APROBADORES (Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarAprobadores
@idAprobador int,
@descripcion varchar(50)
AS
	update TB_APROBADORES 
	set Descripcion = @descripcion
	where Id_Aprobador=@idAprobador
GO

CREATE pROCEDURE SP_EliminarAprobadores
@idAprobador int
AS
	delete from TB_APROBADORES
	where Id_Aprobador=@idAprobador
GO

CREATE PROCEDURE SP_BuscarAprobadores
@idAprobador int
AS
	select Id_Aprobador,Descripcion
	from TB_APROBADORES
	where Id_Aprobador=@idAprobador
GO

/*------------------------------------------------------------------------------------*/

CREATE  PROCEDURE SP_ListarProveedor
AS
	select Id_Proveedor,Descripcion
	from TB_PROVEEDOR
GO


CREATE PROCEDURE SP_InsertarProveedor
@descripcion varchar(50)
AS
	insert into TB_PROVEEDOR (Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarProveedor
@idProveedor int,
@descripcion varchar(50)
AS
	update TB_PROVEEDOR 
	set Descripcion = @descripcion
	where Id_Proveedor=@idProveedor
GO

CREATE pROCEDURE SP_EliminarProveedor
@idProveedor int
AS
	delete from TB_PROVEEDOR
	where Id_Proveedor=@idProveedor
GO

CREATE PROCEDURE SP_BuscarProveedor
@idProveedor int
AS
	select Id_Proveedor,Descripcion
	from TB_PROVEEDOR
	where Id_Proveedor=@idProveedor
GO

/*------------------------------- GESTION DE ACCESOS -----------------------------------------------------*/
/*------------------------------------------------------------------------------------*/

CREATE  PROCEDURE SP_ListarSolicitanteGA
AS
	select Id_Solicitante_GA,Descripcion
	from TB_SOLICITANTE_GA
GO


CREATE PROCEDURE SP_InsertarSolicitanteGA
@descripcion varchar(50)
AS
	insert into TB_SOLICITANTE_GA (Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarSolicitanteGA
@idSolicitanteGA int,
@descripcion varchar(50)
AS
	update TB_SOLICITANTE_GA 
	set Descripcion = @descripcion
	where Id_Solicitante_GA=@idSolicitanteGA
GO

CREATE pROCEDURE SP_EliminarSolicitanteGA
@idSolicitanteGA int
AS
	delete from TB_SOLICITANTE_GA
	where Id_Solicitante_GA=@idSolicitanteGA
GO

CREATE PROCEDURE SP_BuscarSolicitanteGA
@idSolicitanteGA int
AS
	select Id_Solicitante_GA,Descripcion
	from TB_SOLICITANTE_GA
	where Id_Solicitante_GA=@idSolicitanteGA
GO

/*------------------------------------------------------------------------------------*/


CREATE  PROCEDURE SP_ListarAreaGA
AS
	select Id_Area_GA,Descripcion
	from TB_AREA_GA
GO


CREATE PROCEDURE SP_InsertarAreaGA
@descripcion varchar(50)
AS
	insert into TB_AREA_GA (Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarAreaGA
@idAreaGA int,
@descripcion varchar(50)
AS
	update TB_AREA_GA 
	set Descripcion = @descripcion
	where Id_Area_GA=@idAreaGA
GO

CREATE pROCEDURE SP_EliminarAreaGA
@idAreaGA int
AS
	delete from TB_AREA_GA
	where Id_Area_GA=@idAreaGA
GO

CREATE PROCEDURE SP_BuscarAreaGA
@idAreaGA int
AS
	select Id_Area_GA,Descripcion
	from TB_AREA_GA
	where Id_Area_GA=@idAreaGA
GO



/*------------------------------------------------------------------------------------*/


CREATE  PROCEDURE SP_ListarSedeGA
AS
	select Id_Sede_GA,Descripcion
	from TB_SEDE_GA
GO


CREATE PROCEDURE SP_InsertarSedeGA
@descripcion varchar(50)
AS
	insert into TB_SEDE_GA (Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarSedeGA
@idSedeGA int,
@descripcion varchar(50)
AS
	update TB_SEDE_GA 
	set Descripcion = @descripcion
	where Id_Sede_GA=@idSedeGA
GO

CREATE pROCEDURE SP_EliminarSedeGA
@idSedeGA int
AS
	delete from TB_SEDE_GA
	where Id_Sede_GA=@idSedeGA
GO

CREATE PROCEDURE SP_BuscarSedeGA
@idSedeGA int
AS
	select Id_Sede_GA,Descripcion
	from TB_SEDE_GA
	where Id_Sede_GA=@idSedeGA
GO


/*------------------------------------------------------------------------------------*/


CREATE  PROCEDURE SP_ListarServicioGA
AS
	select Id_Servicio_GA,Descripcion
	from TB_SERVICIO_GA
GO


CREATE PROCEDURE SP_InsertarServicioGA
@descripcion varchar(50)
AS
	insert into TB_SERVICIO_GA (Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarServicioGA
@idServicioGA int,
@descripcion varchar(50)
AS
	update TB_SERVICIO_GA 
	set Descripcion = @descripcion
	where Id_Servicio_GA=@idServicioGA
GO

CREATE pROCEDURE SP_EliminarServicioGA
@idServicioGA int
AS
	delete from TB_SERVICIO_GA
	where Id_Servicio_GA=@idServicioGA
GO

CREATE PROCEDURE SP_BuscarServicioGA
@idServicioGA int
AS
	select Id_Servicio_GA,Descripcion
	from TB_SERVICIO_GA
	where Id_Servicio_GA=@idServicioGA
GO


/*------------------------------------------------------------------------------------*/


CREATE  PROCEDURE SP_ListarAprobadoresGA
AS
	select Id_Aprobadores_GA,Descripcion
	from TB_APROBADORES_GA
GO


CREATE PROCEDURE SP_InsertarAprobadoresGA
@descripcion varchar(50)
AS
	insert into TB_APROBADORES_GA (Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarAprobadoresGA
@idAprobadoresGA int,
@descripcion varchar(50)
AS
	update TB_APROBADORES_GA 
	set Descripcion = @descripcion
	where Id_Aprobadores_GA=@idAprobadoresGA
GO

CREATE pROCEDURE SP_EliminarAprobadoresGA
@idAprobadoresGA int
AS
	delete from TB_APROBADORES_GA
	where Id_Aprobadores_GA=@idAprobadoresGA
GO

CREATE PROCEDURE SP_BuscarAprobadoresGA
@idAprobadoresGA int
AS
	select Id_Aprobadores_GA,Descripcion
	from TB_APROBADORES_GA
	where Id_Aprobadores_GA=@idAprobadoresGA
GO



/*------------------------------------------------------------------------------------*/


CREATE  PROCEDURE SP_ListarTipoGA
AS
	select Id_Tipo_GA,Descripcion
	from TB_TIPO_GA
GO


CREATE PROCEDURE SP_InsertarTipoGA
@descripcion varchar(50)
AS
	insert into TB_TIPO_GA (Descripcion)
	values (@descripcion)
GO

CREATE  PROCEDURE SP_ActualizarTipoGA
@idTipoGA int,
@descripcion varchar(50)
AS
	update TB_TIPO_GA 
	set Descripcion = @descripcion
	where Id_Tipo_GA=@idTipoGA
GO

CREATE pROCEDURE SP_EliminarTipoGA
@idTipoGA int
AS
	delete from TB_TIPO_GA
	where Id_Tipo_GA=@idTipoGA
GO

CREATE PROCEDURE SP_BuscarTipoGA
@idTipoGA int
AS
	select Id_Tipo_GA,Descripcion
	from TB_TIPO_GA
	where Id_Tipo_GA=@idTipoGA
GO


/*------------------------------------------------------------------------------------*/
CREATE PROCEDURE [dbo].[SP_ListarGestionAccesos]

AS
	select Id_GestionAcceso,
			FechaHora,
			S.Descripcion AS Solicitante,
			NombreUsuario,
			A.Descripcion AS Area,
			SE.Descripcion AS Sede,
			SER.Descripcion AS Servicio,
			DetalleSolicitud,
			AP.Descripcion AS Aprobadores,
			T.Descripcion AS Tipo, 
			ReferenciaTK,
			R.Descripcion AS Responsable,
			Username,
			PerfilSimilar,
			Observaciones
	from TB_GESTION_ACCESOS GA
	INNER JOIN TB_SOLICITANTE_GA S ON S.Id_Solicitante_GA=GA.Id_Solicitante_GA
	LEFT JOIN TB_AREA_GA A ON A.Id_Area_GA=GA.Id_Area_GA
	LEFT JOIN TB_SEDE_GA SE ON SE.Id_Sede_GA = GA.Id_Sede_GA
	LEFT JOIN TB_SERVICIO_GA SER ON SER.Id_Servicio_GA=GA.Id_Servicio_GA
	LEFT JOIN TB_APROBADORES_GA AP ON AP.Id_Aprobadores_GA = GA.Id_Aprobadores_GA
	LEFT JOIN TB_TIPO_GA T ON T.Id_Tipo_GA=GA.Id_Tipo_GA
	LEFT JOIN TB_RESPONSABLE R ON R.Id_Responsable = GA.Id_Responsable
	
CREATE PROCEDURE [dbo].[SP_InsertarGestionAccesos]
@fecha datetime,
@solicitante int,
@nombreUsuario varchar(250),
@area int,
@sede int,
@servicio int,
@detsolicitud varchar(500),
@aprobadores int,
@tipo int,
@tk varchar(50),
@responsable int,
@username varchar(50),
@perfilsimilar varchar(50),
@obs varchar(500)
AS
	insert into TB_GESTION_ACCESOS (FechaHora,Id_Solicitante_GA,NombreUsuario,Id_Area_GA,Id_Sede_GA,Id_Servicio_GA,DetalleSolicitud
									,Id_Aprobadores_GA,Id_Tipo_GA,ReferenciaTK,Id_Responsable,Username,PerfilSimilar,Observaciones)
	values (@fecha,@solicitante,@nombreUsuario,@area,@sede,@servicio,@detsolicitud,@aprobadores,@tipo,@tk,@responsable,@username,
			@perfilsimilar,@obs)	


CREATE  PROCEDURE [dbo].[SP_ActualizarGestionAccesos]
@id int,
@fecha datetime,
@solicitante int,
@nombreUsuario varchar(250),
@area int,
@sede int,
@servicio int,
@detsolicitud varchar(500),
@aprobadores int,
@tipo int,
@tk varchar(50),
@responsable int,
@username varchar(50),
@perfilsimilar varchar(50),
@obs varchar(500)
AS
	update TB_GESTION_ACCESOS 
	set FechaHora = @fecha,
		Id_Solicitante_GA = @solicitante,
		NombreUsuario = @nombreUsuario,
		Id_Area_GA = @area,
		Id_Sede_GA = @sede,
		Id_Servicio_GA = @servicio,
		DetalleSolicitud = @detsolicitud,
		Id_Aprobadores_GA = @aprobadores,
		Id_Tipo_GA = @tipo,
		ReferenciaTK = @tk,
		Id_Responsable = @responsable,
		Username = @username,
		PerfilSimilar = @perfilsimilar,
		Observaciones = @obs
	where Id_GestionAcceso=@id


CREATE PROCEDURE [dbo].[SP_EliminarGestionAccesos]
@id int
AS
	delete from TB_GESTION_ACCESOS
	where Id_GestionAcceso=@id	

	
CREATE PROCEDURE [dbo].[SP_BuscarGestionAccesos]
@id int
AS
	select Id_GestionAcceso,
			FechaHora,
			Id_Solicitante_GA,
			NombreUsuario,
			Id_Area_GA,
			Id_Sede_GA,
			Id_Servicio_GA,
			DetalleSolicitud,
			Id_Aprobadores_GA,
			Id_Tipo_GA, 
			ReferenciaTK,
			Id_Responsable,
			Username,
			PerfilSimilar,
			Observaciones
	from TB_GESTION_ACCESOS GA
	where Id_GestionAcceso=@id	
	