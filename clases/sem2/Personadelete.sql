USE [PooClase]
GO

/****** Object:  StoredProcedure [dbo].[SP_Persona_Delete]    Script Date: 03/06/2024 11:08:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_Persona_Delete](
	@IdPersona int,
	@user_insert int,
	@exito int output,
	@mensaje varchar(200) output
)
as
set @exito = 1
set @mensaje = 'Eliminación correcta'

update Persona 
	set flgEliminado = 1,
		user_delete = @user_insert,
		fech_delete = GETDATE()
	where IdPersona = @IdPersona 
GO


