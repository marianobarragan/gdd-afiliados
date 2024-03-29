/*
El script est� dividido en diferentes secciones:
	-Creaci�n de tablas
	-Migraci�n de la tabla maestra
	-Funciones (tops del listado estad�stico y funciones del reloj)
	-Procedures creacionales
	-Triggers
	-Indice
	-Procedures de comunicaci�n
	-Procedures de dominio
*/

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
	es_nuevo BIT,
	posee_baja_logica BIT
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
);
GO

CREATE TABLE DBME.visibilidad( --INT IDENTITY(1,1) PRIMARY KEY
	visibilidad_id NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,
	visibilidad_descripcion NVARCHAR(255) UNIQUE,
	visibilidad_precio NUMERIC(18,2), 
	visibilidad_porcentaje NUMERIC(18,2) CHECK(visibilidad_porcentaje BETWEEN '0' AND '1'),
	visibilidad_costo_envio NUMERIC(10,2),
	posee_baja_logica BIT
);
GO

CREATE TABLE DBME.estado ( 
	estado_id NVARCHAR(255) PRIMARY KEY,
	estado_descripcion NVARCHAR(255) UNIQUE,
	CONSTRAINT estado_id CHECK (estado_id IN ('BORRADOR','ACTIVA','PAUSADA','FINALIZADA')) 
);
GO

CREATE TABLE DBME.tipo(
	tipo_id NVARCHAR(255) PRIMARY KEY
	CONSTRAINT tipo_id CHECK (tipo_id IN ('Compra Inmediata','Subasta'))
);
GO

CREATE TABLE DBME.publicacion(
	publicacion_id NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,
	publicacion_tipo NVARCHAR(255) FOREIGN KEY REFERENCES DBME.tipo(tipo_id),
	descripcion NVARCHAR(255), 
	stock NUMERIC(18,0),
	fecha_creacion DATETIME,
	fecha_vencimiento DATETIME, 
	precio NUMERIC(18,2),
	costo DECIMAL(10,2),
	rubro_id INT FOREIGN KEY REFERENCES DBME.rubro(rubro_id),
	visibilidad_id NUMERIC(18,0) FOREIGN KEY REFERENCES DBME.visibilidad(visibilidad_id),
	autor_id INT FOREIGN KEY REFERENCES DBME.usuario(usuario_id),
	estado NVARCHAR(255)  FOREIGN KEY REFERENCES DBME.estado(estado_id),
	permite_preguntas bit,
	realiza_envio bit,
	cantidad INT,
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
	descripcion NVARCHAR(255),
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
	tipo_de_item VARCHAR(64) CHECK (tipo_de_item IN ('Comisi�n por publicaci�n','Costo envio','Comision por producto','INDEFINIDO')),
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
	--Se realizan querys para obtener los datos correspondientes al domicilio de cada empresa y cliente por separado
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
	--Se seleccionan los datos de cada cliente de la tabla maestra.
	--Para los atributos mail, username y password (encriptado) se utiliza el mail del cliente.
	--Todos los clientes migrados se encuentran habilitados.

	INSERT INTO DBME.usuario(mail,username,password,habilitado,cantidad_intentos_fallidos,domicilio_id,fecha_creacion,telefono,es_nuevo,posee_baja_logica)
	SELECT DISTINCT Publ_Cli_Mail,Publ_Cli_Mail,HASHBYTES('SHA2_256',Publ_Cli_Mail),1,0, d.domicilio_id ,NULL,NULL,0,0
	FROM gd_esquema.Maestra m JOIN DBME.domicilio d ON (m.Publ_Cli_Cod_Postal = d.codigo_postal)
	WHERE Publ_Cli_Mail IS NOT NULL
	
	INSERT INTO DBME.cliente(usuario_id,apellido,nombre,numero_documento,tipo_documento,fecha_nacimiento)
	SELECT DISTINCT u.usuario_id, m.Publ_Cli_Apeliido, m.Publ_Cli_Nombre,m.Publ_Cli_Dni,'DNI',m.Publ_Cli_Fecha_Nac
	FROM gd_esquema.Maestra m JOIN DBME.usuario u ON (m.Publ_Cli_Mail = u.mail)
	
END;
GO

CREATE PROCEDURE DBME.migrarEmpresas
AS
BEGIN
	--Se seleccionan los datos de cada empresa de la tabla maestra.
	--Para los atributos mail, username y password se utiliza el mail de la empresa.
	--Todos los empresa migrados se encuentran habilitados.
	--El nombre de contacto para todas las empresas ser� la raz�n social
	INSERT INTO DBME.usuario(mail,username,password,habilitado,cantidad_intentos_fallidos,domicilio_id ,fecha_creacion,telefono,es_nuevo,posee_baja_logica)
	SELECT DISTINCT Publ_Empresa_Mail, Publ_Empresa_Mail,HASHBYTES('SHA2_256',Publ_Empresa_Mail),1,0, d.domicilio_id ,NULL,NULL,0,0
	FROM gd_esquema.Maestra m JOIN DBME.domicilio d ON (m.Publ_Empresa_Cod_Postal = d.codigo_postal)
	WHERE Publ_Empresa_Mail IS NOT NULL
	
	INSERT INTO DBME.empresa(usuario_id,razon_social,cuit,fecha_creacion,nombre_contacto)
	SELECT DISTINCT u.usuario_id,Publ_Empresa_Razon_Social,Publ_Empresa_Cuit,Publ_Empresa_Fecha_Creacion,Publ_Empresa_Razon_Social
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
	--El nombre lo dice todo :)
	INSERT INTO DBME.rubro(descripcion_larga,descripcion_corta)
	SELECT DISTINCT NULL,Publicacion_Rubro_Descripcion
	FROM gd_esquema.Maestra

