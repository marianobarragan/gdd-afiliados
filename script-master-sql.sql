USE[GD1C2016];
GO

CREATE SCHEMA [DBME] AUTHORIZATION [gd];
GO

/* START CREACION TABLAS */

CREATE TABLE DBME.funcionalidad (
	funcionalidad_id INT IDENTITY(1,1) PRIMARY KEY,
	descripcion NVARCHAR(255) UNIQUE
);
GO

CREATE TABLE DBME.rol (
	rol_id INT IDENTITY(1,1) PRIMARY KEY,
	nombre_rol NVARCHAR(255) UNIQUE,
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
	mail NVARCHAR(255) UNIQUE,
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
	tipo_documento NVARCHAR(3) CHECK(tipo_documento IN ('DNI','LE','LC')),
	fecha_nacimiento DATETIME,
	habilitado BIT,
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
	usuario_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id),
	habilitado BIT
);
GO

CREATE TABLE DBME.administrador(
	administrador_id INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(16),
	apellido VARCHAR(25),
	usuario_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id)
);
GO

CREATE TABLE DBME.visibilidad( --INT IDENTITY(1,1) PRIMARY KEY
	visibilidad_id NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,
	visibilidad_descripcion NVARCHAR(255) UNIQUE,
	visibilidad_precio NUMERIC(18,2), 
	visibilidad_porcentaje NUMERIC(18,2) CHECK(visibilidad_porcentaje BETWEEN '0' AND '1'),
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
	fecha_finalizacion_subasta DATETIME,
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
	publicacion_id NUMERIC(18,0) FOREIGN KEY REFERENCES DBME.publicacion(publicacion_id),
	fecha DATETIME,
	monto_total NUMERIC(18,2) NOT NULL,
	forma_pago_desc NVARCHAR(255),
	usuario_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id)
);
GO

CREATE TABLE DBME.factura_detalle(
	factura_detalle_id INT IDENTITY(1,1) PRIMARY KEY,
	factura_cantidad NUMERIC(18,0),
	tipo_de_item VARCHAR(64), 
	factura_id NUMERIC(18,0) FOREIGN KEY REFERENCES DBME.factura(factura_id),
	monto_parcial NUMERIC(18,2)
);
GO

CREATE TABLE DBME.reloj(
	hora_actual DATETIME
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

CREATE PROCEDURE DBME.enlazarRolXFuncionalidad (@nombre_rol NVARCHAR(255),@nombre_funcionalidad NVARCHAR(255) )
AS
BEGIN
	
	DECLARE @rol_id AS INT
	DECLARE @funcionalidad_id AS INT

	SELECT @rol_id = rol_id
	FROM DBME.rol 
	WHERE @nombre_rol = nombre_rol

	SELECT @funcionalidad_id = funcionalidad_id
	FROM DBME.funcionalidad 
	WHERE @nombre_funcionalidad = descripcion

	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id)
	VALUES (@rol_id,@funcionalidad_id)

END;
GO


CREATE PROCEDURE DBME.enlazarRol_X_Funcionalidad  -- agregar funcionalidades para cada rol
AS
BEGIN
	
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id)
	SELECT 1,funcionalidad_id
	FROM DBME.funcionalidad
	
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id) VALUES (2,4)
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id) VALUES (2,5)
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id) VALUES (2,6)
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id) VALUES (2,7)
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id) VALUES (2,8)
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id) VALUES (2,9)
	
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id) VALUES (3,4)
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id) VALUES (3,8)
	INSERT INTO DBME.rol_x_funcionalidad(rol_id,funcionalidad_id) VALUES (3,9)

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

--SELECT SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('SHA2_256', 'w23e')), 3, 250) 

--SELECT HASHBYTES('SHA2_256','w23e'),'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7' FROM 
CREATE PROCEDURE DBME.migrarClientes  -- de PUBL CLI
AS
BEGIN


	INSERT INTO DBME.usuario(mail,username,password,habilitado,cantidad_intentos_fallidos,domicilio_id,fecha_creacion,telefono,es_nuevo)
	SELECT DISTINCT Publ_Cli_Mail,Publ_Cli_Mail,HASHBYTES('SHA2_256',Publ_Cli_Mail),1,0, d.domicilio_id ,NULL,NULL,0
	FROM gd_esquema.Maestra m JOIN DBME.domicilio d ON (m.Publ_Cli_Cod_Postal = d.codigo_postal)
	WHERE Publ_Cli_Mail IS NOT NULL
	
	INSERT INTO DBME.cliente(usuario_id,apellido,nombre,numero_documento,tipo_documento,fecha_nacimiento,habilitado)
	SELECT DISTINCT u.usuario_id, m.Publ_Cli_Apeliido, m.Publ_Cli_Nombre,m.Publ_Cli_Dni,'DNI',m.Publ_Cli_Fecha_Nac,1
	FROM gd_esquema.Maestra m JOIN DBME.usuario u ON (m.Publ_Cli_Mail = u.mail)
	
	
	--UPDATE DBME.usuario SET password = SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('SHA2_256', password)), 3, 250)

		
END;
GO

