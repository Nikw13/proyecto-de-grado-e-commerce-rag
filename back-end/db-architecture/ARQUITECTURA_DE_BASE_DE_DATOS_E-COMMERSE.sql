/* =========================================================
   BASE DE DATOS PARA EL E-COMMERSE (FUTURO RAG SYSTEM)
   ========================================================= */

-- Crear base de datos
CREATE DATABASE ECOMMERCE_DB_RAG_SYSTEM;

USE ECOMMERCE_DB_RAG_SYSTEM;

/* =========================================================
   CLIENTES
   ========================================================= */

-- Tabla CLIENTE
CREATE TABLE CLIENTE (
	id_cliente VARCHAR(28) PRIMARY KEY,
	nombres NVARCHAR(100) NOT NULL,
	apellidos NVARCHAR(100) NOT NULL, 
	email NVARCHAR(255) NOT NULL UNIQUE,
	telefono NVARCHAR(20) NULL,
	direccion NVARCHAR(255) NOT NULL,
	contrasena NVARCHAR(255) NOT NULL,
	creada_en DATETIME2 NOT NULL DEFAULT SYSDATETIME(), 
	estado NVARCHAR(20) NOT NULL DEFAULT 'Activo',
		CHECK (estado IN ('Activo','Inactivo','Suspendido','Baneado')) -- Es una mejor practica que: CHECK (estado = 'Activo' OR estado = 'Inactivo' OR estado = 'Suspendido' OR estado = 'Baneado')
);

/* =========================================================
   CATEGORIAS Y PRODUCTOS
   ========================================================= */

-- Tabla CATEGORIA
CREATE TABLE CATEGORIA (
	id_categoria INT IDENTITY(1,1) PRIMARY KEY,
	nombre_catg NVARCHAR(100) NOT NULL UNIQUE,
	descripcion NVARCHAR(500) NULL,
	estado_cat NVARCHAR(30) NOT NULL DEFAULT 'Activo',
		CHECK (estado_cat IN ('Activo','Inactivo'))
);

-- Tabla PRODUCTO
CREATE TABLE PRODUCTO (
	id_producto INT IDENTITY(1,1) PRIMARY KEY,
	nombre_prod NVARCHAR(150) NOT NULL,
	sku NVARCHAR(50) UNIQUE DEFAULT NULL,
	descripcion NVARCHAR(2000), -- Antes estaba usando en el numero de caracteres (MAX), pero puede llegar a causar una sobrecarga de la informaci�n realmente innecesaria, causando que baje la eficiencia del modelo.
	precio DECIMAL(10,2) NOT NULL,
	stock_qty INT NOT NULL DEFAULT 0,
	estado_prod NVARCHAR(20) NOT NULL DEFAULT 'Activo'
		CHECK (estado_prod in ('Activo','Inactivo')),
	id_categoria INT NOT NULL,
	FOREIGN KEY (id_categoria) REFERENCES CATEGORIA(id_categoria)
);

-- Tabla RESENA
CREATE TABLE RESENA (
	id_resena INT IDENTITY(1,1) PRIMARY KEY,
	rating INT NOT NULL CHECK (rating BETWEEN 1 AND 5),
	comentario NVARCHAR(1000), -- NVARCHAR no reserva 1000 caracteres si el usuario escribe menos
	fecha_resena DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	id_cliente VARCHAR(28) NOT NULL,
	id_producto INT NOT NULL,
	FOREIGN KEY (id_cliente) REFERENCES CLIENTE(id_cliente),
	FOREIGN KEY (id_producto) REFERENCES PRODUCTO(id_producto)
);

-- Tabla FACTURA
CREATE TABLE FACTURA (
	id_factura BIGINT IDENTITY(1,1) PRIMARY KEY,   
	nro_factura NVARCHAR(20) NOT NULL UNIQUE,                     
	fecha_fac DATETIME2 NOT NULL DEFAULT SYSDATETIME(),                        
	subtotal DECIMAL(10,2) NOT NULL, CHECK (subtotal >= 0),                     
	iva DECIMAL(10,2) NOT NULL,                          
	total DECIMAL(10,2) NOT NULL, CHECK (total = subtotal + iva),       
	id_cliente VARCHAR(28) NOT NULL,
	FOREIGN KEY (id_cliente) REFERENCES CLIENTE(id_cliente)
);

