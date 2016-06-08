USE[GD1C2016];
GO

CREATE SCHEMA [DBME] AUTHORIZATION [gd];
GO

/* START CREACION TABLAS */

CREATE TABLE DBME.funcionalidad (
	funcionalidad_id INT IDENTITY(1,1) PRIMARY KEY,
	descripcion NVARCHAR(255)
);
GO

CREATE TABLE DBME.rol (
	rol_id INT IDENTITY(1,1) PRIMARY KEY,
	nombre_rol NVARCHAR(255),
	es_rol_habilitado bit
);
GO


CREATE TABLE DBME.rol_x_funcionalidad (
	funcionalidad_id INT FOREIGN KEY REFERENCES DBME.funcionalidad(funcionalidad_id), 
	rol_id INT FOREIGN KEY REFERENCES DBME.rol(rol_id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
);
GO

CREATE TABLE DBME.domicilio (
	domicilio_id INT IDENTITY(1,1) PRIMARY KEY,
	ciudad NVARCHAR(255),
	localidad NVARCHAR(255),
	codigo_postal NVARCHAR(50),
	piso NUMERIC(18,0),
	departamento NVARCHAR(50),
	domicilio_calle NVARCHAR(255),
	numero_calle NUMERIC(18,0),
);
GO

CREATE TABLE DBME.usuario(
	usuario_id INT IDENTITY(1,1) PRIMARY KEY,
	username NVARCHAR(255) UNIQUE,
	password NVARCHAR(255),
	habilitado bit,
	cantidad_intentos_fallidos TINYINT DEFAULT '0',
	mail NVARCHAR(255),
	domicilio_id INT FOREIGN KEY REFERENCES DBME.domicilio(domicilio_id),
	fecha_creacion DATETIME,
	telefono BIGINT,
	es_nuevo BIT
);
GO

CREATE TABLE DBME.rol_x_usuario (
	usuario_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id), 
	rol_id INT FOREIGN KEY REFERENCES DBME.rol(rol_id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
);
GO

CREATE TABLE DBME.cliente(
	cliente_id INT IDENTITY(1,1) PRIMARY KEY,
	apellido NVARCHAR(255),
	nombre NVARCHAR(255),
	numero_documento NUMERIC(18,0) UNIQUE,
	tipo_documento CHAR,
	fecha_nacimiento DATETIME,
	usuario_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id) 
);
GO

CREATE TABLE DBME.rubro(
	rubro_id INT IDENTITY(1,1) PRIMARY KEY,
	descripcion_corta NVARCHAR(30),
	descripcion_larga NVARCHAR(255),
);
GO

CREATE TABLE DBME.empresa(
	empresa_id INT IDENTITY(1,1) PRIMARY KEY,
	razon_social NVARCHAR(255) UNIQUE,
	cuit NVARCHAR(50) UNIQUE,
	fecha_creacion DATETIME,
	nombre_contacto VARCHAR(25),
	rubro_id INT FOREIGN KEY REFERENCES DBME.rubro(rubro_id),
	usuario_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id)
);
GO

CREATE TABLE DBME.administrador(
	administrador_id INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(16),
	apellido VARCHAR(25),
	usuario_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id)
);
GO

CREATE TABLE DBME.visibilidad(
	visibilidad_id NUMERIC(18,0) PRIMARY KEY,
	visibilidad_descripcion NVARCHAR(255),
	visibilidad_precio NUMERIC(18,2), 
	visibilidad_porcentaje NUMERIC(18,2),
	visibilidad_costo_envio NUMERIC(10,2)
);
GO


CREATE TABLE DBME.publicacion(
	publicacion_id NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,
	publicacion_tipo NVARCHAR(255), 
	descripcion NVARCHAR(255), 
	stock NUMERIC(18,0),
	fecha_creacion DATETIME,
	fecha_vencimiento DATETIME, 
	precio NUMERIC(18,2),
	costo DECIMAL(10,2),
	rubro_id INT FOREIGN KEY REFERENCES DBME.rubro(rubro_id),
	visibilidad_id NUMERIC(18,0) FOREIGN KEY REFERENCES DBME.visibilidad(visibilidad_id),
	autor_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id),
	estado NVARCHAR(255) CHECK (estado IN ('BORRADOR','ACTIVA','PAUSADA','FINALIZADA')) DEFAULT 'BORRADOR',
	permite_preguntas bit,
	realiza_envio bit,
	cantidad INT,
	fecha_finalizacion DATE,
	valor_inicial DECIMAL(10,2),
	valor_actual DECIMAL(10,2)

);
GO

CREATE TABLE DBME.oferta(
	oferta_id INT IDENTITY(1,1) PRIMARY KEY,
	fecha DATETIME,
	monto NUMERIC(18,2),
	publicacion_id NUMERIC(18,0) FOREIGN KEY REFERENCES DBME.publicacion(publicacion_id),
	autor_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id)
);
GO