CREATE PROCEDURE DBME.migrarEmpresas
AS
BEGIN
	
	INSERT INTO DBME.usuario(mail,username,password,habilitado,cantidad_intentos_fallidos,domicilio_id ,fecha_creacion,telefono,es_nuevo)
	SELECT DISTINCT Publ_Empresa_Mail, Publ_Empresa_Mail,HASHBYTES('SHA2_256',Publ_Empresa_Mail),1,0, d.domicilio_id ,NULL,NULL,0
	FROM gd_esquema.Maestra m JOIN DBME.domicilio d ON (m.Publ_Empresa_Cod_Postal = d.codigo_postal)
	WHERE Publ_Empresa_Mail IS NOT NULL
	
	INSERT INTO DBME.empresa(usuario_id,razon_social,cuit,fecha_creacion,habilitado)
	SELECT DISTINCT u.usuario_id,Publ_Empresa_Razon_Social,Publ_Empresa_Cuit,Publ_Empresa_Fecha_Creacion,1
	FROM gd_esquema.Maestra m JOIN DBME.usuario u ON (m.Publ_Empresa_Mail = u.mail) 

	--UPDATE DBME.usuario SET password = SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('SHA2_256', password)), 3, 250) 
	
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
	INSERT INTO DBME.visibilidad( visibilidad_descripcion, visibilidad_porcentaje, visibilidad_precio, visibilidad_costo_envio)
	SELECT DISTINCT Publicacion_Visibilidad_Desc, Publicacion_Visibilidad_Porcentaje, Publicacion_Visibilidad_Precio, (180 - Publicacion_Visibilidad_Precio)
	FROM gd_esquema.Maestra

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
	
	INSERT INTO DBME.factura(factura_id,fecha,monto_total,forma_pago_desc,usuario_id,publicacion_id)
	(SELECT DISTINCT Factura_Nro,Factura_Fecha,Factura_Total,Forma_Pago_Desc,u.usuario_id,Publicacion_Cod
	FROM gd_esquema.Maestra m LEFT JOIN DBME.usuario u ON (m.Publ_Cli_Mail = u.mail)
	WHERE Factura_Nro IS NOT NULL AND Publ_Cli_Mail IS NOT NULL
	UNION
	SELECT DISTINCT Factura_Nro,Factura_Fecha,Factura_Total,Forma_Pago_Desc,u.usuario_id,Publicacion_Cod
	FROM gd_esquema.Maestra m LEFT JOIN DBME.usuario u ON (m.Publ_Empresa_Mail= u.mail)
	WHERE Factura_Nro IS NOT NULL AND Publ_Empresa_Mail IS NOT NULL)

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

	INSERT INTO DBME.calificacion(calificacion_id,cantidad_estrellas,autor_id,descripcion,fecha)
	SELECT m.Calificacion_Codigo,m.Calificacion_Cant_Estrellas/2,u.usuario_id,'Sin descripción',Compra_Fecha
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

	--DECLARE cursor_para_ofertas CURSOR FOR
	INSERT INTO DBME.oferta (monto,fecha,autor_id,publicacion_id)
	SELECT Oferta_Monto,Oferta_Fecha,u.usuario_id,Publicacion_Cod
	FROM gd_esquema.Maestra m JOIN DBME.usuario u ON (m.Cli_Mail = u.mail)
	WHERE Oferta_Fecha IS NOT NULL 
	
	/*
	order by Publicacion_Cod
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
	DEALLOCATE cursor_para_ofertas*/
END;
GO



CREATE PROCEDURE DBME.migrarPublicaciones
AS
BEGIN

	SET IDENTITY_INSERT DBME.publicacion ON;

	--DECLARE cursor_para_publicaciones CURSOR FOR
	INSERT INTO DBME.publicacion(publicacion_id,descripcion,cantidad,stock,fecha_creacion,fecha_vencimiento,precio,estado,publicacion_tipo,rubro_id,visibilidad_id,autor_id,permite_preguntas,realiza_envio)
	SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,0,Publicacion_Fecha,Publicacion_Fecha_Venc,Publicacion_Precio,'FINALIZADA',Publicacion_Tipo,r.rubro_id,v.visibilidad_id,u.usuario_id,0,0  
	FROM gd_esquema.Maestra m JOIN DBME.visibilidad v ON (m.Publicacion_Visibilidad_Desc = v.visibilidad_descripcion) JOIN DBME.rubro r ON (m.Publicacion_Rubro_Descripcion = r.descripcion_corta) JOIN DBME.usuario u ON (u.mail = m.Publ_Cli_Mail)
	WHERE Publicacion_Tipo = 'Compra Inmediata' AND Publ_Cli_Mail IS NOT NULL
	UNION
	SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,0,Publicacion_Fecha,Publicacion_Fecha_Venc,Publicacion_Precio,'FINALIZADA',Publicacion_Tipo,r.rubro_id,v.visibilidad_id,u.usuario_id,0,0  
	FROM gd_esquema.Maestra m JOIN DBME.visibilidad v ON (m.Publicacion_Visibilidad_Desc = v.visibilidad_descripcion) JOIN DBME.rubro r ON (m.Publicacion_Rubro_Descripcion = r.descripcion_corta) JOIN DBME.usuario u ON (u.mail = m.Publ_Empresa_Mail)
	WHERE Publicacion_Tipo = 'Compra Inmediata' AND Publ_Empresa_Mail IS NOT NULL

	INSERT INTO DBME.publicacion(publicacion_id,descripcion,cantidad,stock,fecha_creacion,fecha_vencimiento,precio,estado,publicacion_tipo,rubro_id,visibilidad_id,autor_id,permite_preguntas,realiza_envio,valor_inicial,valor_actual)
	SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,0,Publicacion_Fecha,Publicacion_Fecha_Venc,Publicacion_Precio,'FINALIZADA',Publicacion_Tipo,r.rubro_id,v.visibilidad_id,u.usuario_id,0,0,MIN(Oferta_Monto),MAX(Oferta_Monto)  
	FROM gd_esquema.Maestra m JOIN DBME.visibilidad v ON (m.Publicacion_Visibilidad_Desc = v.visibilidad_descripcion) JOIN DBME.rubro r ON (m.Publicacion_Rubro_Descripcion = r.descripcion_corta) JOIN DBME.usuario u ON (u.mail = m.Publ_Cli_Mail)
	WHERE Publicacion_Tipo = 'Subasta' AND Publ_Cli_Mail IS NOT NULL
	GROUP BY Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha,Publicacion_Fecha_Venc,Publicacion_Precio,Publicacion_Estado,Publicacion_Tipo,r.rubro_id,v.visibilidad_id,u.usuario_id
	UNION
	SELECT DISTINCT Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,0,Publicacion_Fecha,Publicacion_Fecha_Venc,Publicacion_Precio,'FINALIZADA',Publicacion_Tipo,r.rubro_id,v.visibilidad_id,u.usuario_id,0,0,MIN(Oferta_Monto),MAX(Oferta_Monto)  
	FROM gd_esquema.Maestra m JOIN DBME.visibilidad v ON (m.Publicacion_Visibilidad_Desc = v.visibilidad_descripcion) JOIN DBME.rubro r ON (m.Publicacion_Rubro_Descripcion = r.descripcion_corta) JOIN DBME.usuario u ON (u.mail = m.Publ_Empresa_Mail)
	WHERE Publicacion_Tipo = 'Subasta' AND Publ_Empresa_Mail IS NOT NULL
	GROUP BY Publicacion_Cod,Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha,Publicacion_Fecha_Venc,Publicacion_Precio,Publicacion_Estado,Publicacion_Tipo,r.rubro_id,v.visibilidad_id,u.usuario_id
	
	UPDATE DBME.publicacion 
	SET fecha_finalizacion_subasta = g.Compra_Fecha
	FROM gd_esquema.Maestra g 
	WHERE g.Publicacion_Cod = publicacion_id AND g.publicacion_tipo = 'Subasta'
		
	/*
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
	DECLARE @Publicacion_Visibilidad_Cod AS INT
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
	DEALLOCATE cursor_para_publicaciones*/
