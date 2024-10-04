create procedure SP_Trabajador_Insert(
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

				insert into Trabajador(IdTrabajador, NroDocumento, Nombres, Apellidos, FechaNacimiento, FechaContrato, HorasTrabajadas, Tarifa)
				values(@Idtrabajador, @NroDocumento, @Nombres, @Apellidos, @FechaNacimiento, @FechaContrato, @HorasTrabajadas, @Tarifa)

				set @exito = 1
				set @mensaje = 'Se ha registrado a: ' + @Nombres
				
			end
		else  -- si existe
			begin
				set @exito = 0
				set @mensaje = 'El número de documento ya existe : ' + @NroDocumento
			end


end