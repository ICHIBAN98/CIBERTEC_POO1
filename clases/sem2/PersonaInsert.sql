USE [PooClase]
GO

/****** Object:  StoredProcedure [dbo].[SP_Persona_Insert]    Script Date: 03/06/2024 11:08:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[SP_Persona_Insert](
--declare 
	@Nombre varchar(30),
	@ApellidoPaterno varchar(20),
	@ApellidoMaterno varchar(20),
	@NroDocumento varchar(8),
	@FechaNacimiento date,
	@Edad int,
	@user_insert int,
	@exito int output,
	@mensaje varchar(200) output
)
as

set @exito = 1
set @mensaje = 'Se ha registrado correctamente el documento nro: ' + @NroDocumento

begin
	
	declare 
		@IdPersona int,
		@TotRegistro int

	set @TotRegistro = ISNULL((select COUNT(*) from Persona where NroDocumento = @NroDocumento and flgEliminado = 0), 0)

	if(@TotRegistro = 0) -- No existe registro
		begin
			set @IdPersona = ISNULL((select MAX(IdPersona) from Persona), 0) + 1

			insert into Persona (
				IdPersona,
				Nombre,
				ApellidoPaterno,
				ApellidoMaterno,
				NroDocumento,
				FechaNacimiento,
				Edad,
				flgEliminado,
				user_insert,
				fech_insert	)

			values(
				@IdPersona,
				@Nombre,
				@ApellidoPaterno,
				@ApellidoMaterno,
				@NroDocumento,
				@FechaNacimiento,
				@Edad,
				0,
				@user_insert,
				GETDATE()
			)
		end
	else
		begin
			set @exito = 0
			set @mensaje = 'El número de documento ' + @NroDocumento + ' ya existe'
		end
end
GO


