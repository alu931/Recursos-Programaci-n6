CREATE PROCEDURE [dbo].[TipoIdentificacionLista]


AS BEGIN
	SET NOCOUNT ON

	SELECT
			IdTipoIdentificacion
		,	Descripcion


	FROM dbo.TipoIdentificacion
	WHERE
	     Estado=1
		 order by Descripcion

END