END;
GO

CREATE PROCEDURE DBME.migrarCompras
AS
BEGIN

	INSERT INTO DBME.compra (cantidad,fecha,autor_id,publicacion_id,esta_calificada)
	SELECT Compra_Cantidad,Compra_Fecha,u.usuario_id,Publicacion_Cod,1
	FROM gd_esquema.Maestra m JOIN DBME.usuario u ON (m.Cli_Mail=u.mail)
	WHERE Compra_Fecha IS NOT NULL AND Calificacion_Codigo IS NOT NULL

	UPDATE DBME.calificacion SET compra_id = com.compra_id
	FROM gd_esquema.Maestra m JOIN DBME.calificacion ca ON (m.Calificacion_Codigo = ca.calificacion_id)
							  JOIN DBME.compra com ON (m.Publicacion_Cod = com.publicacion_id)

END;
GO

/* END BASES DE MIGRACION */ 

/* START MIGRACION*/ --      EJECUTAR LOS PROCEDURES !!!!

	EXECUTE DBME.crearFuncionalidades
	EXECUTE DBME.crearRoles
	EXECUTE DBME.enlazarRol_X_Funcionalidad
	EXECUTE DBME.migrarDomicilio2
	EXECUTE DBME.migrarRubro
	EXECUTE DBME.migrarClientes
	EXECUTE DBME.migrarEmpresas
	EXECUTE DBME.enlazarRol_X_Usuario
	EXECUTE DBME.migrarVisibilidad
	EXECUTE DBME.migrarPublicaciones
	EXECUTE DBME.migrarFacturas
	EXECUTE DBME.migrarCalificaciones
	EXECUTE DBME.migrarCompras
	EXECUTE DBME.migrarOfertas
GO   


/* END MIGRACION */


/* START TRIGGERS */
/*
CREATE TRIGGER InsertarEnFuncionalidadXRolLuegoDeRol
ON DBME.rol
AFTER INSERT
AS 
BEGIN
	INSERT INTO DBME.rol_x_funcionalidad (rol_id,funcionalidad_id)
	SELECT rol_id,funcionalidad_id FROM inserted
	


GO
*/

/* END TRIGGERS */


/* START FUNCTIONS */

CREATE PROCEDURE DBME.setHoraDelSistema (@nueva_hora DATETIME)
AS
BEGIN
	
	BEGIN TRY
		DELETE FROM DBME.reloj
	
		INSERT INTO DBME.reloj (hora_actual)
		VALUES (@nueva_hora)
	END TRY
	BEGIN CATCH
		RAISERROR('Error actualizando la fecha del sistema', 12, 1)
	END CATCH

END;
GO

CREATE FUNCTION DBME.getHoraDelSistema()
RETURNS DATETIME
AS
BEGIN

	DECLARE @hora_actual AS DATETIME
	SELECT @hora_actual = hora_actual FROM DBME.reloj
	
	RETURN @hora_actual
END;
GO