END;
GO

CREATE PROCEDURE DBME.migrarVisibilidad
AS
BEGIN

	--Se migran los tipos de visibilidad de la tabla Maestra
	INSERT INTO DBME.visibilidad( visibilidad_descripcion, visibilidad_porcentaje, visibilidad_precio, visibilidad_costo_envio,posee_baja_logica)
	SELECT DISTINCT Publicacion_Visibilidad_Desc, Publicacion_Visibilidad_Porcentaje, Publicacion_Visibilidad_Precio, 50, 0
	FROM gd_esquema.Maestra
	--El costo de envio de los tipos de visibilidad migrados tiene un valor fijo de 50 pesos.
	UPDATE DBME.visibilidad
	SET visibilidad_costo_envio = 50
	
	UPDATE DBME.visibilidad
	SET visibilidad_costo_envio = 0
	WHERE visibilidad_descripcion = 'Gratis'

END;
GO

CREATE PROCEDURE DBME.migrarFacturas
AS
BEGIN
	--En este procedure se migran las facturas y los detalle-factura.
	--Para el atributo ID de cada factura se utiliza Factura_Nro de la tabla maestra
	SET IDENTITY_INSERT DBME.factura ON;--Permite insertar en el atributo ID de la tabla DBME.factura
	SET IDENTITY_INSERT DBME.factura_detalle OFF;
	
	INSERT INTO DBME.factura(factura_id,fecha,monto_total,forma_pago_desc,usuario_id,publicacion_id)
	(SELECT DISTINCT Factura_Nro,Factura_Fecha,Factura_Total,Forma_Pago_Desc,u.usuario_id,Publicacion_Cod
	FROM gd_esquema.Maestra m LEFT JOIN DBME.usuario u ON (m.Publ_Cli_Mail = u.mail)
	WHERE Factura_Nro IS NOT NULL AND Publ_Cli_Mail IS NOT NULL
	UNION
	SELECT DISTINCT Factura_Nro,Factura_Fecha,Factura_Total,Forma_Pago_Desc,u.usuario_id,Publicacion_Cod
	FROM gd_esquema.Maestra m LEFT JOIN DBME.usuario u ON (m.Publ_Empresa_Mail= u.mail)
	WHERE Factura_Nro IS NOT NULL AND Publ_Empresa_Mail IS NOT NULL)
	--Para todas las descripciones de los detalles de factura migrados se utiliza "INDEFINIDO"
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
	--Se migran calificaciones
	--Se utliza el ID de la tabla maestra
	INSERT INTO DBME.calificacion(calificacion_id,cantidad_estrellas,autor_id,descripcion,fecha)
	SELECT m.Calificacion_Codigo,m.Calificacion_Cant_Estrellas/2,u.usuario_id,'Sin descripci�n',Compra_Fecha
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
	
	INSERT INTO DBME.oferta (monto,fecha,autor_id,publicacion_id)
	SELECT Oferta_Monto,Oferta_Fecha,u.usuario_id,Publicacion_Cod
	FROM gd_esquema.Maestra m JOIN DBME.usuario u ON (m.Cli_Mail = u.mail)
	WHERE Oferta_Fecha IS NOT NULL 
	
END;
GO

CREATE PROCEDURE DBME.migrarEstados
AS
BEGIN
	--Se migran los estados de publicaci�n a una nueva tabla seg�n lo indicado por la correci�n
	INSERT INTO DBME.estado (estado_id,estado_descripcion)
	VALUES('BORRADOR','Publicaci�n Borrador, visible solo para el autor')
	INSERT INTO DBME.estado (estado_id,estado_descripcion)
	VALUES ('ACTIVA','Publicaci�n Activa, visible para los usuarios')
	INSERT INTO DBME.estado (estado_id,estado_descripcion)
	VALUES ('PAUSADA','Publicaci�n Pausada, no genera compras')
	INSERT INTO DBME.estado (estado_id,estado_descripcion)
	VALUES ('FINALIZADA','Publicaci�n Finalizada')
	
END;
GO

CREATE PROCEDURE DBME.migrarTipos
AS
BEGIN
	--Se migran los tipos de publicaci�n a una nueva tabla seg�n lo indicado por la correci�n
	INSERT INTO DBME.tipo(tipo_id)
	VALUES('Subasta')
	INSERT INTO DBME.tipo (tipo_id)
	VALUES ('Compra Inmediata')
	
END;
GO

CREATE PROCEDURE DBME.migrarPublicaciones
AS
BEGIN
	--Se migran las publicaciones
	--Se seleccionan las publicaciones por compra inmediata y por subasta, los cuales se dividen entre las hechas por clientes y por empresas.
	--Luego se insertan en la tabla DBME.publicacion con diferentes criterios dependiendo su tipo seg�n corresponda
	SET IDENTITY_INSERT DBME.publicacion ON;

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
	
