CREATE PROCEDURE dbo.EmpresasObtener
@IdEmpresa INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			IdEmpresa
		,	NombreEmpresa
		,	Estado

	FROM dbo.Empresa
	WHERE
	     (@IdEmpresa IS NULL OR IdEmpresa=@IdEmpresa)

END