/*
CREATE FUNCTION DBME.topVendedoresConMayorCantidadDeProductosNoVendidos(@trimestre TINYINT,@anio INTEGER,@visibilidad VARCHAR(255))
RETURNS @TABLA_RESULTADO TABLE ( id_vendedor INT, mail_vendedor NVARCHAR(255), cantidad_productos_sin_vender BIGINT)
AS 
BEGIN 
	INSERT INTO @TABLA_RESULTADO(id_vendedor,mail_vendedor ,cantidad_productos_sin_vender)
	
	SELECT u.usuario_id, u.mail, SUM(p.stock) as Cantidad_Productos_No_Vendidos 
	FROM DBME.usuario u JOIN DBME.publicacion p ON(u.usuario_id = p.autor_id)
	GROUP BY u.usuario_id, u.mail
	ORDER BY Cantidad_Productos_No_Vendidos DESC

	RETURN
END;
GO
*/
CREATE FUNCTION DBME.topClientesConMayorCantidadDeProductosComprados(@trimestre TINYINT,@anio INTEGER,@rubro INT)
RETURNS @TABLA_RESULTADO TABLE ( id_cliente INT, nombre_cliente NVARCHAR(255), apellido_cliente NVARCHAR(255), cantidad_productos_comprados BIGINT)
AS 
BEGIN
	--Falta Filtrado por Rubro, Fecha y Visibilidad
	If (@trimestre = 1)
	BEGIN
		INSERT INTO @TABLA_RESULTADO(id_cliente,nombre_cliente,apellido_cliente,cantidad_productos_comprados)
		SELECT TOP 5 c.cliente_id, c.nombre,c.apellido,  SUM(c2.cantidad) as compras_Realizadas 
		FROM DBME.cliente c JOIN DBME.compra c2 ON (c.usuario_id = c2.autor_id) JOIN DBME.publicacion p ON(c2.publicacion_id = p.publicacion_id)
			WHERE YEAR(c2.fecha) = @anio AND MONTH(c2.fecha) Between 1 AND 3 AND p.rubro_id = @rubro
			Group By c.cliente_id, c.nombre, c.apellido
			Order By compras_Realizadas DESC	
	END;
	If (@trimestre = 2)
	BEGIN
		INSERT INTO @TABLA_RESULTADO(id_cliente,nombre_cliente,apellido_cliente,cantidad_productos_comprados)
		SELECT TOP 5 c.cliente_id, c.nombre,c.apellido,  SUM(c2.cantidad) as compras_Realizadas 
		FROM DBME.cliente c JOIN DBME.compra c2 ON (c.usuario_id = c2.autor_id) JOIN DBME.publicacion p ON(c2.publicacion_id = p.publicacion_id)
			WHERE YEAR(c2.fecha) = @anio AND MONTH(c2.fecha) Between 4 AND 6 AND p.rubro_id = @rubro
			Group By c.cliente_id, c.nombre, c.apellido
			Order By compras_Realizadas DESC	
	END;
	If (@trimestre = 3)
	BEGIN
		INSERT INTO @TABLA_RESULTADO(id_cliente,nombre_cliente,apellido_cliente,cantidad_productos_comprados)
		SELECT TOP 5 c.cliente_id, c.nombre,c.apellido,  SUM(c2.cantidad) as compras_Realizadas 
		FROM DBME.cliente c JOIN DBME.compra c2 ON (c.usuario_id = c2.autor_id) JOIN DBME.publicacion p ON(c2.publicacion_id = p.publicacion_id)
			WHERE YEAR(c2.fecha) = @anio AND MONTH(c2.fecha) Between 7 AND 9 AND p.rubro_id = @rubro
			Group By c.cliente_id, c.nombre, c.apellido
			Order By compras_Realizadas DESC	
	END
	ELSE 
		INSERT INTO @TABLA_RESULTADO(id_cliente,nombre_cliente,apellido_cliente,cantidad_productos_comprados)
		SELECT TOP 5 c.cliente_id, c.nombre,c.apellido,  SUM(c2.cantidad) as compras_Realizadas 
		FROM DBME.cliente c JOIN DBME.compra c2 ON (c.usuario_id = c2.autor_id) JOIN DBME.publicacion p ON(c2.publicacion_id = p.publicacion_id)
			WHERE YEAR(c2.fecha) = @anio AND MONTH(c2.fecha) Between 10 AND 12 AND p.rubro_id = @rubro
			Group By c.cliente_id, c.nombre, c.apellido
			Order By compras_Realizadas DESC	
	RETURN
END;
GO


