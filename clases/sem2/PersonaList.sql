USE [PooClase]
GO

/****** Object:  StoredProcedure [dbo].[SP_Persona_List]    Script Date: 03/06/2024 11:08:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_Persona_List](
	@Orden int,
	@Buscar varchar(50),
	@Idpersona int
)
as

if @Orden  = 1 -- el orden 1 me devuelve toda la lista de personas
	begin
		select
			IdPersona,
			Nombre,
			ApellidoPaterno,
			ApellidoMaterno,
			NroDocumento,
			FechaNacimiento,
			Edad
		from Persona
		where flgEliminado = 0 and
		(
			Nombre like @Buscar or
			ApellidoPaterno like @Buscar or
			ApellidoMaterno like @Buscar or
			NroDocumento like @Buscar
		)
	end
if @Orden = 2
	begin
		select
			IdPersona,
			Nombre,
			ApellidoPaterno,
			ApellidoMaterno,
			NroDocumento,
			FechaNacimiento,
			Edad
		from Persona
		where IdPersona = @Idpersona
	end
GO


