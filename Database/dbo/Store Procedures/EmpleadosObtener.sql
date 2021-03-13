CREATE PROCEDURE [dbo].[EmpleadosObtener]
@IdEmpleado INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			E.IdEmpleado
		,   E.Identificacion
		,   E.NombreEmpleado
		,   E.Edad
		,   E.Sexo
		,   E.Estado
		,   E.TieneVehiculo
		,   E.Vehiculos
		,   TI.IdTipoIdentificacion
		,	TI.Descripcion
		,   EM.IdEmpresa
		,	EM.NombreEmpresa
		

	FROM dbo.Empleado E
	 LEFT JOIN dbo.TipoIdentificacion TI
         ON E.IdTipoIdentificacion = TI.IdTipoIdentificacion
	 LEFT JOIN dbo.Empresa EM
         ON E.IdEmpresa = EM.IdEmpresa
	WHERE
	     (@IdEmpleado IS NULL OR IdEmpleado=@IdEmpleado)

END