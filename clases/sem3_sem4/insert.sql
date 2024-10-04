create procedure SP_Trabajador_List(
	@Orden int,
	@IdTrabajador int,
	@Buscar varchar(50)
)

as

if @Orden = 1 -- me devuelve toda la lista
	begin
		select 
			IdTrabajador, NroDocumento, Nombres, Apellidos, FechaNacimiento, FechaContrato, HorasTrabajadas, Tarifa
		from Trabajador
		where Nombres like @Buscar or Apellidos like @Buscar or NroDocumento like @Buscar
	end

if @Orden =  2 -- me devuelve por ID
	begin
		select IdTrabajador, NroDocumento, Nombres, Apellidos, FechaNacimiento, FechaContrato, HorasTrabajadas, Tarifa
		from Trabajador
		where IdTrabajador = @IdTrabajador
	end