CREATE TABLE DBME.compra(
	compra_id INT IDENTITY(1,1) PRIMARY KEY,
	cantidad NUMERIC(18,0),
	fecha DATETIME,
	autor_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id),
	publicacion_id NUMERIC(18,0) FOREIGN KEY REFERENCES DBME.publicacion(publicacion_id),
	esta_calificada bit
);
GO

CREATE TABLE DBME.calificacion(
	calificacion_id NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,
	cantidad_estrellas NUMERIC(18,0) CHECK(cantidad_estrellas BETWEEN '0' AND '5') DEFAULT '0',
	descripcion NVARCHAR(255) NOT NULL,
	fecha DATETIME,
	autor_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id),
	compra_id INT FOREIGN KEY REFERENCES DBME.compra(compra_id),
	
);
GO

CREATE TABLE DBME.factura(
	factura_id NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,
	compra_id INT FOREIGN KEY REFERENCES DBME.compra(compra_id),
	fecha DATETIME,
	monto_total NUMERIC(18,2) NOT NULL,
	forma_pago_desc NVARCHAR(255)
);
GO

CREATE TABLE DBME.factura_detalle(
	factura_detalle_id INT IDENTITY(1,1) PRIMARY KEY,
	factura_cantidad NUMERIC(18,0),
	tipo_de_item VARCHAR(64) CHECK(tipo_de_item IN ('PRODUCTO','ENVIO','VISIBILIDAD','INDEFINIDO')), /* costo de producto, o costo de envio, o costo de publicacion  */
	factura_id NUMERIC(18,0) FOREIGN KEY REFERENCES DBME.factura(factura_id),
	monto_parcial NUMERIC(18,2)
);
GO

/* END CREACION TABLAS*/
--*****************************************************************




/* START BASES DE MIGRACION */ 

CREATE PROCEDURE DBME.crearFuncionalidades
AS
BEGIN
	
	INSERT INTO DBME.funcionalidad (descripcion) VALUES ('ABM DE ROL');
	INSERT INTO DBME.funcionalidad (descripcion) VALUES ('ABM DE USUARIOS');
	INSERT INTO DBME.funcionalidad (descripcion) VALUES ('ABM DE RUBRO');
	INSERT INTO DBME.funcionalidad (descripcion) VALUES ('ABM DE VISIBILIDAD DE PUBLICACION');
	INSERT INTO DBME.funcionalidad (descripcion) VALUES ('GENERAR PUBLICACION');
	INSERT INTO DBME.funcionalidad (descripcion) VALUES ('COMPRAR/OFERTAR');
	INSERT INTO DBME.funcionalidad (descripcion) VALUES ('HISTORIAL DEL CLIENTE');
	INSERT INTO DBME.funcionalidad (descripcion) VALUES ('CALIFICAR AL VENDEDOR');
	INSERT INTO DBME.funcionalidad (descripcion) VALUES ('CONSULTA DE FACTURAS REALIZADAS AL VENDEDOR');
	INSERT INTO DBME.funcionalidad (descripcion) VALUES ('LISTADO ESTADISTICO');

END;
GO

CREATE PROCEDURE DBME.crearRoles
AS
BEGIN
	
	INSERT INTO DBME.rol(nombre_rol,es_rol_habilitado) VALUES ('Administrador',1);
	INSERT INTO DBME.rol(nombre_rol,es_rol_habilitado) VALUES ('Cliente',1);
	INSERT INTO DBME.rol(nombre_rol,es_rol_habilitado) VALUES ('Empresa',1);

END;
GO

CREATE PROCEDURE DBME.enlazarRol_X_Funcionalidad  -- agregar funcionalidades para cada rol
AS
BEGIN
	
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id)
	SELECT 1,funcionalidad_id
	FROM DBME.funcionalidad
	UNION
	SELECT 2,funcionalidad_id
	FROM DBME.funcionalidad
	UNION
	SELECT 3,funcionalidad_id
	FROM DBME.funcionalidad

END;
GO

CREATE PROCEDURE DBME.migrarDomicilio2
AS
BEGIN

	INSERT INTO DBME.domicilio(codigo_postal,domicilio_calle,numero_calle,piso,departamento)
	SELECT Publ_Cli_Cod_Postal,Publ_Cli_Dom_Calle,Publ_Cli_Nro_Calle,Publ_Cli_Piso,Publ_Cli_Depto
	FROM gd_esquema.Maestra
	WHERE Publ_Cli_Cod_Postal IS NOT NULL
	UNION
	SELECT Publ_Empresa_Cod_Postal,Publ_Empresa_Dom_Calle,Publ_Empresa_Nro_Calle,Publ_Empresa_Piso,Publ_Empresa_Depto
	FROM gd_esquema.Maestra
	WHERE Publ_Empresa_Cod_Postal IS NOT NULL

END;
GO