END;
GO

CREATE PROCEDURE DBME.migrarCompras
AS
BEGIN
	--Se migran las compras, y sus respectivas referencias a calificacion y publicacion.
	--Se actualiza la referencia compra_id en la tabla calificacion
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
	EXECUTE DBME.migrarEstados
	EXECUTE DBME.migrarTipos
	EXECUTE DBME.migrarPublicaciones
	EXECUTE DBME.migrarFacturas
	EXECUTE DBME.migrarCalificaciones
	EXECUTE DBME.migrarCompras
	EXECUTE DBME.migrarOfertas
GO   


/* END MIGRACION */




/* START FUNCTIONS */

CREATE PROCEDURE DBME.setHoraDelSistema (@nueva_hora DATETIME)
AS
BEGIN
	--Se setea el reloj seg�n lo indicado en el archivo de configuraci�n
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
	--Funcion para obtener la hora del sistema, para su uso dentro de la base de datos.
	DECLARE @hora_actual AS DATETIME
	SELECT @hora_actual = hora_actual FROM DBME.reloj
	
	RETURN @hora_actual
END;
GO


--TOP PROD NO VENDIDOS--

CREATE FUNCTION DBME.topVendedoresConMayorCantidadDeProductosNoVendidos(@trimestre TINYINT,@anio INTEGER, @visibilidad NVARCHAR(255))
RETURNS @TABLA_RESULTADO TABLE ( Nombre_Usuario NVARCHAR(255), mail_vendedor NVARCHAR(255), cantidad_productos_sin_vender BIGINT)
AS 
BEGIN 
	DECLARE @inicio AS INT
	DECLARE @fin AS INT

	SET @inicio =
			 CASE @trimestre
			 WHEN 1 THEN 1
			 WHEN 2 THEN 4   
			 WHEN 3 THEN 7   
			 ELSE 10  
	END
	SET @fin = @inicio + 2

	
		INSERT INTO @TABLA_RESULTADO(Nombre_Usuario,mail_vendedor ,cantidad_productos_sin_vender)
		SELECT TOP 5 u.username, u.mail, SUM(p.stock) as Cantidad_Productos_No_Vendidos 
		FROM DBME.usuario u JOIN DBME.publicacion p ON(u.usuario_id = p.autor_id) 
							JOIN dbme.visibilidad v ON(p.visibilidad_id = v.visibilidad_id)
		WHERE YEAR(p.fecha_creacion) = @anio AND 
			MONTH(p.fecha_creacion) Between @inicio AND @fin AND
			v.visibilidad_descripcion = @visibilidad 
		GROUP BY u.username, u.mail
		ORDER BY Cantidad_Productos_No_Vendidos DESC
		RETURN
	
END;
GO

--TOP PROD COMPRADOS--


CREATE FUNCTION DBME.topClientesConMayorCantidadDeProductosComprados(@trimestre TINYINT,@anio INTEGER,@rubro INT)
RETURNS @TABLA_RESULTADO TABLE ( cliente_id INT, nombre_cliente NVARCHAR(255), apellido_cliente NVARCHAR(255), cantidad_productos_comprados BIGINT)
AS 
BEGIN
	DECLARE @inicio AS INT
	DECLARE @fin AS INT

	SET @inicio =
			 CASE @trimestre
			 WHEN 1 THEN 1
			 WHEN 2 THEN 4   
			 WHEN 3 THEN 7   
			 ELSE 10  
	END
	SET @fin = @inicio + 2

	INSERT INTO @TABLA_RESULTADO(cliente_id,nombre_cliente,apellido_cliente,cantidad_productos_comprados)
		SELECT TOP 5 c.cliente_id, c.nombre,c.apellido,  SUM(c2.cantidad) as Cantidad_Productos_Comprados 
		FROM DBME.cliente c JOIN DBME.compra c2 ON (c.usuario_id = c2.autor_id) 
							JOIN DBME.publicacion p ON(c2.publicacion_id = p.publicacion_id) 
		WHERE YEAR(c2.fecha) = @anio AND 
			  MONTH(c2.fecha) Between @inicio AND @fin
			  AND p.rubro_id = @rubro
		Group By c.cliente_id, c.nombre, c.apellido
		Order By Cantidad_Productos_Comprados DESC
		RETURN

END;
GO

--TOP MAX FACT--

CREATE FUNCTION DBME.topVendedoresConMayorCantidadDeFacturas(@trimestre TINYINT,@anio INTEGER)-- dentro de un mes y a�o particular
RETURNS @TABLA_RESULTADO TABLE ( id_vendedor INT, nombre_vendedor NVARCHAR(255), cantidad_facturas BIGINT)
AS 
BEGIN 
DECLARE @inicio AS INT
DECLARE @fin AS INT

SET @inicio =
		 CASE @trimestre
	     WHEN 1 THEN 1
         WHEN 2 THEN 4   
         WHEN 3 THEN 7   
         ELSE 10  
