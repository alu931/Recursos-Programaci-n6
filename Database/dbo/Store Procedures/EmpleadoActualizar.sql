CREATE PROCEDURE [dbo].[EmpleadoActualizar]
    @IdEmpleado INT,
    @IdTipoIdentificacion INT,
	@IdEmpresa INT,
	@Identificacion varchar(100),
	@NombreEmpleado varchar(50),
	@Edad INT,
	@Sexo varchar(1),
	@Estado BIT,
	@TieneVehiculo BIT,
	@Vehiculos varchar(1000)=NULL
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
	UPDATE DBO.Empleado SET
	IdTipoIdentificacion=@IdTipoIdentificacion,
	IdEmpresa=@IdEmpresa,
	Identificacion=@Identificacion,
    NombreEmpleado=@NombreEmpleado,
    Edad=@Edad,
	Sexo=@Sexo,
	Estado=@Estado,
	TieneVehiculo=@TieneVehiculo,
	Vehiculos=@Vehiculos

	WHERE IdEmpleado=@IdEmpleado


		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, '' AS MsgError



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END