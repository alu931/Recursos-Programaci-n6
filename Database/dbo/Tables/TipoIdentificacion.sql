CREATE TABLE [dbo].[TipoIdentificacion]
(
	IdTipoIdentificacion INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_TipoIdentificacion PRIMARY KEY CLUSTERED(IdTipoIdentificacion)
	, Descripcion VARCHAR(50) NOT NULL
	, Estado BIT NOT NULL CONSTRAINT DF_TipoIdentificacion_Estado DEFAULT(0)

) WITH (DATA_COMPRESSION = PAGE)
