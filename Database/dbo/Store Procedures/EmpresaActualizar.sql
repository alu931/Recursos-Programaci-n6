CREATE PROCEDURE [dbo].[EmpresaActualizar]
    @IdEmpresa INT,
    @NombreEmpresa VARCHAR(50),
	@Estado BIT
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
	UPDATE DBO.Empresa SET
	NombreEmpresa=@NombreEmpresa,
	Estado=@Estado

	WHERE IdEmpresa=@IdEmpresa


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

