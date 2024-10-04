USE [PooClase]
GO

/****** Object:  StoredProcedure [dbo].[SP_Persona_Update]    Script Date: 03/06/2024 11:08:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_Persona_Update](
	@IdPersona int,
	@Nombre varchar(30),
	@ApellidoPaterno varchar(20),
	@ApellidoMaterno varchar(20),	
	@FechaNacimiento date,
	@Edad int,
	@user_insert int,
	@exito int output,
	@mensaje varchar(200) output
)

as
set @exito = 1
set @mensaje = 'Actualización correcta'

update Persona
	set Nombre = @Nombre,
		ApellidoPaterno = @ApellidoPaterno,
		ApellidoMaterno = @ApellidoMaterno,
		FechaNacimiento = @FechaNacimiento,
		Edad = @Edad,
		user_update = @user_insert,
		fech_update = GETDATE()
	where IdPersona = @IdPersona
GO