/*
CREATE FUNCTION DBME.topVendedoresConMayorCantidadDeFacturas(@trimestre TINYINT,@anio INTEGER)-- dentro de un mes y año particular
RETURNS @TABLA_RESULTADO TABLE ( id_vendedor INT, nombre_vendedor NVARCHAR(255), apellido_vendedor NVARCHAR(255), cantidad_facturas BIGINT)
AS 
BEGIN 
	INSERT INTO @TABLA_RESULTADO(id_vendedor,nombre_vendedor,apellido_vendedor,cantidad_facturas)
	
	--podemos obtener las mejores 5 empresas y dsp las mejores 5 clientes y dsp agarrar top 5 de esos 10
	-pero por que compra id es null? Yo le pregunte a SAPo y me dijo que no pudo migrar bien eso

	-- TOP 5 EMPRESAS
	SELECT TOP 5 e.empresa_id, e.razon_social, e.nombre_contacto, COUNT(f.factura_id) as facturas_Realizadas FROM DBME.empresa e JOIN DBME.publicacion p ON (e.empresa_id = p.autor_id) JOIN DBME.compra c ON(p.publicacion_id = c.publicacion_id) JOIN DBME.factura f ON(f.compra_id = c.compra_id)
	GROUP BY e.empresa_id, e.razon_social, e.nombre_contacto
	ORDER BY facturas_Realizadas DESC

	-- TOP 5 CLIENTES
	
	SELECT c1.cliente_id, c1.nombre, c1.apellido, COUNT(f.factura_id) as facturas_Realizadas FROM DBME.cliente c1 JOIN DBME.publicacion p ON (c1.usuario_id = p.autor_id) JOIN DBME.compra c ON(p.publicacion_id = c.publicacion_id) JOIN DBME.factura f ON(f.compra_id = c.compra_id)
	GROUP BY c1.cliente_id, c1.nombre, c1.apellido
	ORDER BY facturas_Realizadas 
	

	
	RETURN
END;
GO

CREATE FUNCTION DBME.topVendedoresConMayorMontoFacturado(@trimestre,@anio INTEGER)-- dentro de un mes y año particular
RETURNS @TABLA_RESULTADO TABLE ( id_vendedor INT, nombre_vendedor NVARCHAR(255), apellido_vendedor NVARCHAR(255), monto_facturado BIGINT)
AS 
BEGIN 
	INSERT INTO @TABLA_RESULTADO(id_vendedor,nombre_vendedor,apellido_vendedor,monto_facturado)
	
	
	-- TOP 5 EMPRESAS
	SELECT TOP 5 e.empresa_id, e.razon_social, f.factura_id, SUM(f.monto_total) as facturas_Realizadas FROM DBME.empresa e JOIN DBME.publicacion p ON (e.empresa_id = p.autor_id) JOIN DBME.compra c ON(p.publicacion_id = c.publicacion_id) JOIN DBME.factura f ON(f.compra_id = c.compra_id)
	GROUP BY e.empresa_id, e.razon_social, f.factura_id

	-- TOP 5 CLIENTES
	SELECT TOP 5 c1.cliente_id, c1.nombre, c1.apellido, SUM(f.monto_total) as facturas_Realizadas FROM DBME.cliente c JOIN DBME.publicacion p ON (c1.cliente_id = p.autor_id) JOIN DBME.compra c ON(p.publicacion_id = c.publicacion_id) JOIN DBME.factura f ON(f.compra_id = c.compra_id)
	GROUP BY e.empresa_id, e.razon_social, f.factura_id
	
	RETURN
END;
GO
*/
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
	VALUES (@username,HASHBYTES('SHA2_256',@password),1,0,@mail,@domicilio_id,GETDATE(),@telefono,1)

	SET @usuario_id = SCOPE_IDENTITY()
END;
GO
 