CREATE PROCEDURE DBME.migrarClientes  -- de PUBL CLI
AS
BEGIN

	INSERT INTO DBME.usuario(mail,username,password,habilitado,cantidad_intentos_fallidos,domicilio_id ,fecha_creacion,telefono,es_nuevo)
	SELECT DISTINCT Publ_Cli_Mail, Publ_Cli_Mail,Publ_Cli_Mail,1,0, d.domicilio_id ,GETDATE(),NULL,1
	FROM gd_esquema.Maestra m JOIN DBME.domicilio d ON (m.Publ_Cli_Cod_Postal = d.codigo_postal)
	WHERE Publ_Cli_Mail IS NOT NULL
	
	INSERT INTO DBME.cliente(usuario_id,apellido,nombre,numero_documento,tipo_documento,fecha_nacimiento)
	SELECT DISTINCT u.usuario_id, m.Publ_Cli_Apeliido, m.Publ_Cli_Nombre,m.Publ_Cli_Dni,'D',m.Publ_Cli_Fecha_Nac
	FROM gd_esquema.Maestra m JOIN DBME.usuario u ON (m.Publ_Cli_Mail = u.mail)


	
END;
GO

CREATE PROCEDURE DBME.migrarEmpresas
AS
BEGIN
	
	INSERT INTO DBME.usuario(mail,username,password,habilitado,cantidad_intentos_fallidos,domicilio_id ,fecha_creacion,telefono,es_nuevo)
	SELECT DISTINCT Publ_Empresa_Mail, Publ_Empresa_Mail,Publ_Empresa_Mail,1,0, d.domicilio_id ,GETDATE(),NULL,1
	FROM gd_esquema.Maestra m JOIN DBME.domicilio d ON (m.Publ_Empresa_Cod_Postal = d.codigo_postal)
	WHERE Publ_Empresa_Mail IS NOT NULL
	
	INSERT INTO DBME.empresa(usuario_id,razon_social,cuit,fecha_creacion)
	SELECT DISTINCT u.usuario_id,Publ_Empresa_Razon_Social,Publ_Empresa_Cuit,Publ_Empresa_Fecha_Creacion
	FROM gd_esquema.Maestra m JOIN DBME.usuario u ON (m.Publ_Empresa_Mail = u.mail) 


	
END;
GO

CREATE PROCEDURE DBME.enlazarRol_X_Usuario
AS
BEGIN
	
	INSERT INTO DBME.rol_x_usuario(rol_id,usuario_id)
	SELECT 2, u.usuario_id 
	FROM DBME.usuario u JOIN DBME.cliente c ON (u.usuario_id=c.usuario_id)
	UNION
	SELECT 3, u.usuario_id 
	FROM DBME.usuario u JOIN DBME.empresa e ON (u.usuario_id=e.usuario_id)
	
END;
GO

CREATE PROCEDURE DBME.migrarRubro
AS 
BEGIN

	INSERT INTO DBME.rubro(descripcion_larga,descripcion_corta)
	SELECT DISTINCT NULL,Publicacion_Rubro_Descripcion
	FROM gd_esquema.Maestra

END;
GO

CREATE PROCEDURE DBME.migrarVisibilidad
AS
BEGIN

	--Se migran los fabricante de la tabla Maestra
	INSERT INTO DBME.visibilidad(visibilidad_id, visibilidad_descripcion, visibilidad_porcentaje, visibilidad_precio, visibilidad_costo_envio)
	SELECT DISTINCT Publicacion_Visibilidad_Cod, Publicacion_Visibilidad_Desc, Publicacion_Visibilidad_Porcentaje, Publicacion_Visibilidad_Precio, (180 - Publicacion_Visibilidad_Precio)
	FROM gd_esquema.Maestra
	ORDER BY Publicacion_Visibilidad_Cod

	UPDATE DBME.visibilidad
	SET visibilidad_costo_envio = (180 - visibilidad_precio)
	
	UPDATE DBME.visibilidad
	SET visibilidad_costo_envio = 0
	WHERE visibilidad_descripcion = 'Gratis'

END;
GO

CREATE PROCEDURE DBME.migrarFacturas
AS
BEGIN
	
	SET IDENTITY_INSERT DBME.factura ON;
	SET IDENTITY_INSERT DBME.factura_detalle OFF;
	
	INSERT INTO DBME.factura(factura_id,fecha,monto_total,forma_pago_desc)
	SELECT DISTINCT Factura_Nro,Factura_Fecha,Factura_Total,Forma_Pago_Desc
	FROM gd_esquema.Maestra
	WHERE Factura_Nro IS NOT NULL

	INSERT INTO DBME.factura_detalle(factura_id,factura_cantidad,monto_parcial,tipo_de_item)
	SELECT Factura_Nro,Item_Factura_Cantidad,Item_Factura_Monto,'INDEFINIDO'
	FROM gd_esquema.Maestra 
	WHERE Factura_Nro IS NOT NULL


END;
GO

