CREATE PROCEDURE [dbo].[EmpresaLista]

AS BEGIN
	SET NOCOUNT ON

	SELECT
			IdEmpresa
		,	NombreEmpresa


	FROM dbo.Empresa
	WHERE
	     Estado=1
		 order by NombreEmpresa

END