CREATE PROCEDURE DBME.crearCliente(
	@apellido NVARCHAR(255),
	@nombre NVARCHAR(255),
	@numero_documento NUMERIC(18,0),
	@tipo_documento NVARCHAR(3),
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
	
	INSERT INTO DBME.cliente(apellido,nombre,numero_documento,tipo_documento,fecha_nacimiento,usuario_id,habilitado)
	VALUES (@apellido,@nombre,@numero_documento,@tipo_documento,@fecha_nacimiento,@usuario_id,1)

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
	
	INSERT INTO DBME.empresa(razon_social,cuit,fecha_creacion,nombre_contacto,rubro_id,usuario_id,habilitado)
	VALUES (@razon_social,@cuit,@fecha_creacion,@nombre_contacto,@rubro_id,@usuario_id,1)

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
	EXECUTE DBME.crearUsuario 'admin','w23e',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL, @usuario_id OUT
	INSERT INTO DBME.administrador(nombre,apellido,usuario_id)
	VALUES ('Administrador','General',@usuario_id)
	INSERT INTO DBME.rol_x_usuario (usuario_id,rol_id)
	VALUES (@usuario_id,1)
END;
GO

EXECUTE DBME.crearAdministradores
GO


CREATE PROCEDURE DBME.nuevoCliente (@username NVARCHAR(255), @password NVARCHAR(255), @mail NVARCHAR(255), @nombre NVARCHAR(255), @apellido NVARCHAR(255),@fechaNacimiento DATETIME, @tipoDocumento NVARCHAR(3),@numero_documento NUMERIC(18,0),@ciudad NVARCHAR(255),@localidad NVARCHAR(255),@codigo_postal NVARCHAR(50), @domicilio_calle NVARCHAR(255),@altura_calle NUMERIC (18,0),@numero_piso NUMERIC(18,0), @departamento NVARCHAR(50), @numero_telefono BIGINT)
AS
BEGIN

	DECLARE @mensaje_error varchar(100)
	DECLARE @cliente_id INT

	BEGIN TRY
		BEGIN TRANSACTION	
		EXECUTE DBME.crearCliente @apellido,@nombre,@numero_documento,@tipoDocumento,@fechaNacimiento,@username,@password,@mail,@numero_telefono,@ciudad,@localidad,@codigo_postal,@numero_piso,@departamento,@domicilio_calle,@altura_calle ,@cliente_id OUT
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @mensaje_error = 'Error en insertar nuevos datos. Se deshace la operacion entera. Lo sentimos.'
		RAISERROR(@mensaje_error, 12, 1)
		ROLLBACK TRANSACTION 
	END CATCH

	
END;
GO


CREATE PROCEDURE DBME.updateCliente (@cliente_id INT, @nombre NVARCHAR(255), @apellido NVARCHAR(255),@fechaNacimiento DATETIME, @tipoDocumento NVARCHAR(3),@numero_documento NUMERIC(18,0),@ciudad NVARCHAR(255),@localidad NVARCHAR(255),@codigo_postal NVARCHAR(50), @domicilio_calle NVARCHAR(255),@altura_calle NUMERIC (18,0),@numero_piso NUMERIC(18,0), @departamento NVARCHAR(50), @numero_telefono BIGINT)
AS
BEGIN

	DECLARE @mensaje_error varchar(100)
	DECLARE @usuario_id INT

	SET @usuario_id = (SELECT usuario_id FROM DBME.cliente WHERE cliente_id = @cliente_id)
	
	BEGIN TRY
		BEGIN TRANSACTION	
		
		UPDATE DBME.domicilio 
		SET ciudad = @ciudad, localidad = @localidad, codigo_postal = @codigo_postal, piso = @numero_piso, departamento = @departamento,domicilio_calle = @domicilio_calle, numero_calle = @altura_calle 
		WHERE domicilio_id = @usuario_id
		
		UPDATE DBME.cliente 
		SET apellido = @apellido, nombre = @nombre, numero_documento = @numero_documento, tipo_documento = @tipoDocumento, fecha_nacimiento = @fechaNacimiento 
		WHERE usuario_id = @usuario_id
		
		UPDATE DBME.usuario 
		SET telefono = @numero_telefono 
		WHERE usuario_id = @usuario_id
		
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @mensaje_error = 'Error en actualizar los datos. Se deshace la operacion entera. Lo sentimos.'
		RAISERROR(@mensaje_error, 12, 1)
		ROLLBACK TRANSACTION 
	END CATCH

END;
GO

CREATE PROCEDURE DBME.nuevaEmpresa (@username NVARCHAR(255), @password NVARCHAR(255), @mail NVARCHAR(255), @nombre NVARCHAR(255),@razon_social NVARCHAR(255), @cuit NVARCHAR(50), @rubro_id INT, @ciudad NVARCHAR(255), @localidad NVARCHAR(255),@codigo_postal NVARCHAR(50), @domicilio_calle NVARCHAR(255),@numero_calle NUMERIC(18,0),@piso NUMERIC(18,0),@departamento NVARCHAR(50), @telefono BIGINT)
AS
BEGIN

	DECLARE @mensaje_error varchar(100)
	DECLARE @empresa_id INT
	DECLARE @date DATETIME

	SET @date = GETDATE()

	BEGIN TRY
		BEGIN TRANSACTION			
		EXECUTE DBME.crearEmpresa @razon_social,@cuit,@date,@nombre,@rubro_id,@username,@password,@mail, @telefono, @ciudad, @localidad, @codigo_postal, @piso, @departamento,@domicilio_calle,@numero_calle, @empresa_id OUT
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @mensaje_error = 'Error en insertar nuevos datos. Se deshace la operacion entera. Lo sentimos.'
		RAISERROR(@mensaje_error, 12, 1)
		ROLLBACK TRANSACTION 
	END CATCH

	
END;
GO


CREATE PROCEDURE DBME.updateEmpresa (@empresa_id INT, @nombre NVARCHAR(255), @razon_social NVARCHAR(255),@cuit NVARCHAR(50),@rubro_id INT ,@ciudad NVARCHAR(255),@localidad NVARCHAR(255),@codigo_postal NVARCHAR(50), @domicilio_calle NVARCHAR(255),@altura_calle NUMERIC (18,0),@numero_piso NUMERIC(18,0), @departamento NVARCHAR(50), @numero_telefono BIGINT)
AS
BEGIN

	DECLARE @mensaje_error varchar(100)
	DECLARE @usuario_id INT

	SET @usuario_id = (SELECT usuario_id FROM DBME.empresa WHERE empresa_id = @empresa_id)
	BEGIN TRY
		BEGIN TRANSACTION	
		
		UPDATE DBME.domicilio 
		SET ciudad = @ciudad, localidad = @localidad, codigo_postal = @codigo_postal, piso = @numero_piso, departamento = @departamento,domicilio_calle = @domicilio_calle, numero_calle = @altura_calle 
		WHERE domicilio_id = @usuario_id
		
		UPDATE DBME.empresa 
		SET razon_social = @razon_social, cuit = @cuit, nombre_contacto = @nombre, rubro_id = @rubro_id
		WHERE empresa_id = @empresa_id
		
		UPDATE DBME.usuario 
		SET telefono = @numero_telefono 
		WHERE usuario_id = @usuario_id
		
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @mensaje_error = 'Error en actualizar los datos. Se deshace la operacion entera. Lo sentimos.'
		RAISERROR(@mensaje_error, 12, 1)
		ROLLBACK TRANSACTION 
	END CATCH

END;
GO

CREATE PROCEDURE DBME.crearCompraInmediata (@descripcion NVARCHAR(255),@stock NUMERIC(18,0),@fecha_creacion DATETIME,@fecha_vencimiento DATETIME,@precio NUMERIC(18,2), @rubro_id INT, @visibilidad_id NUMERIC(18,0), @autor_id INT, @estado NVARCHAR(255),@permite_preguntas bit,@realiza_envio bit, @costo NUMERIC(18,2))
AS
BEGIN

	DECLARE @mensaje_error AS NVARCHAR(99)
	DECLARE @publicacion_id AS NUMERIC(18,0)
	
	DECLARE @visibilidad_descripcion AS NVARCHAR(255) 
	SET @visibilidad_descripcion = (SELECT visibilidad_descripcion FROM dbme.visibilidad WHERE visibilidad_id = @visibilidad_id)
	
	DECLARE @factura_id AS INT

	BEGIN TRY
		BEGIN TRANSACTION	

		IF ((SELECT es_nuevo FROM DBME.usuario WHERE usuario_id = @autor_id) = 1 )
		BEGIN
			SET @costo = 0
			UPDATE DBME.usuario SET es_nuevo = 0 WHERE usuario_id = @autor_id
		END

		INSERT INTO DBME.publicacion (publicacion_tipo,descripcion,stock,fecha_creacion,fecha_vencimiento,precio,costo,rubro_id,visibilidad_id,autor_id,estado,permite_preguntas,realiza_envio,cantidad)
		VALUES ('Compra Inmediata',@descripcion,@stock,@fecha_creacion,@fecha_vencimiento,@precio,@costo,@rubro_id,@visibilidad_id,@autor_id,@estado,@permite_preguntas,@realiza_envio,@stock)

		SET @publicacion_id = SCOPE_IDENTITY()
		DECLARE @descripcion_facha AS VARCHAR(64)
		SET @descripcion_facha =  'Costo visibilidad ' + CONVERT(VARCHAR(64),@visibilidad_descripcion) 

		EXECUTE DBME.crearFactura @publicacion_id, @autor_id,@costo,@factura_id OUT
		EXECUTE DBME.crearDetalleFactura 1,@descripcion_facha, @factura_id,@costo

		select @factura_id
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @mensaje_error = 'Error en crear la nueva publicacion. Se deshace la operacion entera. Lo sentimos.'
		RAISERROR(@mensaje_error, 12, 1)
		ROLLBACK TRANSACTION 
	END CATCH
END;
GO

CREATE PROCEDURE DBME.crearSubasta (@descripcion NVARCHAR(255),@stock NUMERIC(18,0),@fecha_creacion DATETIME,@fecha_vencimiento DATETIME, @costo NUMERIC(18,2), @rubro_id INT, @visibilidad_id NUMERIC(18,0), @autor_id INT, @estado NVARCHAR(255),@permite_preguntas bit,@realiza_envio bit, @valor_inicial DECIMAL(10,2))
AS
BEGIN

	DECLARE @mensaje_error AS NVARCHAR(99)
	DECLARE @publicacion_id AS NUMERIC(18,0)
	
	DECLARE @visibilidad_descripcion AS NVARCHAR(255) 
	SET @visibilidad_descripcion = (SELECT visibilidad_descripcion FROM dbme.visibilidad WHERE visibilidad_id = @visibilidad_id)
	
	DECLARE @factura_id AS INT

	BEGIN TRY
		BEGIN TRANSACTION	

		IF ((SELECT es_nuevo FROM DBME.usuario WHERE usuario_id = @autor_id) = 1 )
		BEGIN
			SET @costo = 0
			UPDATE DBME.usuario SET es_nuevo = 0 WHERE usuario_id = @autor_id
		END

		INSERT INTO DBME.publicacion (publicacion_tipo, descripcion, stock, fecha_creacion, fecha_vencimiento, costo, rubro_id, visibilidad_id, autor_id, estado ,permite_preguntas, realiza_envio, valor_inicial)
		VALUES ('Subasta', @descripcion, @stock, @fecha_creacion,@fecha_vencimiento, @costo, @rubro_id, @visibilidad_id , @autor_id, @estado ,@permite_preguntas, @realiza_envio , @valor_inicial)

		SET @publicacion_id = SCOPE_IDENTITY()
		DECLARE @descripcion_facha AS VARCHAR(64)
		SET @descripcion_facha = CONVERT(VARCHAR(64),@visibilidad_descripcion) + 'Costo visibilidad'

		EXECUTE DBME.crearFactura @publicacion_id, @autor_id,@costo,@factura_id OUT
		EXECUTE DBME.crearDetalleFactura 1,@descripcion_facha, @factura_id,@costo
		
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SET @mensaje_error = 'Error en crear la nueva publicacion. Se deshace la operacion entera. Lo sentimos.'
		RAISERROR(@mensaje_error, 12, 1)
		ROLLBACK TRANSACTION 
	END CATCH
END;
GO



/* END PROCEDURES CREACIONALES */

/* START PROCEDURES COMUNICACION */


CREATE PROCEDURE DBME.loginUsuario (@username nvarchar(255),@contrasenia nvarchar(255))
AS
BEGIN
	DECLARE @u_id INT
	DECLARE @u_password NVARCHAR(255)
	DECLARE @u_habilitado bit
	DECLARE @cantidad_intentos_fallidos tinyint
	DECLARE @mensaje_error varchar(300)

	SET @contrasenia = HASHBYTES('SHA2_256',@contrasenia)

	
	SELECT @u_id = usuario_id, @u_password = password, @u_habilitado = habilitado, @cantidad_intentos_fallidos = cantidad_intentos_fallidos
	FROM DBME.usuario
	WHERE DBME.usuario.username = @username 
	
	/*
	SELECT @u_id = DBME.usuario.usuario_id, @u_password = usuario.password, @u_habilitado = habilitado, @cantidad_intentos_fallidos = DBME.usuario.cantidad_intentos_fallidos
	FROM DBME.usuario
	WHERE DBME.usuario.username = @username
	*/


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

CREATE PROCEDURE DBME.calificarAlVendedor (@compra_id INT,@cliente_id INT, @comentario NVARCHAR(255), @calificacion numeric(18,0))
AS
BEGIN

		INSERT INTO DBME.calificacion(cantidad_estrellas,descripcion,fecha,autor_id,compra_id) VALUES(@calificacion,@comentario, GETDATE(),@cliente_id,@compra_id)
		UPDATE DBME.compra
		SET esta_calificada = 1
		WHERE compra_id = @compra_id	
 
END;
GO


CREATE PROCEDURE DBME.chequearVencimientoPublicaciones (@hora_actual DATETIME)
AS
BEGIN

	--BEGIN TRY

		-- verificar las publicaciones activas
		-- marcarlas como finalizadas
		-- ver si alguien gano las subastas 
		-- generar las facturas correspondientes
		
		DECLARE @publicacion_id NUMERIC(18,0)
		DECLARE @publicacion_tipo NVARCHAR(255)
		DECLARE @oferta_id_ganador INT

		DECLARE publicaciones_activas2 CURSOR FOR
		SELECT p.publicacion_id,p.publicacion_tipo
		FROM DBME.publicacion p
		WHERE fecha_vencimiento<@hora_actual AND p.estado = 'ACTIVA'
		
		
		OPEN publicaciones_activas2 

		FETCH NEXT FROM publicaciones_activas2 INTO
		@publicacion_id, @publicacion_tipo
		
		WHILE(@@FETCH_STATUS = 0)
		BEGIN
			
			IF (@publicacion_tipo = 'Compra Inmediata')
			BEGIN
				UPDATE DBME.publicacion SET estado = 'FINALIZADA' 
				WHERE publicacion_id = @publicacion_id
			END
			
			IF (@publicacion_tipo = 'Subasta')
			BEGIN
				
				SET @oferta_id_ganador = (SELECT TOP 1 oferta_id 
				FROM dbme.oferta
				WHERE publicacion_id = @publicacion_id
				ORDER BY monto)
				
				/*
				IF (@oferta_id_ganador IS NOT NULL)
				BEGIN
					select * from dbme.visibilidad -- estos es chamuyo
					--generar factura al ganador
				END
				*/
				UPDATE DBME.publicacion SET estado = 'FINALIZADA' 
				WHERE publicacion_id = @publicacion_id
				
			END
			
			FETCH NEXT FROM publicaciones_activas2
		END
		
		CLOSE publicaciones_activas2
		DEALLOCATE publicaciones_activas2
		
	--END TRY
	--BEGIN CATCH
		--RAISERROR('Error chequeando el vencimiento de Publicaciones', 12, 1)
	--END CATCH
		
END; 
GO

/*
create procedure DBME.sida
AS
BEGIN
	
	DECLARE @mensaje_error varchar(100)
	DECLAre @sida VARCHAR (5)
	SET @sida = 'ho'
	BEGIN TRY
		INSERT INTO DBME.domicilio (numero_calle) VALUES (@sida)
	END TRY
	BEGIN CATCH
		SET @mensaje_error = 'El usuario ingresado no existe'
		RAISERROR(@mensaje_error, 12, 1)
	END CATCH 
END;
GO*/



CREATE PROCEDURE DBME.crearFactura (@publicacion_id NUMERIC(18,2) , @usuario_id INT, @precio NUMERIC(18,2),@factura_id INT OUT)
AS
BEGIN
	DECLARE @mensaje_error AS NVARCHAR(99)
		
	BEGIN TRY
		BEGIN TRANSACTION

		INSERT INTO DBME.factura(publicacion_id,usuario_id,monto_total,fecha,forma_pago_desc)
		VALUES (@publicacion_id,@usuario_id,@precio,dbme.getHoraDelSistema(),'Efectivo')

		COMMIT TRANSACTION 
		SET @factura_id = SCOPE_IDENTITY()
	END TRY

	BEGIN CATCH
		SET @mensaje_error = 'Error en crear la nueva factura. Se deshace la operacion entera. Lo sentimos.'
		RAISERROR(@mensaje_error, 12, 1)
		ROLLBACK TRANSACTION 
	END CATCH

END;
GO

CREATE PROCEDURE DBME.crearDetalleFactura (@cantidad NUMERIC(18,0), @tipo_de_item VARCHAR(64), @factura_id INT,@monto_parcial NUMERIC(18,2))
AS
BEGIN
	DECLARE @mensaje_error AS NVARCHAR(99)
		
	BEGIN TRY
		BEGIN TRANSACTION

		INSERT INTO DBME.factura_detalle(factura_cantidad,tipo_de_item,factura_id,monto_parcial)
		VALUES (@cantidad,@tipo_de_item,@factura_id,@monto_parcial)

		COMMIT TRANSACTION 
	END TRY

	BEGIN CATCH
		SET @mensaje_error = 'Error en crear el detalle de factura. Se deshace la operacion entera. Lo sentimos.'
		RAISERROR(@mensaje_error, 12, 1)
		ROLLBACK TRANSACTION 
	END CATCH

END;
GO


/* END PROCEDURES COMUNICACION */

/* START PROCEDURES DOMINIO */

CREATE PROCEDURE DBME.cantidadDeCalificacionesDelUsuario (@usuario_id INT)
AS
BEGIN
	SELECT cantidad_estrellas as 'Numero de estrellas', COUNT(cantidad_estrellas) as 'Cantidad de calificaciones'
	FROM DBME.calificacion
	WHERE autor_id = @usuario_id
	Group By cantidad_estrellas
	Order By cantidad_estrellas DESC
END;
GO 

CREATE PROCEDURE DBME.historialComprasYSubastas (@usuario_id INT)
AS
BEGIN

	SELECT oferta_id,monto,fecha,publicacion_id
	FROM DBME.oferta o 
	WHERE o.autor_id = @usuario_id
	UNION
	SELECT compra_id,cantidad,fecha,publicacion_id
	FROM DBME.compra c
	WHERE c.autor_id = @usuario_id

END;
GO

CREATE PROCEDURE DBME.devolverInformacionFactura (@usuario_id INT)
AS
BEGIN
	IF (EXISTS(SELECT usuario_id FROM DBME.empresa WHERE usuario_id = @usuario_id))
	BEGIN
		SELECT 'empresa'
	END
	ELSE
	BEGIN
		SELECT 'cliente'
	END

END;

/* END PROCEDURES DOMINIO*/

-- COMO EJECUTAR FUNCIONES select * from DBME.topClientesConMayorCantidadDeProductosComprados (1,2015,'1')