CREATE PROCEDURE DBME.migrarCalificaciones
AS
BEGIN
	SET IDENTITY_INSERT DBME.calificacion ON;

	INSERT INTO DBME.calificacion(calificacion_id,cantidad_estrellas,autor_id,descripcion)
	SELECT m.Calificacion_Codigo,m.Calificacion_Cant_Estrellas/2,u.usuario_id,'Sin descripción'
	FROM gd_esquema.Maestra m LEFT JOIN DBME.usuario u ON (m.Cli_Mail=u.mail)
	WHERE Calificacion_Codigo IS NOT NULL
END;
GO

CREATE PROCEDURE DBME.devolverIdDeMail(
	@Publ_Mail NVARCHAR(255),
	@usuario_id INT OUT)
AS
BEGIN
	SELECT DISTINCT @usuario_id = usuario_id 
	FROM DBME.usuario u
	WHERE @Publ_Mail = u.mail
END;
GO

CREATE PROCEDURE DBME.migrarOfertas
AS
BEGIN

	DECLARE cursor_para_ofertas CURSOR FOR
	SELECT Publ_Empresa_Mail,Publ_Cli_Mail,Publicacion_Cod,Oferta_Monto,Oferta_Fecha
	FROM gd_esquema.Maestra
	WHERE Oferta_Fecha IS NOT NULL

	DECLARE @Publ_Empresa_Mail AS NVARCHAR(255)
	DECLARE @Publ_Cli_Mail AS NVARCHAR(255)
	DECLARE @Publicacion_Cod AS NUMERIC(18,0)
	DECLARE @Oferta_Monto AS NUMERIC(18,2)
	DECLARE @Oferta_Fecha AS DATETIME
	DECLARE @usuario_id AS INT
	DECLARE @oferta_id AS INT

	OPEN cursor_para_ofertas 
	FETCH cursor_para_ofertas INTO @Publ_Empresa_Mail,@Publ_Cli_Mail,@Publicacion_Cod,@Oferta_Monto,@Oferta_Fecha

	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			IF (@Publ_Empresa_Mail IS NOT NULL)
				BEGIN
					EXECUTE DBME.devolverIdDeMail @Publ_Empresa_Mail,@usuario_id OUT

					INSERT INTO DBME.oferta (monto,fecha,autor_id,publicacion_id)
					VALUES (@Oferta_Monto,@Oferta_Fecha,@usuario_id,@Publicacion_Cod)
				END
			ELSE
				BEGIN
					EXECUTE DBME.devolverIdDeMail @Publ_Cli_Mail,@usuario_id OUT

					INSERT INTO DBME.oferta (monto,fecha,autor_id,publicacion_id)
					VALUES (@Oferta_Monto,@Oferta_Fecha,@usuario_id,@Publicacion_Cod)
				END
			FETCH cursor_para_ofertas INTO @Publ_Empresa_Mail,@Publ_Cli_Mail,@Publicacion_Cod,@Oferta_Monto,@Oferta_Fecha
		END
	CLOSE cursor_para_ofertas
	DEALLOCATE cursor_para_ofertas
END;
GO

CREATE PROCEDURE DBME.devolverIdRubroDeDescripcion (
	@Publicacion_Rubro_Descripcion NVARCHAR(255),
	@rubro_id INT OUT)
AS
BEGIN
	SELECT DISTINCT @rubro_id = rubro_id 
	FROM DBME.rubro
	WHERE descripcion_corta = @Publicacion_Rubro_Descripcion
END;
GO