-- Tabla FACTURA_PRODUCTO (relacion muchos a muchos)
CREATE TABLE FACTURA_PRODUCTO (
    id_factura BIGINT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precio DECIMAL(10,2) NOT NULL CHECK (precio >= 0),
    valor_total AS (cantidad * precio), -- esto puede ser persistido, preguntar al profe

    PRIMARY KEY (id_factura, id_producto),

    FOREIGN KEY (id_factura) REFERENCES FACTURA(id_factura),
    FOREIGN KEY (id_producto) REFERENCES PRODUCTO(id_producto)
);

-- Tabla PAGO
CREATE TABLE PAGO (
	id_pago BIGINT IDENTITY(1,1) PRIMARY KEY,
	metodo_pago NVARCHAR(20) NOT NULL
		CHECK (metodo_pago in('Tarjeta','PayPal','Efectivo','Transferencia')),
	monto DECIMAL(10,2) NOT NULL,
	fecha_pago DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	estado NVARCHAR(20) NOT NULL DEFAULT 'Pendiente',
		CHECK (estado in ('Pendiente','Completado','Fallido','Reembolsado')),
	id_factura BIGINT NOT NULL, -- Debe coincidir con FACTURA.id_factura
	FOREIGN KEY (id_factura) REFERENCES FACTURA(id_factura)
);


/* =========================================================
   UBICACION GEOGROFICA
   ========================================================= */

-- Tabla DEPARTAMENTO

CREATE TABLE DEPARTAMENTO (
	id_departamento INT PRIMARY KEY, --preguntar al profesor si esta sentencia es valida porque según gemini cuando le pase este codigo para su corrección me dice que solo el valor lo acepta mysql
	nombre_dep VARCHAR(60) UNIQUE,
	codigo_dane_dep VARCHAR(10),
	estado_dep NVARCHAR(30) NOT NULL DEFAULT 'Activo'
		CHECK (estado_dep in ('Activo','Inactivo'))
);

-- Tabla CIUDAD

CREATE TABLE CIUDAD (
	id_ciudad INT PRIMARY KEY,
	nombre_ciu VARCHAR (60),
	codigo_dane_ciu VARCHAR(10),
	estado_ciu NVARCHAR(30) NOT NULL DEFAULT 'Activo'
		CHECK (estado_ciu in('Activo','Inactivo')),
	id_departamento INT,
	FOREIGN KEY (id_departamento) REFERENCES DEPARTAMENTO(id_departamento)
);

-- Tabla CODIGO POSTAL

CREATE TABLE CODIGO_POSTAL( 
	id_cp INT PRIMARY KEY, -- preguntar al profe si puede ser autoincrementable (me respondo) es mejor crear unos seeds para inyectarlos y ya, no suele variar esto. y se documenta cual fue el ultimo agregada
	cp VARCHAR(6),
	estado_cp NVARCHAR(30) NOT NULL DEFAULT 'Activo'
		CHECK (estado_cp in ('Activo','Inactivo')),
	id_ciudad INT,
	FOREIGN KEY (id_ciudad) REFERENCES CIUDAD(id_ciudad)
);

-- Tabla ENVIO
CREATE TABLE ENVIO (
    id_envio BIGINT IDENTITY(1,1) PRIMARY KEY,
    direc_envio NVARCHAR(255) NOT NULL,
    fecha_envio DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    fecha_entrega DATETIME2 NULL,
    estado_envio NVARCHAR(30) NOT NULL DEFAULT 'Pendiente'
        CHECK (estado_envio IN ('Pendiente','En proceso','En tránsito','Entregado','Cancelado')),
    costo_envio DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    metodo_envio NVARCHAR(30) NOT NULL
        CHECK (metodo_envio IN ('Estandar','Express','Recogida en tienda')),
    empresa_envio VARCHAR(50) NULL DEFAULT NULL,
    id_pago BIGINT NOT NULL,
    id_cp INT NOT NULL,
    FOREIGN KEY (id_pago) REFERENCES PAGO(id_pago),
    FOREIGN KEY (id_cp) REFERENCES CODIGO_POSTAL(id_cp)
);