END
SET @fin = @inicio + 2

	INSERT INTO @TABLA_RESULTADO(id_vendedor,nombre_vendedor,cantidad_facturas)
		
	SELECT TOP 5 u.usuario_id, u.username, COUNT(f.usuario_id) as facturas_realizadas 
	FROM DBME.usuario u JOIN DBME.factura f ON (u.usuario_id = f.usuario_id)
	WHERE YEAR(f.fecha) = @anio AND 
		  MONTH(f.fecha) Between @inicio AND @fin
	GROUP BY u.usuario_id, u.username
	ORDER BY facturas_realizadas DESC
	
	RETURN
END;
GO

--TOP MAX MONTO--

CREATE FUNCTION DBME.topVendedoresConMayorMontoFacturado(@trimestre INT,@anio INTEGER)
RETURNS @TABLA_RESULTADO TABLE (id_vendedor INT, nombre_vendedor NVARCHAR(255), monto_facturado BIGINT)
AS 
BEGIN 
DECLARE @inicio AS INT
DECLARE @fin AS INT

SET @inicio =
		 CASE @trimestre
	     WHEN 1 THEN 1
         WHEN 2 THEN 4   
         WHEN 3 THEN 7   
         ELSE 10  
END
SET @fin = @inicio + 2

	
	INSERT INTO @TABLA_RESULTADO(id_vendedor,nombre_vendedor,monto_facturado)
	SELECT TOP 5 u.usuario_id, u.username, SUM(f.monto_total) as monto_facturado 
	FROM DBME.usuario u JOIN DBME.factura f ON (u.usuario_id = f.usuario_id)
	WHERE YEAR(f.fecha) = @anio AND 
		  MONTH(f.fecha) Between @inicio AND @fin
	GROUP BY u.usuario_id, u.username
	ORDER BY monto_facturado DESC
	RETURN
	/*
	INSERT INTO @TABLA_RESULTADO(id_vendedor,nombre_vendedor,monto_facturado)
	SELECT TOP 5 u.usuario_id, u.username, SUM(fd.monto_parcial) as monto_facturado
	FROM DBME.usuario u JOIN DBME.factura f ON (u.usuario_id = f.usuario_id)
						JOIN DBME.factura_detalle fd ON (f.factura_id = fd.factura_id) 
	WHERE YEAR(f.fecha) = @anio AND 
		  MONTH(f.fecha) Between @inicio AND @fin
	GROUP BY u.usuario_id, u.username
	ORDER BY monto_facturado DESC
	RETURN
	*/
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
		--Procedure que genera un nuevo domicilio, y devuelve su id para su posterior uso
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
	--Procedure que genera un nueva entrada en la tabla usuario, guarda la contrase�a con la encriptaci�n SHA2_256 y devuelve su id para su posterior uso
	--Recibe tambi�n todos los datos necesarios para crear el domicilio
	DECLARE @domicilio_id AS INT 
	EXECUTE DBME.crearDomicilio @ciudad,@localidad,@codigo_postal,@piso,@departamento,@domicilio_calle,@numero_calle,@domicilio_id OUT

	INSERT INTO DBME.usuario(username,password,habilitado,cantidad_intentos_fallidos,mail,domicilio_id,fecha_creacion,telefono,es_nuevo,posee_baja_logica)
	VALUES (@username,HASHBYTES('SHA2_256',@password),1,0,@mail,@domicilio_id,dbme.getHoraDelSistema(),@telefono,1,0)

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
	--Genera un nuevo cliente, recibiendo todos los datos para crear un nuevo usuario y domicilio.
	--Devuelve el id del cliente creado.
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
	--Genera un nueva empresa, recibiendo todos los datos para crear un nuevo usuario y domicilio.
	--Devuelve el id de la empresa creado.
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
	--Crea al administrador
	DECLARE @usuario_id AS INT
										--w23e encriptado
	EXECUTE DBME.crearUsuario 'admin','w23e','mail@admin.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL, @usuario_id OUT

	INSERT INTO DBME.rol_x_usuario (usuario_id,rol_id)
	VALUES (@usuario_id,1)

END;
GO

EXECUTE DBME.crearAdministradores
GO


CREATE PROCEDURE DBME.nuevoCliente (@username NVARCHAR(255), @password NVARCHAR(255), @mail NVARCHAR(255), @nombre NVARCHAR(255), @apellido NVARCHAR(255),@fechaNacimiento DATETIME, @tipoDocumento NVARCHAR(3),@numero_documento NUMERIC(18,0),@ciudad NVARCHAR(255),@localidad NVARCHAR(255),@codigo_postal NVARCHAR(50), @domicilio_calle NVARCHAR(255),@altura_calle NUMERIC (18,0),@numero_piso NUMERIC(18,0), @departamento NVARCHAR(50), @numero_telefono BIGINT)
AS
BEGIN
	--Crea un nuevo cliente de manera at�mica y con el respectivo manejo de errores
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