CREATE PROCEDURE DBME.migrarPublicaciones
AS
BEGIN

	SET IDENTITY_INSERT DBME.publicacion ON;

	DECLARE cursor_para_publicaciones CURSOR FOR
	SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha,Publicacion_Fecha_Venc,Publicacion_Precio,
	Publicacion_Estado,Publicacion_Tipo,Publicacion_Rubro_Descripcion,Publicacion_Visibilidad_Cod,Publ_Cli_Mail,Publ_Empresa_Mail
	FROM gd_esquema.Maestra

	DECLARE @Publicacion_Cod AS NUMERIC(18,0)
	DECLARE @Publicacion_Descripcion AS NVARCHAR(255) 
	DECLARE @Publicacion_Tipo AS NVARCHAR(255)
	DECLARE @Publicacion_Stock AS NUMERIC(18,0)
	DECLARE @Publicacion_Fecha AS DATETIME
	DECLARE @Publicacion_Fecha_Venc AS DATETIME
	DECLARE @Publicacion_Precio AS NUMERIC(18,2)
	DECLARE @Publicacion_Estado AS NVARCHAR(255)
	DECLARE @Publicacion_Rubro_Descripcion AS NVARCHAR(255)
	DECLARE @rubro_id AS INT
	DECLARE @Publicacion_Visibilidad_Cod AS NUMERIC(18,0)
	DECLARE @Publ_Cli_Mail AS NVARCHAR(255)
	DECLARE @Publ_Empresa_Mail AS NVARCHAR(255)
	DECLARE @usuario_id AS INT

	OPEN cursor_para_publicaciones
	FETCH cursor_para_publicaciones INTO @Publicacion_Cod,@Publicacion_Descripcion,@Publicacion_Stock,@Publicacion_Fecha,
	@Publicacion_Fecha_Venc,@Publicacion_Precio,@Publicacion_Estado,@Publicacion_Tipo,@Publicacion_Rubro_Descripcion,@Publicacion_Visibilidad_Cod,@Publ_Cli_Mail,@Publ_Empresa_Mail
	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			EXECUTE DBME.devolverIdRubroDeDescripcion @Publicacion_Rubro_Descripcion,@rubro_id OUT
			
			IF (@publicacion_tipo = 'Compra Inmediata')
			BEGIN
				IF (@Publ_Cli_Mail IS NOT NULL)
				BEGIN
					EXECUTE DBME.devolverIdDeMail @Publ_Cli_Mail,@usuario_id OUT
				END
				ELSE
				BEGIN
					EXECUTE DBME.devolverIdDeMail @Publ_Empresa_Mail,@usuario_id OUT
				END
				INSERT INTO DBME.publicacion(publicacion_id,descripcion,stock,fecha_creacion,fecha_vencimiento,precio,publicacion_tipo,estado,permite_preguntas,realiza_envio,rubro_id,visibilidad_id,autor_id,cantidad)
				VALUES (@Publicacion_Cod,@Publicacion_Descripcion,@Publicacion_Stock,@Publicacion_Fecha,@Publicacion_Fecha_Venc,@Publicacion_Precio,@Publicacion_Tipo,'FINALIZADA',1,0,@rubro_id,@Publicacion_Visibilidad_Cod,@usuario_id,0)
			END
			ELSE
			BEGIN
				IF(@Publ_Cli_Mail IS NOT NULL)
				BEGIN
					EXECUTE DBME.devolverIdDeMail @Publ_Cli_Mail,@usuario_id OUT
					END
				ELSE
				BEGIN
					EXECUTE DBME.devolverIdDeMail @Publ_Empresa_Mail,@usuario_id OUT
				END
				INSERT INTO DBME.publicacion(publicacion_id,descripcion,stock,fecha_creacion,fecha_vencimiento,publicacion_tipo,estado,permite_preguntas,realiza_envio,rubro_id,visibilidad_id,autor_id,cantidad)
				VALUES (@Publicacion_Cod,@Publicacion_Descripcion,@Publicacion_Stock,@Publicacion_Fecha,@Publicacion_Fecha_Venc,@Publicacion_Tipo,'FINALIZADA',1,0,@rubro_id,@Publicacion_Visibilidad_Cod,@usuario_id,0)
				
			END
			FETCH cursor_para_publicaciones INTO @Publicacion_Cod,@Publicacion_Descripcion,@Publicacion_Stock,@Publicacion_Fecha,@Publicacion_Fecha_Venc,@Publicacion_Precio,
			@Publicacion_Estado,@Publicacion_Tipo,@Publicacion_Rubro_Descripcion,@Publicacion_Visibilidad_Cod,@Publ_Cli_Mail,@Publ_Empresa_Mail
		END
	CLOSE cursor_para_publicaciones
	DEALLOCATE cursor_para_publicaciones
END;
GO

CREATE PROCEDURE DBME.migrarCompras
AS
BEGIN

	DECLARE cursor_para_compras CURSOR FOR
	SELECT Compra_Fecha,Compra_Cantidad,Publicacion_Cod,u.usuario_id,Calificacion_Codigo
	FROM gd_esquema.Maestra m JOIN DBME.usuario u ON (m.Cli_Mail=u.mail)
	WHERE Compra_Fecha IS NOT NULL AND Calificacion_Codigo IS NOT NULL

	DECLARE @Compra_Fecha AS DATETIME
	DECLARE @Compra_Cantidad AS NUMERIC(18,0)
	DECLARE @Publicacion_Cod AS NUMERIC(18,0)
	DECLARE @usuario_id AS INT
	DECLARE @Calificacion_Codigo AS INT

	OPEN cursor_para_compras
	FETCH cursor_para_compras INTO @Compra_Fecha,@Compra_Cantidad,@Publicacion_Cod,@usuario_id,@Calificacion_Codigo
	WHILE(@@FETCH_STATUS = 0)
		BEGIN
			INSERT INTO DBME.compra(fecha,cantidad,publicacion_id,autor_id,esta_calificada)
			VALUES (@Compra_Fecha,@Compra_Cantidad,@Publicacion_Cod,@usuario_id,1)

			UPDATE DBME.calificacion SET compra_id = SCOPE_IDENTITY() WHERE calificacion_id = @Calificacion_Codigo

			FETCH cursor_para_compras INTO @Compra_Fecha,@Compra_Cantidad,@Publicacion_Cod,@usuario_id,@Calificacion_Codigo
		END
	CLOSE cursor_para_compras
	DEALLOCATE cursor_para_compras
	
