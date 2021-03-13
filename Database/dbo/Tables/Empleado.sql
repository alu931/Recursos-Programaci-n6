CREATE TABLE [dbo].[Empleado]
(
	IdEmpleado INT NOT NULL IDENTITY(1,1)
	           CONSTRAINT PK_Empleado PRIMARY KEY CLUSTERED(IdEmpleado)
    , IdTipoIdentificacion INT NOT NULL
	           CONSTRAINT FK_Empleado_TipoIdentificacion FOREIGN KEY(IdTipoIdentificacion) REFERENCES dbo.TipoIdentificacion(IdTipoIdentificacion)
	, IdEmpresa INT NOT NULL
	           CONSTRAINT FK_Empleado_Empresa FOREIGN KEY(IdTipoIdentificacion) REFERENCES dbo.Empresa(IdEmpresa)
	, Identificacion VARCHAR(100) NOT NULL
	, NombreEmpleado VARCHAR(100) NOT NULL
	, Edad INT NOT NULL
	       CONSTRAINT CHK_Empleado_Edad CHECK(Edad>=18)
	, Sexo VARCHAR(1) NOT NULL
	       CONSTRAINT CHK_Empleado_Sexo CHECK(Sexo= 'F' OR Sexo= 'M')
	, Estado BIT NOT NULL
	       CONSTRAINT DF_Empleado_Estado DEFAULT(0)
	, TieneVehiculo BIT NOT NULL
	       CONSTRAINT DF_Empleado_Vehiculo DEFAULT(0)
	, Vehiculos VARCHAR(1000) NULL
)WITH (DATA_COMPRESSION = PAGE)
