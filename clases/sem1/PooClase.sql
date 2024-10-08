USE [master]
GO
/****** Object:  Database [PooClase]    Script Date: 27/05/2024 03:18:47 AM ******/
CREATE DATABASE [PooClase]
GO

USE [PooClase]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 27/05/2024 03:18:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[IdPersona] [int] NOT NULL,
	[Nombre] [varchar](30) NULL,
	[ApellidoPaterno] [varchar](20) NULL,
	[ApellidoMaterno] [varchar](20) NULL,
	[NroDocumento] [varchar](8) NULL,
	[FechaNacimiento] [date] NULL,
	[Edad] [int] NULL,
	[flgEliminado] [bit] NULL,
	[user_insert] [int] NULL,
	[fech_insert] [smalldatetime] NULL,
	[user_update] [int] NULL,
	[fech_update] [smalldatetime] NULL,
	[user_delete] [int] NULL,
	[fech_delete] [smalldatetime] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_Persona_Insert]    Script Date: 27/05/2024 03:18:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_Persona_Insert](
--declare 
	@Nombre varchar(30),
	@ApellidoPaterno varchar(20),
	@ApellidoMaterno varchar(20),
	@NroDocumento varchar(8),
	@FechaNacimiento date,
	@Edad int,
	@user_insert int

)

as
begin
	
	declare @IdPersona int

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
GO
USE [master]
GO
ALTER DATABASE [PooClase] SET  READ_WRITE 
GO