END;
GO

SELECT * FROM DBME.publicacion


/* END BASES DE MIGRACION */ 

/* START MIGRACION*/ --      EJECUTAR LOS PROCEDURES !!!!

	EXECUTE DBME.crearFuncionalidades
	EXECUTE DBME.crearRoles
	EXECUTE DBME.enlazarRol_X_Funcionalidad
	EXECUTE DBME.migrarDomicilio2
	EXECUTE DBME.migrarRubro
	EXECUTE DBME.migrarClientes
	EXECUTE DBME.migrarEmpresas
	EXECUTE DBME.migrarFacturas
	EXECUTE DBME.enlazarRol_X_Usuario
	EXECUTE DBME.migrarVisibilidad
	EXECUTE DBME.migrarPublicaciones
	EXECUTE DBME.migrarCalificaciones
	EXECUTE DBME.migrarCompras
	EXECUTE DBME.migrarOfertas

	GO


/* END MIGRACION */


/* START TRIGGERS */

/* END TRIGGERS */

/* START FUNCTIONS */

CREATE FUNCTION DBME.topVendedoresConMayorCantidadDeProductosNoVendidos(@mes TINYINT,@anio INTEGER,@visibilidad NUMERIC (18,0))
RETURNS @TABLA_RESULTADO TABLE ( id_vendedor INT, nombre_vendedor NVARCHAR(255), apellido_vendedor NVARCHAR(255), cantidad_productos_sin_vender BIGINT)
AS 
BEGIN 
	INSERT INTO @TABLA_RESULTADO(id_vendedor,nombre_vendedor,apellido_vendedor,cantidad_productos_sin_vender)
	select ciudad, localidad, codigo_postal from dbme.domicilio						
	--aca va la funcion posta

	RETURN
END;
GO


CREATE FUNCTION DBME.topClientesConMayorCantidadDeProductosComprados(@mes TINYINT,@anio INTEGER,@rubro NVARCHAR(255))
RETURNS @TABLA_RESULTADO TABLE ( id_cliente INT, nombre_cliente NVARCHAR(255), apellido_cliente NVARCHAR(255), cantidad_productos_comprados BIGINT)
AS 
BEGIN 
	INSERT INTO @TABLA_RESULTADO(id_cliente,nombre_cliente,apellido_cliente,cantidad_productos_comprados)
	select ciudad, localidad, codigo_postal from dbme.domicilio
	--aca va la funcion posta

	RETURN
END;
GO

CREATE FUNCTION DBME.topVendedoresConMayorCantidadDeFacturas(@mes TINYINT,@anio INTEGER)-- dentro de un mes y año particular
RETURNS @TABLA_RESULTADO TABLE ( id_vendedor INT, nombre_vendedor NVARCHAR(255), apellido_vendedor NVARCHAR(255), cantidad_facturas BIGINT)
AS 
BEGIN 
	INSERT INTO @TABLA_RESULTADO(id_vendedor,nombre_vendedor,apellido_vendedor,cantidad_facturas)
	select ciudad, localidad, codigo_postal from dbme.domicilio						
	--aca va la funcion posta

	RETURN
END;
GO

CREATE FUNCTION DBME.topVendedoresConMayorMontoFacturado(@mes TINYINT,@anio INTEGER)-- dentro de un mes y año particular
RETURNS @TABLA_RESULTADO TABLE ( id_vendedor INT, nombre_vendedor NVARCHAR(255), apellido_vendedor NVARCHAR(255), monto_facturado BIGINT)
AS 
BEGIN 
	INSERT INTO @TABLA_RESULTADO(id_vendedor,nombre_vendedor,apellido_vendedor,monto_facturado)
	select ciudad, localidad, codigo_postal from dbme.domicilio						
	--aca va la funcion posta

	RETURN
END;
GO

/* END FUNCTIONS */


/* START PROCEDURES CREACIONALES */

CREATE PROCEDURE DBME.crearDomicilio (
	
	@ciudad NVARCHAR(255),
	@localidad NVARCHAR(255),
	@codigo_postal NVARCHAR(50),
	@piso NUMERIC(18,0),
	@departamento NVARCHAR(50),
	@domicilio_calle NVARCHAR(255),
	@numero_calle NUMERIC(18,0),
	@domicilio_id INT OUT)
AS
BEGIN
	

	INSERT INTO DBME.domicilio(ciudad,localidad,codigo_postal,piso,departamento,domicilio_calle,numero_calle)
	VALUES (@ciudad,@localidad,@codigo_postal,@piso,@departamento,@domicilio_calle,@numero_calle)

	SET @domicilio_id = SCOPE_IDENTITY()

END;
GO