CREATE PROCEDURE DBME.updateCliente (@cliente_id INT, @nombre NVARCHAR(255), @apellido NVARCHAR(255),@fechaNacimiento DATETIME, @tipoDocumento NVARCHAR(3),@numero_documento NUMERIC(18,0),@ciudad NVARCHAR(255),@localidad NVARCHAR(255),@codigo_postal NVARCHAR(50), @domicilio_calle NVARCHAR(255),@altura_calle NUMERIC (18,0),@numero_piso NUMERIC(18,0), @departamento NVARCHAR(50), @numero_telefono BIGINT, @habilitado BIT)
AS
BEGIN
	--Procedure que est� para mantener la consistencia con el TP, refleja cambios en tablas domicilio, cliente y usuario
	--Tiene manejo de errores
	--Se realiza de manera at�mica
	DECLARE @mensaje_error varchar(100)
	DECLARE @usuario_id INT
	DECLARE @domicilio_id INT
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
		SET telefono = @numero_telefono,habilitado = @habilitado
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
	--Crea una nueva empresa de manera at�mica y con el respectivo manejo de errores
	DECLARE @mensaje_error varchar(100)
	DECLARE @empresa_id INT
	DECLARE @date DATETIME

	SET @date = DBME.getHoraDelSistema()

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


CREATE PROCEDURE DBME.updateEmpresa (@empresa_id INT, @nombre NVARCHAR(255), @razon_social NVARCHAR(255),@cuit NVARCHAR(50),@rubro_id INT ,@ciudad NVARCHAR(255),@localidad NVARCHAR(255),@codigo_postal NVARCHAR(50), @domicilio_calle NVARCHAR(255),@altura_calle NUMERIC (18,0),@numero_piso NUMERIC(18,0), @departamento NVARCHAR(50), @numero_telefono BIGINT, @habilitado BIT)
AS
BEGIN
	--Procedure que est� para mantener la consistencia con el TP, refleja cambios en tablas domicilio, empresa y usuario
	--Tiene manejo de errores
	--Se realiza de manera at�mica
	DECLARE @mensaje_error varchar(100)
	DECLARE @usuario_id INT
	DECLARE @domicilio_id INT

	SET @usuario_id = (SELECT usuario_id FROM DBME.empresa WHERE empresa_id = @empresa_id)
	SET @domicilio_id = (SELECT domicilio_id FROM DBME.usuario WHERE usuario_id = @usuario_id)

	BEGIN TRY
		BEGIN TRANSACTION	
		
		UPDATE DBME.domicilio 
		SET ciudad = @ciudad, localidad = @localidad, codigo_postal = @codigo_postal, piso = @numero_piso, departamento = @departamento,domicilio_calle = @domicilio_calle, numero_calle = @altura_calle 
		WHERE domicilio_id = @domicilio_id
		
		UPDATE DBME.empresa 
		SET razon_social = @razon_social, cuit = @cuit, nombre_contacto = @nombre, rubro_id = @rubro_id
		WHERE empresa_id = @empresa_id
		
		UPDATE DBME.usuario 
		SET telefono = @numero_telefono,habilitado = @habilitado 
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


CREATE PROCEDURE DBME.crearFactura (@publicacion_id NUMERIC(18,2) , @usuario_id INT, @precio NUMERIC(18,2),@factura_id INT OUT)
AS
BEGIN
	--Crea una factura de manera at�mica
	--Tiene manejo de errores
	--Devuelve el id de la factura creada
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
	--Crea el detalle factura de manera at�mica
	--Tiene manejo de errores
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



CREATE PROCEDURE DBME.crearCompraInmediata (@descripcion NVARCHAR(255),@stock NUMERIC(18,0),@fecha_creacion DATETIME,@fecha_vencimiento DATETIME,@precio NUMERIC(18,2), @rubro_id INT, @visibilidad_id NUMERIC(18,0), @autor_id INT, @estado NVARCHAR(255),@permite_preguntas bit,@realiza_envio bit, @costo NUMERIC(18,2))
AS
BEGIN
	--Crea una nueva compra inmediata de manera at�mica, y con manejo de errores.
	DECLARE @mensaje_error AS NVARCHAR(99)
	DECLARE @publicacion_id AS NUMERIC(18,0)
	
	DECLARE @visibilidad_descripcion AS NVARCHAR(255) 
	SET @visibilidad_descripcion = (SELECT visibilidad_descripcion FROM dbme.visibilidad WHERE visibilidad_id = @visibilidad_id)
	
	DECLARE @factura_id AS INT

	BEGIN TRY
		BEGIN TRANSACTION	
		--Si es la primera publicaci�n del usuario
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
		
		--Se genera la factura correspondiente si tiene el estado "ACTIVA"
		IF (@estado = 'ACTIVA')
		BEGIN
			EXECUTE DBME.crearFactura @publicacion_id, @autor_id,@costo,@factura_id OUT
			EXECUTE DBME.crearDetalleFactura 1,'Comisi�n por publicaci�n', @factura_id,@costo
			select @factura_id
		END


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
	--Crea una nueva subasta de manera at�mica, y con manejo de errores.
	DECLARE @mensaje_error AS NVARCHAR(99)
	DECLARE @publicacion_id AS NUMERIC(18,0)
	
	DECLARE @visibilidad_descripcion AS NVARCHAR(255) 
	SET @visibilidad_descripcion = (SELECT visibilidad_descripcion FROM dbme.visibilidad WHERE visibilidad_id = @visibilidad_id)
	
	DECLARE @factura_id AS INT

	BEGIN TRY
		BEGIN TRANSACTION
			
				--Si es la primera publicaci�n del usuario
		IF ((SELECT es_nuevo FROM DBME.usuario WHERE usuario_id = @autor_id) = 1 )
		BEGIN
			SET @costo = 0
			UPDATE DBME.usuario SET es_nuevo = 0 WHERE usuario_id = @autor_id
		END

		INSERT INTO DBME.publicacion (publicacion_tipo, descripcion, stock, fecha_creacion, fecha_vencimiento, costo, rubro_id, visibilidad_id, autor_id, estado ,permite_preguntas, realiza_envio, valor_inicial,valor_actual)
		VALUES ('Subasta', @descripcion, @stock, @fecha_creacion,@fecha_vencimiento, @costo, @rubro_id, @visibilidad_id , @autor_id, @estado ,@permite_preguntas, @realiza_envio , @valor_inicial,@valor_inicial)

		SET @publicacion_id = SCOPE_IDENTITY()
		DECLARE @descripcion_facha AS VARCHAR(64)
		SET @descripcion_facha = 'Costo visibilidad: ' + CONVERT(VARCHAR(64),@visibilidad_descripcion) 
				
				--Se genera la factura correspondiente si tiene el estado "ACTIVA"')
		IF (@estado = 'ACTIVA')
		BEGIN
			EXECUTE DBME.crearFactura @publicacion_id, @autor_id,@costo,@factura_id OUT
			EXECUTE DBME.crearDetalleFactura 1,'Comisi�n por publicaci�n', @factura_id,@costo
			select @factura_id
		END
		
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

