USE [master]
GO
/****** Object:  Database [PooClase]    Script Date: 27/06/2024 01:57:07 PM ******/
CREATE DATABASE [PooClase] 
GO
USE [PooClase]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 27/06/2024 01:57:07 PM ******/
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
/****** Object:  Table [dbo].[Tabla]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tabla](
	[Codtabla] [varchar](30) NULL,
	[Valor] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[valor1] [varchar](50) NULL,
	[valor2] [varchar](50) NULL,
	[Estado] [int] NULL,
	[Eliminado] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trabajador]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trabajador](
	[IdTrabajador] [int] NOT NULL,
	[NroDocumento] [varchar](8) NULL,
	[Nombres] [varchar](30) NULL,
	[Apellidos] [varchar](30) NULL,
	[FechaNacimiento] [date] NULL,
	[FechaContrato] [date] NULL,
	[HorasTrabajadas] [int] NULL,
	[Tarifa] [decimal](18, 3) NULL,
 CONSTRAINT [PK_Trabajador] PRIMARY KEY CLUSTERED 
(
	[IdTrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta_Cab]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta_Cab](
	[Id_Venta] [int] NOT NULL,
	[Id_Persona] [int] NOT NULL,
	[Id_TipoDocumento] [int] NULL,
	[Nro_Documento] [varchar](8) NULL,
	[Fecha_Venta] [smalldatetime] NULL,
	[Sub_Total] [decimal](18, 4) NULL,
	[Descuento] [decimal](18, 4) NULL,
	[Igv] [decimal](18, 4) NULL,
	[Total] [decimal](18, 4) NULL,
	[Flg_Eliminado] [bit] NULL,
 CONSTRAINT [PK_Venta_Cab] PRIMARY KEY CLUSTERED 
(
	[Id_Venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta_Det]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta_Det](
	[Id_VentaDetalle] [int] NOT NULL,
	[Id_Venta] [int] NULL,
	[NombreProducto] [varchar](50) NULL,
	[Cantidad] [int] NULL,
	[Precio] [decimal](18, 4) NULL,
	[Subtotal] [decimal](18, 4) NULL,
	[Descuento] [decimal](18, 4) NULL,
	[Igv] [decimal](18, 4) NULL,
	[Total] [decimal](18, 4) NULL,
	[Flag_Eliminado] [bit] NULL,
 CONSTRAINT [PK_Venta_Det] PRIMARY KEY CLUSTERED 
(
	[Id_VentaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Persona] ([IdPersona], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NroDocumento], [FechaNacimiento], [Edad], [flgEliminado], [user_insert], [fech_insert], [user_update], [fech_update], [user_delete], [fech_delete]) VALUES (1, N'franz', N'chuje', N'panaifo', N'47814917', CAST(N'1993-06-05' AS Date), 31, 0, 1, CAST(N'2024-05-27T02:55:00' AS SmallDateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Persona] ([IdPersona], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NroDocumento], [FechaNacimiento], [Edad], [flgEliminado], [user_insert], [fech_insert], [user_update], [fech_update], [user_delete], [fech_delete]) VALUES (2, N'sas', N'saas', N'assa', N'47814918', CAST(N'2020-01-29' AS Date), 4, 0, 1, CAST(N'2024-06-03T09:07:00' AS SmallDateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Persona] ([IdPersona], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NroDocumento], [FechaNacimiento], [Edad], [flgEliminado], [user_insert], [fech_insert], [user_update], [fech_update], [user_delete], [fech_delete]) VALUES (3, N'Manuel', N'Dominguez', N'Florez', N'12345678', CAST(N'1990-01-30' AS Date), 34, 0, 1, CAST(N'2024-06-03T09:34:00' AS SmallDateTime), 1, CAST(N'2024-06-03T09:35:00' AS SmallDateTime), NULL, NULL)
INSERT [dbo].[Persona] ([IdPersona], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NroDocumento], [FechaNacimiento], [Edad], [flgEliminado], [user_insert], [fech_insert], [user_update], [fech_update], [user_delete], [fech_delete]) VALUES (4, N'qwqe', N'qweqw', N'qwewq', N'22222222', CAST(N'2000-02-01' AS Date), 24, 1, 1, CAST(N'2024-06-03T09:46:00' AS SmallDateTime), NULL, NULL, 1, CAST(N'2024-06-03T09:46:00' AS SmallDateTime))
INSERT [dbo].[Persona] ([IdPersona], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [NroDocumento], [FechaNacimiento], [Edad], [flgEliminado], [user_insert], [fech_insert], [user_update], [fech_update], [user_delete], [fech_delete]) VALUES (5, N'123123', N'qweqwe', N'qweqw', N'23333333', CAST(N'2000-02-01' AS Date), 24, 0, 1, CAST(N'2024-06-03T09:46:00' AS SmallDateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Tabla] ([Codtabla], [Valor], [Nombre], [valor1], [valor2], [Estado], [Eliminado]) VALUES (N'TablaTipoDocumento', 1, N'DNI', NULL, NULL, 1, 0)
INSERT [dbo].[Tabla] ([Codtabla], [Valor], [Nombre], [valor1], [valor2], [Estado], [Eliminado]) VALUES (N'TablaTipoDocumento', 2, N'Libreta Militar', NULL, NULL, 1, 0)
INSERT [dbo].[Tabla] ([Codtabla], [Valor], [Nombre], [valor1], [valor2], [Estado], [Eliminado]) VALUES (N'TablaTipoDocumento', 3, N'Passaporte', NULL, NULL, 1, 0)
INSERT [dbo].[Tabla] ([Codtabla], [Valor], [Nombre], [valor1], [valor2], [Estado], [Eliminado]) VALUES (N'TablaEstadoPersona', 1, N'Activo', NULL, NULL, 1, 0)
INSERT [dbo].[Tabla] ([Codtabla], [Valor], [Nombre], [valor1], [valor2], [Estado], [Eliminado]) VALUES (N'TablaEstadoPersona', 1, N'Inactivo', NULL, NULL, 1, 0)
GO
INSERT [dbo].[Trabajador] ([IdTrabajador], [NroDocumento], [Nombres], [Apellidos], [FechaNacimiento], [FechaContrato], [HorasTrabajadas], [Tarifa]) VALUES (1, N'47814917', N'Franz', N'Chuje', CAST(N'2024-06-17' AS Date), CAST(N'2024-06-17' AS Date), 5, CAST(1000.000 AS Decimal(18, 3)))
INSERT [dbo].[Trabajador] ([IdTrabajador], [NroDocumento], [Nombres], [Apellidos], [FechaNacimiento], [FechaContrato], [HorasTrabajadas], [Tarifa]) VALUES (2, N'1234567', N'asdas', N'adad', CAST(N'2024-06-17' AS Date), CAST(N'2024-06-17' AS Date), 5, CAST(1000.000 AS Decimal(18, 3)))
GO
INSERT [dbo].[Venta_Cab] ([Id_Venta], [Id_Persona], [Id_TipoDocumento], [Nro_Documento], [Fecha_Venta], [Sub_Total], [Descuento], [Igv], [Total], [Flg_Eliminado]) VALUES (1, 1, 1, N'47814917', CAST(N'2024-06-27T00:00:00' AS SmallDateTime), CAST(30.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(88.2000 AS Decimal(18, 4)), CAST(578.2000 AS Decimal(18, 4)), 0)
GO
INSERT [dbo].[Venta_Det] ([Id_VentaDetalle], [Id_Venta], [NombreProducto], [Cantidad], [Precio], [Subtotal], [Descuento], [Igv], [Total], [Flag_Eliminado]) VALUES (1, 1, N'Colcha tigre', 2, CAST(35.0000 AS Decimal(18, 4)), CAST(70.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(12.6000 AS Decimal(18, 4)), CAST(82.6000 AS Decimal(18, 4)), 0)
INSERT [dbo].[Venta_Det] ([Id_VentaDetalle], [Id_Venta], [NombreProducto], [Cantidad], [Precio], [Subtotal], [Descuento], [Igv], [Total], [Flag_Eliminado]) VALUES (2, 1, N'producto nuevo', 12, CAST(35.0000 AS Decimal(18, 4)), CAST(420.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(75.6000 AS Decimal(18, 4)), CAST(495.6000 AS Decimal(18, 4)), 0)
GO
/****** Object:  StoredProcedure [dbo].[SP_Persona_Delete]    Script Date: 27/06/2024 01:57:07 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Persona_Insert]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_Persona_Insert](
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
/****** Object:  StoredProcedure [dbo].[SP_Persona_List]    Script Date: 27/06/2024 01:57:07 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Persona_Update]    Script Date: 27/06/2024 01:57:07 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Tabla_List]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Tabla_List](
	@codtabla varchar(30)
)

as
	select 
		Codtabla, valor, Nombre 
	from tabla 
	where Codtabla = @codtabla and Eliminado = 0
GO
/****** Object:  StoredProcedure [dbo].[SP_Trabajador_Insert]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Trabajador_Insert](
@NroDocumento varchar(8),
@Nombres varchar(30),
@Apellidos varchar(30),
@FechaNacimiento date,
@FechaContrato date,
@HorasTrabajadas int,
@Tarifa decimal (18,3),
@exito int output,
@mensaje varchar(200) output
)

as

begin
	declare 
		@totregistros int , 
		@Idtrabajador int


		set @totregistros = (select COUNT(*) from Trabajador where NroDocumento = @NroDocumento)
		if(@totregistros=0)  -- no exite
			begin
				
				set @Idtrabajador = ISNULL((select MAX(IdTrabajador) from Trabajador),0) + 1

				insert into Trabajador(
				IdTrabajador, 
				NroDocumento,
				Nombres,
				Apellidos,
				FechaNacimiento,
				FechaContrato,
				HorasTrabajadas,
				Tarifa)
				values(
					@Idtrabajador,
					@NroDocumento,
					@Nombres,
					@Apellidos,
					@FechaNacimiento,
					@FechaContrato,
					@HorasTrabajadas,
					@Tarifa
				)

				set @exito = 1
				set @mensaje = 'Se ha registrado a: ' + @Nombres
				


			end
		else  -- si existe
			begin
				set @exito = 0
				set @mensaje = 'El número de documento ya existe : ' + @NroDocumento
			end


end
GO
/****** Object:  StoredProcedure [dbo].[SP_Trabajador_List]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Trabajador_List](
	@Orden int,
	@IdTrabajador int,
	@Buscar varchar(50)
)

as

if @Orden = 1 -- me devuelve toda la lista
	begin
		select 
			IdTrabajador, 
			NroDocumento,
			Nombres,
			Apellidos,
			FechaNacimiento,
			FechaContrato,
			HorasTrabajadas,
			Tarifa
		from Trabajador
		where Nombres like @Buscar or Apellidos like @Buscar or NroDocumento like @Buscar
	end

if @Orden =  2 -- me devuelve por ID
	begin
		select 
			IdTrabajador, 
			NroDocumento,
			Nombres,
			Apellidos,
			FechaNacimiento,
			FechaContrato,
			HorasTrabajadas,
			Tarifa
		from Trabajador
		where IdTrabajador = @IdTrabajador
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_VentaCab_Update]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_VentaCab_Update](
	@Idventa int, 
	@SubTotal decimal(18,4),
	@Igv decimal(18,4),
	@Total decimal(18,4)
)

as
update Venta_Cab set @SubTotal = @SubTotal, Igv = @Igv, Total = @Total where Id_Venta = @Idventa
GO
/****** Object:  StoredProcedure [dbo].[SP_VentaDet_Insert]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SP_VentaDet_Insert](
	@Id_VentaDetalle int,
	@IdVenta int,
	@NombreProducto varchar(50),
	@Cantidad int, 
	@Precio decimal(18,4),
	@Subtotal decimal(18,4),
	@Igv decimal(18,4),
	@Descuento decimal(18,4),
	@Total decimal(18,4)
 )
 as


  set @Id_VentaDetalle = isnull((select max(Id_VentaDetalle) from Venta_Det), 0) +1

  insert into Venta_Det (
  Id_VentaDetalle, Id_Venta, NombreProducto, Cantidad, Precio, Subtotal, Igv, Descuento, Total, Flag_Eliminado )
  values(
  @Id_VentaDetalle, @IdVenta, @NombreProducto, @Cantidad, @Precio, @Subtotal, @Igv, @Descuento, @Total, 0
  )
GO
/****** Object:  StoredProcedure [dbo].[SP_VentaDet_Update]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SP_VentaDet_Update](
	@Id_VentaDetalle int,
	@NombreProducto varchar(50),
	@Cantidad int, 
	@Precio decimal(18,4),
	@Subtotal decimal(18,4),
	@Igv decimal(18,4),
	@Descuento decimal(18,4),
	@Total decimal(18,4)
 )
 as


 update Venta_Det 
	set NombreProducto = @NombreProducto,
		Cantidad = @Cantidad,
		Precio = @Precio ,
		Subtotal = @Subtotal,
		Igv = @Igv,
		Descuento = @Descuento,
		Total = @Total
	where  Id_VentaDetalle = @Id_VentaDetalle	
GO
/****** Object:  StoredProcedure [dbo].[Venta_List]    Script Date: 27/06/2024 01:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Venta_List](
	@orden int,
	@idventa int
)

as

if @orden = 1 --- Listar Todas las ventas
	begin
		select 
			Id_Venta,
			v.Id_Persona,
			p.Nombre as NombreCliente,
			Id_TipoDocumento,
			t.Nombre as NombreTipoDocumento,
			v.Nro_Documento,
			v.Fecha_Venta,
			v.Sub_Total,
			v.Descuento,
			v.Igv,
			v.Total
		from Venta_Cab v
		inner join Persona p on p.IdPersona = v.Id_Persona
		inner join Tabla t on t.Codtabla = 'TablaTipoDocumento' and t.Valor = v.Id_TipoDocumento
		where v.Flg_Eliminado = 0
	end

if @orden = 2 --- Lista por ID
	begin
		select 
			Id_Venta,
			v.Id_Persona,
			p.Nombre as NombreCliente,
			Id_TipoDocumento,
			t.Nombre as NombreTipoDocumento,
			v.Nro_Documento,
			v.Fecha_Venta,
			v.Sub_Total,
			v.Descuento,
			v.Igv,
			v.Total
		from Venta_Cab v
		inner join Persona p on p.IdPersona = v.Id_Persona
		inner join Tabla t on t.Codtabla = 'TablaTipoDocumento' and t.Valor = v.Id_TipoDocumento
		where v.Flg_Eliminado = 0 and v.Id_Venta = @idventa

		select 
			Id_VentaDetalle,
			Id_Venta,
			NombreProducto,
			Cantidad,
			Precio,
			Subtotal, 
			Descuento,
			Igv,
			Total
		
		from Venta_Det v where Id_Venta  = @idventa


	end
GO
USE [master]
GO
ALTER DATABASE [PooClase] SET  READ_WRITE 
GO