CREATE PROCEDURE DBME.crearUsuario(
	@username NVARCHAR(255),
	@password NVARCHAR(255),
	@mail NVARCHAR(255),
	@telefono BIGINT,
	@ciudad NVARCHAR(255),
	@localidad NVARCHAR(255),
	@codigo_postal NVARCHAR(50),
	@piso NUMERIC(18,0),
	@departamento NVARCHAR(50),
	@domicilio_calle NVARCHAR(255),
	@numero_calle NUMERIC(18,0),
	@usuario_id INT OUT)
AS
BEGIN

	DECLARE @domicilio_id AS INT 
	EXECUTE DBME.crearDomicilio @ciudad,@localidad,@codigo_postal,@piso,@departamento,@domicilio_calle,@numero_calle,@domicilio_id OUT

	INSERT INTO DBME.usuario(username,password,habilitado,cantidad_intentos_fallidos,mail,domicilio_id,fecha_creacion,telefono,es_nuevo)
	VALUES (@username,@password,1,0,@mail,@domicilio_id,GETDATE(),@telefono,1)

	SET @usuario_id = SCOPE_IDENTITY()
END;
GO

CREATE PROCEDURE DBME.crearCliente(
	@apellido NVARCHAR(255),
	@nombre NVARCHAR(255),
	@numero_documento NUMERIC(18,0),
	@tipo_documento CHAR,
	@fecha_nacimiento DATETIME,
	@username NVARCHAR(255),
	@password NVARCHAR(255),
	@mail NVARCHAR(255),
	@telefono BIGINT,
	@ciudad NVARCHAR(255),
	@localidad NVARCHAR(255),
	@codigo_postal NVARCHAR(50),
	@piso NUMERIC(18,0),
	@departamento NVARCHAR(50),
	@domicilio_calle NVARCHAR(255),
	@numero_calle NUMERIC(18,0),
	@cliente_id INT OUT)
AS
BEGIN
	
	DECLARE @usuario_id AS INT

	EXECUTE DBME.crearUsuario @username,@password,@mail,@telefono,@ciudad,@localidad,@codigo_postal,@piso,@departamento,@domicilio_calle,@numero_calle, @usuario_id OUT
	
	INSERT INTO DBME.cliente(apellido,nombre,numero_documento,tipo_documento,fecha_nacimiento,usuario_id)
	VALUES (@apellido,@nombre,@numero_documento,@tipo_documento,@fecha_nacimiento,@usuario_id)

	SET @cliente_id = SCOPE_IDENTITY()
	
	INSERT INTO DBME.rol_x_usuario (usuario_id,rol_id)
	VALUES (@usuario_id,2)

END;
GO

CREATE PROCEDURE DBME.crearEmpresa(
	@razon_social NVARCHAR(255),
	@cuit NVARCHAR(50),
	@fecha_creacion DATETIME,
	@nombre_contacto VARCHAR(25),
	@rubro_id INT,
	@username NVARCHAR(255),
	@password NVARCHAR(255),
	@mail NVARCHAR(255),
	@telefono BIGINT,
	@ciudad NVARCHAR(255),
	@localidad NVARCHAR(255),
	@codigo_postal NVARCHAR(50),
	@piso NUMERIC(18,0),
	@departamento NVARCHAR(50),
	@domicilio_calle NVARCHAR(255),
	@numero_calle NUMERIC(18,0),
	@cliente_id INT OUT)
AS
BEGIN
	
	DECLARE @usuario_id AS INT

	EXECUTE DBME.crearUsuario @username,@password,@mail,@telefono,@ciudad,@localidad,@codigo_postal,@piso,@departamento,@domicilio_calle,@numero_calle, @usuario_id OUT
	
	INSERT INTO DBME.empresa(razon_social,cuit,fecha_creacion,nombre_contacto,rubro_id,usuario_id)
	VALUES (@razon_social,@cuit,@fecha_creacion,@nombre_contacto,@rubro_id,@usuario_id)

	SET @cliente_id = SCOPE_IDENTITY()

	INSERT INTO DBME.rol_x_usuario (usuario_id,rol_id)
	VALUES (@usuario_id,3)

END;
GO

CREATE PROCEDURE DBME.crearAdministradores
AS
BEGIN

	DECLARE @usuario_id AS INT
										--w23e encriptado
	EXECUTE DBME.crearUsuario 'admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL, @usuario_id OUT
	INSERT INTO DBME.administrador(nombre,apellido,usuario_id)
	VALUES ('Administrador','General',@usuario_id)
	INSERT INTO DBME.rol_x_usuario (usuario_id,rol_id)
	VALUES (@usuario_id,1)
END;
GO

--UPDATE DBME.usuario SET habilitado = '0' WHERE username = 'sapo'
--select * from DBME.usuario where usuario.username = 'sapo'