/* START TRIGGERS */

CREATE TRIGGER DBME.triggerCrearFacturaLuegoDeCompra
ON DBME.compra
FOR INSERT
AS
BEGIN
--Este trigger se ejecuta cuando se realiza una compra con �xito
	--Crea una nueva factura cuando hay una compra inmediata en cualquier momento y el sistema "barre" las subastas finalizadas
	DECLARE @hora DATETIME
	DECLARE @autor_id INT
	DECLARE @factura_id INT
			
	DECLARE @visibilidad NVARCHAR(255)
	DECLARE @costo_envio NUMERIC(10,2)
	DECLARE @comision NUMERIC(10,2) 
	DECLARE @publicacion_id AS NUMERIC(18,0) = (SELECT publicacion_id FROM inserted)
	DECLARE @costo NUMERIC(18,2) = (SELECT costo FROM DBME.publicacion WHERE publicacion_id = @publicacion_id)
	DECLARE @cantidad NUMERIC(18,0) = (SELECT cantidad FROM inserted)
		--Si la compra corresponde a una compra inmediata
	IF ((SELECT publicacion_tipo FROM DBME.publicacion WHERE publicacion_id = @publicacion_id) = 'Subasta')
	BEGIN 

		DECLARE @oferta_id_ganador AS INT
		SET @oferta_id_ganador = (SELECT TOP 1 o.oferta_id 
		FROM dbme.oferta o
		WHERE o.publicacion_id = @publicacion_id
		ORDER BY o.monto DESC)
				--Agarro los datos necesarios para la factura
		SELECT @cantidad = cantidad,@hora = DBME.getHoraDelSistema(),@autor_id = p.autor_id,@visibilidad = v.visibilidad_descripcion,@costo_envio = v.visibilidad_costo_envio,@comision = visibilidad_porcentaje * o.monto
		FROM DBME.publicacion p JOIN DBME.oferta o ON (p.publicacion_id = o.publicacion_id) JOIN DBME.visibilidad v ON (v.visibilidad_id = p.visibilidad_id)
		WHERE o.oferta_id=@oferta_id_ganador

		IF ((SELECT realiza_envio FROM DBME.publicacion WHERE publicacion_id = @publicacion_id) = 0)
		BEGIN	
			SET @costo_envio = 0
		END

		DECLARE @CostoTotal AS NUMERIC(18,2) = @costo_envio + @comision

		EXECUTE DBME.crearFactura @publicacion_id, @autor_id,@CostoTotal,@factura_id OUT
		EXECUTE DBME.crearDetalleFactura 1,'Costo envio',@factura_id,@costo_envio
		EXECUTE DBME.crearDetalleFactura @cantidad,'Comision por producto',@factura_id,@comision
	END;
	--Si la compra corresponde a una subasta								
	IF ((SELECT publicacion_tipo FROM DBME.publicacion WHERE publicacion_id = @publicacion_id AND estado = 'ACTIVA') = 'Compra Inmediata')
	BEGIN 
				--Agarro los datos necesarios para la factura
		SELECT @costo_envio = v.visibilidad_costo_envio,@comision = p.precio*i.cantidad*v.visibilidad_porcentaje
		FROM DBME.visibilidad v JOIN DBME.publicacion p ON (v.visibilidad_id = p.visibilidad_id) JOIN inserted i ON (p.publicacion_id = i.publicacion_id) 
		WHERE p.publicacion_id = @publicacion_id
		
		IF ((SELECT realiza_envio FROM DBME.publicacion WHERE publicacion_id = @publicacion_id) = 0)
		BEGIN	
			SET @costo_envio = 0
		END

		SET @autor_id = (SELECT autor_id FROM dbme.publicacion WHERE publicacion_id = @publicacion_id)
		SET @CostoTotal = @costo_envio + @comision

		UPDATE DBME.publicacion
		SET stock = stock - @cantidad
		WHERE publicacion_id = @publicacion_id
				--Si la compra inmediata se queda sin stock le actualizo el estado a finalizada
		IF((SELECT stock FROM DBME.publicacion WHERE publicacion_id = @publicacion_id) = 0)
		BEGIN
			UPDATE DBME.publicacion
			SET estado = 'FINALIZADA'
			WHERE publicacion_id = @publicacion_id
		END

		EXECUTE DBME.crearFactura @publicacion_id, @autor_id,@CostoTotal,@factura_id OUT
		EXECUTE DBME.crearDetalleFactura 1,'Costo envio',@factura_id,@costo_envio
		EXECUTE DBME.crearDetalleFactura @cantidad,'Comision por producto',@factura_id,@comision

	END