BEGIN TRANSACTION
DECLARE @usuario_id AS INT
EXECUTE DBME.crearUsuario 'a','a','metodoGuede@sanLorenzo.com.br',NULL,NULL,NULL,NULL,NULL,NULL,'Orticalle','1000', @usuario_id OUT
INSERT INTO DBME.administrador(nombre,apellido,usuario_id)
VALUES ('Pablo','Guede',@usuario_id)
EXECUTE DBME.crearAdministradores
SELECT * FROM DBME.administrador a JOIN DBME.usuario u ON (a.usuario_id=u.usuario_id)
DROP PROCEDURE DBME.crearDomicilio
DROP PROCEDURE DBME.crearUsuario
DROP PROCEDURE DBME.crearCliente
DECLARE @cliente_id AS INT
EXECUTE DBME.crearCliente 'do interest','sapinho','38355825','D','20120618 10:34:09 AM','sapo','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7','sapinhododeus@gemeil.com','1565212592','CABA','CABA','1102','0','6','Carlos Calvo','1781',@cliente_id OUT
SELECT rubro_id,descripcion_larga FROM DBME.  
SELECT nombre,apellido,numero_documento,tipo_documento FROM DBME.cliente WHERE numero_documento = '38355825'
ROLLBACK TRANSACTION


select nombre_rol,rxu.rol_id 
from dbme.rol r join dbme.rol_x_usuario rxu ON (rxu.rol_id = r.rol_id)
--WHERE usuario_id = 100 AND es_rol_habilitado = 1

/* END PROCEDURES CREACIONALES */

/* START PROCEDURES COMUNICACION */

EXECUTE DBME.crearAdministradores




EXECUTE DBME.loginUsuario 'sapo','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'

CREATE PROCEDURE DBME.loginUsuario (@username nvarchar(255),@contrasenia nvarchar(255))
AS
BEGIN
	DECLARE @u_id INT
	DECLARE @u_password NVARCHAR(255)
	DECLARE @u_habilitado bit
	DECLARE @cantidad_intentos_fallidos tinyint
	DECLARE @mensaje_error varchar(100)
	

	SELECT @u_id = DBME.usuario.usuario_id, @u_password = usuario.password, @u_habilitado = habilitado, @cantidad_intentos_fallidos = DBME.usuario.cantidad_intentos_fallidos
	FROM DBME.usuario
	WHERE DBME.usuario.username = @username 

	
	IF (@U_id IS NULL)
	BEGIN
		-- no se encontro usuario
		SET @mensaje_error = 'El usuario ingresado no existe'
		RAISERROR(@mensaje_error, 12, 1)
		
	END
	
	IF (@u_habilitado = 0)
	BEGIN
		-- el usuario esta deshabilitado
		SET @mensaje_error = 'El usuario se encuentra deshabilitado'
		RAISERROR(@mensaje_error, 12, 1)
		
	END
	
	IF (@contrasenia != @u_password)
	BEGIN
		SET @cantidad_intentos_fallidos = @cantidad_intentos_fallidos + 1
		UPDATE DBME.usuario SET cantidad_intentos_fallidos = @cantidad_intentos_fallidos WHERE usuario_id = @u_id
		
		IF (@cantidad_intentos_fallidos > 2)
		BEGIN
			UPDATE DBME.usuario SET usuario.habilitado = 0 WHERE usuario_id = @u_id
			SET @mensaje_error = 'Supero la cantidad de intentos fallidos: el usuario se encuentra deshabilitado a partir de ahora'
			RAISERROR(@mensaje_error, 12, 1)
			
		END
		ELSE
		BEGIN 
			SET @mensaje_error = 'Contrasenia incorrecta'
			RAISERROR(@mensaje_error, 12, 1)
		
		END
	END 

	IF (@contrasenia = @u_password)
	BEGIN
		UPDATE DBME.usuario SET cantidad_intentos_fallidos = 0 WHERE DBME.usuario.usuario_id = @u_id
		
		SELECT DBME.usuario.usuario_id
		FROM DBME.usuario
		WHERE DBME.usuario.username = @username 
	END
	
END;
GO

SELECT f.funcionalidad_id,descripcion FROM DBME.funcionalidad f JOIN DBME.rol_x_funcionalidad rxf ON (f.funcionalidad_id=rxf.funcionalidad_id) WHERE rol_id = 1

SELECT r.rol_id,nombre_rol
FROM DBME.rol r JOIN DBME.rol_x_usuario rxu
	ON (r.rol_id=rxu.rol_id) 
WHERE r.es_rol_habilitado = 1 AND rxu.usuario_id = 96

SELECT * FROM DBME.usuario WHERE username = 'admin'

SELECT r.rol_id,nombre_rol 
FROM DBME.rol r JOIN DBME.rol_x_usuario rxu 
	ON (r.rol_id=rxu.rol_id) 
WHERE r.es_rol_habilitado = 1 AND usuario_id = 102--JOIN DBME.funcionalidad
/* END PROCEDURES COMUNICACION */