END;
GO

CREATE TRIGGER DBME.triggerActualizarEstadoPublicaciones
ON DBME.publicacion
AFTER UPDATE
AS
BEGIN
	UPDATE DBME.publicacion
	SET estado = 'FINALIZADA'
	WHERE stock = 0 AND estado = 'ACTIVA'

END;
GO


/* END TRIGGERS */

/* START INDICES */

CREATE INDEX INDICE_FACTURA_FECHA
ON DBME.factura (fecha)

CREATE INDEX INDICE_FACTURA_USUARIO_ID
ON DBME.factura (usuario_id)

CREATE INDEX INDICE_FACTURA_DETALLE_TIPO_DE_ITEM
ON DBME.factura_detalle (tipo_de_item)

GO
/* END INDICES */

/* START PROCEDURES COMUNICACION */


CREATE PROCEDURE DBME.loginUsuario (@username nvarchar(255),@contrasenia nvarchar(255))
AS
BEGIN

	--Procedure que maneja el login del usuario al sistema
	DECLARE @u_id INT
	DECLARE @u_password NVARCHAR(255)
	DECLARE @u_habilitado bit
	DECLARE @cantidad_intentos_fallidos tinyint
	DECLARE @mensaje_error varchar(300)
	DECLARE @u_baja bit

	SET @contrasenia = HASHBYTES('SHA2_256',@contrasenia)

	
	SELECT @u_id = usuario_id, @u_password = password, @u_habilitado = habilitado, @cantidad_intentos_fallidos = cantidad_intentos_fallidos,@u_baja = posee_baja_logica
	FROM DBME.usuario
	WHERE DBME.usuario.username = @username 


	IF (@U_id IS NULL)
	BEGIN
		-- no se encontro usuario
		SET @mensaje_error = 'El usuario ingresado no existe'
		RAISERROR(@mensaje_error, 12, 1)
		
	END
	
	IF (@u_baja = 1)
	BEGIN
		-- no se encontro usuario
		SET @mensaje_error = 'El usuario ya no forma parte del sistema'
		RAISERROR(@mensaje_error, 12, 1)
		
	END

	IF (@u_habilitado = 0)
	BEGIN
		-- el usuario esta deshabilitado
		SET @mensaje_error = 'El usuario se encuentra deshabilitado, contacte al administrador'
		RAISERROR(@mensaje_error, 12, 1)
		
	END
	
	IF (@contrasenia != @u_password)
	BEGIN
		SET @cantidad_intentos_fallidos = @cantidad_intentos_fallidos + 1
		UPDATE DBME.usuario SET cantidad_intentos_fallidos = @cantidad_intentos_fallidos WHERE usuario_id = @u_id
				--Si el usuario supera la cantidad de intentos permitidos
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
		--login correcto
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
		--Crea una nueva calificacion y actualiza el campo en la tabla compra
		INSERT INTO DBME.calificacion(cantidad_estrellas,descripcion,fecha,autor_id,compra_id) VALUES(@calificacion,@comentario, DBME.getHoraDelSistema(),@cliente_id,@compra_id)
		UPDATE DBME.compra
		SET esta_calificada = 1
		WHERE compra_id = @compra_id	
 
END;
GO

CREATE PROCEDURE DBME.chequearVencimientoPublicaciones 
AS
BEGIN

	DECLARE @hora_actual DATETIME
	SELECT @hora_actual = DBME.getHoraDelSistema()

			-- Procedure que se ejecuta cuando un usuario se loguea en el sistema
		
		--Se encarga de lo siguiente:
		-- verificar las publicaciones activas
		-- marcarlas como finalizadas
		-- ver si alguien gano las subastas 
		--Generar la compra para la subasta con ganador	
		DECLARE @publicacion_id NUMERIC(18,0)
		DECLARE @publicacion_tipo NVARCHAR(255)
		DECLARE @oferta_id_ganador INT

		DECLARE publicaciones_activas2 CURSOR FOR
		SELECT p.publicacion_id,p.publicacion_tipo
		FROM DBME.publicacion p
		WHERE fecha_vencimiento<=@hora_actual AND (p.estado = 'ACTIVA' OR p.estado = 'PAUSADA')
		
		
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

				DECLARE @cantidad NUMERIC(18,0)
				DECLARE @hora DATETIME
				DECLARE @autor_id INT

				SET @oferta_id_ganador = (SELECT TOP 1 o.oferta_id 
				FROM dbme.oferta o
				WHERE o.publicacion_id = @publicacion_id
				ORDER BY o.monto DESC)

				IF (@oferta_id_ganador IS NOT NULL)
				BEGIN
					SELECT @cantidad = stock,@hora = DBME.getHoraDelSistema(),@autor_id = o.autor_id--,@visibilidad = v.visibilidad_descripcion,@costo_envio = v.visibilidad_costo_envio,@comision = visibilidad_porcentaje * o.monto
					FROM DBME.publicacion p JOIN DBME.oferta o ON (p.publicacion_id = o.publicacion_id) JOIN DBME.visibilidad v ON (v.visibilidad_id = p.visibilidad_id)
					WHERE o.oferta_id=@oferta_id_ganador
					
					INSERT INTO DBME.compra (cantidad,fecha,autor_id,publicacion_id,esta_calificada)
					VALUES (@cantidad,@hora,@autor_id,@publicacion_id,0)
				
				END

				UPDATE DBME.publicacion SET estado = 'FINALIZADA' 
				WHERE publicacion_id = @publicacion_id
			END
			
			FETCH NEXT FROM publicaciones_activas2 INTO @publicacion_id, @publicacion_tipo
		END
		
		CLOSE publicaciones_activas2
		DEALLOCATE publicaciones_activas2
		
	--END TRY
	--BEGIN CATCH
		--RAISERROR('Error chequeando el vencimiento de Publicaciones', 12, 1)
	--END CATCH
		
END; 
GO



/* END PROCEDURES COMUNICACION */

/* START PROCEDURES DOMINIO */


CREATE PROCEDURE DBME.validarUsuarioExistente (@username NVARCHAR(255),@mail NVARCHAR(255))
AS
BEGIN
		--Devuelve si existe un usuario con el mail o username
	IF (EXISTS(SELECT username,mail FROM DBME.usuario WHERE username = @username OR mail = @mail))
	BEGIN
		SELECT 'true'
	END
	ELSE
	BEGIN
		SELECT 'false'
	END
END;
GO 


CREATE PROCEDURE DBME.cantidadDeCalificacionesDelUsuario (@usuario_id INT)
AS
BEGIN
	--Procedure para el punto "calificaciones del usuario"
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
	--Procedure que devuelve el historia de compras y subastas del usuario
	(SELECT oferta_id as ofertas,monto,fecha,publicacion_id,'Oferta' as 'Tipo de publicaci�n'
	FROM DBME.oferta o 
	WHERE o.autor_id = @usuario_id
	UNION
	SELECT compra_id,cantidad,fecha,publicacion_id,'Compra' as 'Tipo de publicaci�n'
	FROM DBME.compra c
	WHERE c.autor_id = @usuario_id)
	ORDER BY fecha DESC

END;
GO

CREATE PROCEDURE DBME.devolverInformacionFactura (@usuario_id INT)
AS
BEGIN
	--Devuelve para qui�n est� dirigida la factura, ya que se genera de manera diferente dependiendo el tipo de usuario
	IF (EXISTS(SELECT usuario_id FROM DBME.empresa WHERE usuario_id = @usuario_id))
	BEGIN
		SELECT 'empresa'
	END
	IF (EXISTS(SELECT usuario_id FROM DBME.cliente WHERE usuario_id = @usuario_id))
	BEGIN
		SELECT 'cliente'
	END
	IF ((SELECT username FROM DBME.usuario WHERE usuario_id = @usuario_id) = 'admin')
	BEGIN
		SELECT 'admin'
	END

END;
GO

CREATE PROCEDURE DBME.crearFacturasDelBorrador (@publicacion_id NUMERIC(18,0)) 
AS
BEGIN
		--Crea la factura si el usuario guard� la publicaci�n correspondiente como borrador
	DECLARE @autor_id INT
	DECLARE @costo DECIMAL(10,2)
	DECLARE @factura_id NUMERIC (18,0)
	DECLARE @descripcion_facha VARCHAR(64)
	
	SELECT @autor_id = p.autor_id, @costo= p.costo
	FROM DBME.publicacion p
	WHERE p.publicacion_id = @publicacion_id

	EXECUTE DBME.crearFactura @publicacion_id, @autor_id,@costo,@factura_id OUT
	EXECUTE DBME.crearDetalleFactura 1,'Comisi�n por publicaci�n', @factura_id,@costo

	select @factura_id
END;
GO

CREATE PROCEDURE DBME.cambiarContrasenia (@usuario_id INT, @contrasenia NVARCHAR(255))
AS
BEGIN
	--Procedure para el cambio de contrase�a del usuario
	DECLARE @contraseniaCifrada AS NVARCHAR(255)
	SET @contraseniaCifrada = HASHBYTES('SHA2_256',@contrasenia)
	
	UPDATE DBME.usuario SET password = @contraseniaCifrada WHERE usuario_id = @usuario_id


END;
GO

/* END PROCEDURES DOMINIO*/

-- COMO EJECUTAR FUNCIONES select * from DBME.topClientesConMayorCantidadDeProductosComprados (1,2015,'1')

