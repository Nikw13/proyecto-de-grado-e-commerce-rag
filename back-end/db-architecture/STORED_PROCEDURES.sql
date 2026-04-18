/* ===========================================================
   PROCESOS ALMACENADOS PARA EL E-COMMERSE (FUTURO RAG SYSTEM)
   =========================================================== */

   /* =========================================================
   CLIENTES
   ========================================================= */

-- REGISTRAR:

CREATE PROCEDURE usp_registrar(

@id_cliente VARCHAR(28),
@nombres NVARCHAR(100),
@apellidos NVARCHAR(100),
@email NVARCHAR(255),
@telefono NVARCHAR(20),
@direccion NVARCHAR(255),
@contrasena NVARCHAR(255) -- Nunca poner coma aca, preguntar instructor porque.
)
as
begin
insert into CLIENTE (id_cliente, nombres, apellidos, email, telefono, direccion, contrasena)
values
(
@id_cliente,
@nombres,
@apellidos,
@email,
@telefono,
@direccion,
@contrasena -- Nunca poner coma aca, preguntar instructor porque.
)
end

-- --------------------------------------------------------------------------------------------

-- ACTUALIZAR:

CREATE PROCEDURE usp_actualizar(

@id_cliente VARCHAR(28),
@nombres NVARCHAR(100),
@apellidos NVARCHAR(100),
@email NVARCHAR(255),
@telefono NVARCHAR(20),
@direccion NVARCHAR(255),
@contrasena NVARCHAR(255) 
)
as
begin
update CLIENTE set
nombres = @nombres,
apellidos = @apellidos,
email = @email,
telefono = @telefono,
direccion = @direccion,
contrasena = @contrasena

where id_cliente = @id_cliente
end	

-- --------------------------------------------------------------------------------------------

-- ELIMINAR:

CREATE PROCEDURE usp_eliminar(
@id_cliente VARCHAR(28)
)
as
begin

delete from CLIENTE where id_cliente = @id_cliente

end

-- --------------------------------------------------------------------------------------------

-- CONSULTAR CLIENTE

CREATE PROCEDURE usp_consultar_clnt(
@id_cliente VARCHAR(28)
)
as begin

select * from CLIENTE where id_cliente = @id_cliente 

end

-- --------------------------------------------------------------------------------------------

-- LISTAR LA TABLA CLIENTE

CREATE PROCEDURE usp_listar_clientes
as
begin

select * from CLIENTE
end

-- --------------------------------------------------------------------------------------------

/* =========================================================
CATEGORIA
========================================================= */


-- REGISTRAR:

CREATE PROCEDURE usp_categoria_registrar
(
    @nombre_catg NVARCHAR(100)
)
AS
BEGIN
    INSERT INTO CATEGORIA (nombre_catg)
    VALUES (@nombre_catg);
END

-- --------------------------------------------------------------------------------------------

-- ACTUALIZAR CATEGORIA

CREATE PROCEDURE usp_actualizar_categoria
    @id_categoria INT,
    @nombre_catg NVARCHAR(100),
    @descripcion NVARCHAR(500),
    @estado_cat NVARCHAR(30)
AS
BEGIN
    UPDATE CATEGORIA
    SET nombre_catg = @nombre_catg,
        descripcion = @descripcion,
        estado_cat = @estado_cat
    WHERE id_categoria = @id_categoria
END

-- --------------------------------------------------------------------------------------------

-- BORRAR
CREATE PROCEDURE usp_categoria_eliminar
(
    @id_categoria INT
)
AS
BEGIN
    DELETE FROM CATEGORIA
    WHERE id_categoria = @id_categoria;
END
-- --------------------------------------------------------------------------------------------

-- SELECTOR POR ID DE LA CATEGORIA

CREATE PROCEDURE usp_categoria_consultar
(
    @id_categoria INT
)
AS
BEGIN
    SELECT id_categoria, nombre_catg, descripcion, estado_cat
    FROM CATEGORIA
    WHERE id_categoria = @id_categoria;
END
-- --------------------------------------------------------------------------------------------

-- LISTAR TODAS LAS CATEGORIAS

CREATE PROCEDURE usp_categoria_listar
AS
BEGIN
    SELECT id_categoria, nombre_catg, descripcion, estado_cat
    FROM CATEGORIA;
END

-- --------------------------------------------------------------------------------------------

/* =========================================================
PRODUCTOS
========================================================= */

-- REGISTRAR
CREATE PROCEDURE usp_producto_registrar
(
    @nombre_prod NVARCHAR(150),
    @sku NVARCHAR(50),
    @descripcion NVARCHAR(2000),
    @precio DECIMAL(10,2),
    @stock_qty INT,
    @estado_prod NVARCHAR(20),
    @id_categoria INT
)
AS
BEGIN
    INSERT INTO PRODUCTO
    (
        nombre_prod, -- preguntar si asi es mejor para documentar
        sku,
        descripcion,
        precio,
        stock_qty,
        estado_prod,
        id_categoria
    )
    VALUES
    (
        @nombre_prod,
        @sku,
        @descripcion,
        @precio,
        @stock_qty,
        @estado_prod,
        @id_categoria
    );
END

-- --------------------------------------------------------------------------------------------

-- borrar

CREATE PROCEDURE usp_borrar_producto
(
    @id_producto int
)
as
begin
    delete from PRODUCTO
    WHERE id_producto = @id_producto
end

-- --------------------------------------------------------------------------------------------

-- actualizar (PREGUNTARAS!!!!!!!!!!!!!!!!)
create procedure usp_actualizar_producto
(
    @id_producto INT,
    @nombre_prod NVARCHAR(150),
    @sku NVARCHAR(50),
    @descripcion NVARCHAR(2000),
    @precio DECIMAL(10,2),
    @stock_qty INT,
    @estado_prod NVARCHAR(20),
    @id_categoria INT
)
as
begin
    update PRODUCTO set
    nombre_prod = @nombre_prod,
    sku = @sku,
    descripcion = @descripcion,
    precio = @precio,
    stock_qty = @stock_qty,
    estado_prod = @estado_prod,
    id_categoria = @id_categoria
    where id_producto = @id_producto
end

-- --------------------------------------------------------------------------------------------

-- consultar
create procedure usp_consultar_producto
(
    @id_producto INT
)
as
begin
    select * from PRODUCTO
    where id_producto = @id_producto
end

-- --------------------------------------------------------------------------------------------

-- listar tabla productos

create procedure usp_listar_producto

as
begin
select * from PRODUCTO
end

-- --------------------------------------------------------------------------------------------

/* =========================================================
TABLA RESEÑA
========================================================= */

-- registrar
CREATE PROCEDURE usp_resena_registrar
(
    @rating INT,
    @comentario NVARCHAR(1000),
    @id_cliente VARCHAR(28),
    @id_producto INT
)
AS
BEGIN
    INSERT INTO RESENA
    (
        rating,
        comentario,
        id_cliente,
        id_producto
    )
    VALUES
    (
        @rating,
        @comentario,
        @id_cliente,
        @id_producto
    );
END

-- -------------------

-- actualizar
CREATE PROCEDURE usp_resena_actualizar
(
    @id_resena INT,
    @rating INT,
    @comentario NVARCHAR(1000)
)
AS
BEGIN
    UPDATE RESENA
    SET
        rating = @rating,
        comentario = @comentario
    WHERE id_resena = @id_resena;
END

-- -------------------

-- eliminar reseña
CREATE PROCEDURE usp_resena_eliminar
(
    @id_resena INT
)
AS
BEGIN
    DELETE FROM RESENA
    WHERE id_resena = @id_resena;
END

-- --------------------

-- listar reseñas por producto
CREATE PROCEDURE usp_resena_listar_por_producto
(
    @id_producto INT
)
AS
BEGIN
    SELECT
        id_resena,
        rating,
        comentario,
        fecha_resena,
        id_cliente
    FROM RESENA
    WHERE id_producto = @id_producto
    ORDER BY fecha_resena DESC; -- consultar mas acerca de desc
END

-- --------------------------------------------------------------------------------------------

/* =========================================================
TABLA FACTURA
========================================================= */

-- Insertar Factura

CREATE PROCEDURE usp_insertar_factura
    @nro_factura NVARCHAR(20),
    @subtotal DECIMAL(10,2),
    @iva DECIMAL(10,2),
    @total DECIMAL(10,2),
    @id_cliente VARCHAR(28)
AS
BEGIN
    INSERT INTO FACTURA (nro_factura, subtotal, iva, total, id_cliente)
    VALUES (@nro_factura, @subtotal, @iva, @total, @id_cliente)
END
-- --------------------------------------------------------------------------------------------

-- Actualizar Factura

CREATE PROCEDURE usp_actualizar_factura
    @id_factura BIGINT,
    @subtotal DECIMAL(10,2),
    @iva DECIMAL(10,2),
    @total DECIMAL(10,2)
AS
BEGIN
    UPDATE FACTURA
    SET subtotal = @subtotal,
        iva = @iva,
        total = @total
    WHERE id_factura = @id_factura
END
-- --------------------------------------------------------------------------------------------

-- Eliminar Factura

CREATE PROCEDURE usp_eliminar_factura
    @id_factura BIGINT
AS
BEGIN
    DELETE FROM FACTURA
    WHERE id_factura = @id_factura
END
-- --------------------------------------------------------------------------------------------

-- Consultar Factura

CREATE PROCEDURE usp_consultar_factura
    @id_factura BIGINT
AS
BEGIN
    SELECT * FROM FACTURA
    WHERE id_factura = @id_factura
END
-- --------------------------------------------------------------------------------------------

-- Listar Facturas

CREATE PROCEDURE usp_listar_facturas
AS
BEGIN
    SELECT * FROM FACTURA
END
-- --------------------------------------------------------------------------------------------

/* =========================================================
TABLA FACTURA_PRODUCTO                                                          -- este comentario comprueba que si se esta guardando
========================================================= */

-- Instertar Factura_producto

CREATE PROCEDURE usp_insertar_factura_producto
    @id_factura BIGINT,
    @id_producto INT,
    @cantidad INT,
    @precio DECIMAL(10,2)
AS
BEGIN
    INSERT INTO FACTURA_PRODUCTO
    (id_factura, id_producto, cantidad, precio)
    VALUES
    (@id_factura, @id_producto, @cantidad, @precio)
END
-- --------------------------------------------------------------------------------------------

-- Actualizar Factura_Producto

CREATE PROCEDURE usp_actualizar_factura_producto
    @id_factura BIGINT,
    @id_producto INT,
    @cantidad INT,
    @precio DECIMAL(10,2)
AS
BEGIN
    UPDATE FACTURA_PRODUCTO
    SET cantidad = @cantidad,
        precio = @precio
    WHERE id_factura = @id_factura
      AND id_producto = @id_producto
END
-- --------------------------------------------------------------------------------------------

-- Eliminar Factura_producto

CREATE PROCEDURE usp_eliminar_factura_producto
    @id_factura BIGINT,
    @id_producto INT
AS
BEGIN
    DELETE FROM FACTURA_PRODUCTO
    WHERE id_factura = @id_factura
      AND id_producto = @id_producto
END
-- --------------------------------------------------------------------------------------------

-- Consultar una Factura_producto

CREATE PROCEDURE usp_consultar_factura_producto
    @id_factura BIGINT,
    @id_producto INT
AS
BEGIN
    SELECT *
    FROM FACTURA_PRODUCTO
    WHERE id_factura = @id_factura
      AND id_producto = @id_producto
END
-- --------------------------------------------------------------------------------------------

-- Listar facturas_productos

CREATE PROCEDURE usp_listar_factura_productos
AS
BEGIN
    SELECT *
    FROM FACTURA_PRODUCTO
END
-- --------------------------------------------------------------------------------------------

/* =========================================================
TABLA PAGO
========================================================= */

-- Insertar Pago
CREATE PROCEDURE usp_insertar_pago
    @metodo_pago NVARCHAR(20),
    @monto DECIMAL(10,2),
    @estado NVARCHAR(20),
    @id_factura BIGINT
AS
BEGIN
    INSERT INTO PAGO (metodo_pago, monto, estado, id_factura)
    VALUES (@metodo_pago, @monto, @estado, @id_factura)
END
-- --------------------------------------------------------------------------------------------

-- Actualizar Pago
CREATE PROCEDURE usp_actualizar_pago
    @id_pago BIGINT,
    @estado NVARCHAR(20)
AS
BEGIN
    UPDATE PAGO
    SET estado = @estado
    WHERE id_pago = @id_pago
END
-- --------------------------------------------------------------------------------------------

-- Eliminar_Pago
CREATE PROCEDURE usp_eliminar_pago
    @id_pago BIGINT
AS
BEGIN
    DELETE FROM PAGO
    WHERE id_pago = @id_pago
END
-- --------------------------------------------------------------------------------------------

-- Consultar un Pago
CREATE PROCEDURE usp_consultar_pago
    @id_pago BIGINT
AS
BEGIN
    SELECT * FROM PAGO
    WHERE id_pago = @id_pago
END
-- --------------------------------------------------------------------------------------------

-- Listar todos los pagos
CREATE PROCEDURE usp_listar_pagos
AS
BEGIN
    SELECT * FROM PAGO
END
-- --------------------------------------------------------------------------------------------

/* =========================================================
TABLA DEPARTAMENTO                  -- Creo que hay que crear unos seeds para esto, but creo que es bueno crearlo por si se crea un departamento nuevo en colombia :v jajaja.
========================================================= */

-- Insertar departamento
CREATE PROCEDURE usp_insertar_departamento
    @nombre_dep VARCHAR(60),
    @codigo_dane_dep VARCHAR(10),
    @estado_dep NVARCHAR(30)
AS
BEGIN
    INSERT INTO DEPARTAMENTO (nombre_dep, codigo_dane_dep, estado_dep)
    VALUES (@nombre_dep, @codigo_dane_dep, @estado_dep)
END
-- --------------------------------------------------------------------------------------------

-- Listar Departamentos
CREATE PROCEDURE usp_listar_departamentos
AS
BEGIN
    SELECT * FROM DEPARTAMENTO
END
-- --------------------------------------------------------------------------------------------

-- Actualizar Departamento
CREATE PROCEDURE usp_actualizar_departamento
    @id_departamento INT,
    @nombre_dep VARCHAR(60),
    @codigo_dane_dep VARCHAR(10),
    @estado_dep NVARCHAR(30)
AS
BEGIN
    UPDATE DEPARTAMENTO
    SET nombre_dep = @nombre_dep,
        codigo_dane_dep = @codigo_dane_dep,
        estado_dep = @estado_dep
    WHERE id_departamento = @id_departamento
END
-- --------------------------------------------------------------------------------------------

-- Eliminar Departamento
CREATE PROCEDURE usp_eliminar_departamento
    @id_departamento INT
AS
BEGIN
    DELETE FROM DEPARTAMENTO
    WHERE id_departamento = @id_departamento
END
-- --------------------------------------------------------------------------------------------

-- Consultar Departamento
CREATE PROCEDURE usp_consultar_departamento
    @id_departamento INT
AS
BEGIN
    SELECT * FROM DEPARTAMENTO
    WHERE id_departamento = @id_departamento
END
-- --------------------------------------------------------------------------------------------

/* =========================================================
TABLA CIIDAD
========================================================= */
-- Insertar una Ciudad
CREATE PROCEDURE usp_insertar_ciudad
    @nombre_ciu VARCHAR(60),
    @codigo_dane_ciu VARCHAR(10),
    @estado_ciu NVARCHAR(30),
    @id_departamento INT
AS
BEGIN
    INSERT INTO CIUDAD (nombre_ciu, codigo_dane_ciu, estado_ciu, id_departamento)
    VALUES (@nombre_ciu, @codigo_dane_ciu, @estado_ciu, @id_departamento)
END
-- --------------------------------------------------------------------------------------------

-- Listar Ciudades
CREATE PROCEDURE usp_listar_ciudades
AS
BEGIN
    SELECT * FROM CIUDAD
END
-- --------------------------------------------------------------------------------------------

-- Actualizar Ciudad
CREATE PROCEDURE usp_actualizar_ciudad
    @id_ciudad INT,
    @nombre_ciu VARCHAR(60),
    @codigo_dane_ciu VARCHAR(10),
    @estado_ciu NVARCHAR(30),
    @id_departamento INT
AS
BEGIN
    UPDATE CIUDAD
    SET nombre_ciu = @nombre_ciu,
        codigo_dane_ciu = @codigo_dane_ciu,
        estado_ciu = @estado_ciu,
        id_departamento = @id_departamento
    WHERE id_ciudad = @id_ciudad
END
-- --------------------------------------------------------------------------------------------

-- Eliminar Ciudad
CREATE PROCEDURE usp_eliminar_ciudad
    @id_ciudad INT
AS
BEGIN
    DELETE FROM CIUDAD
    WHERE id_ciudad = @id_ciudad
END
-- --------------------------------------------------------------------------------------------

-- Consultar Ciudad
CREATE PROCEDURE usp_consultar_ciudad
    @id_ciudad INT
AS
BEGIN
    SELECT * FROM CIUDAD
    WHERE id_ciudad = @id_ciudad
END
-- --------------------------------------------------------------------------------------------

/* =========================================================
TABLA CODIGO POSTAL
========================================================= */

-- insertar codigo postal
CREATE PROCEDURE usp_insertar_cp
    @id_cp INT,
    @cp VARCHAR(6),
    @estado_cp NVARCHAR(30),
    @id_ciudad INT
AS
BEGIN
    INSERT INTO CODIGO_POSTAL (id_cp, cp, estado_cp, id_ciudad)
    VALUES (@id_cp, @cp, @estado_cp, @id_ciudad)
END
-- --------------------------------------------------------------------------------------------

-- Actualizar un codigo postal
CREATE PROCEDURE usp_actualizar_codigo_postal
    @id_cp INT,
    @cp VARCHAR(6),
    @estado_cp NVARCHAR(30),
    @id_ciudad INT
AS
BEGIN
    UPDATE CODIGO_POSTAL
    SET cp = @cp,
        estado_cp = @estado_cp,
        id_ciudad = @id_ciudad
    WHERE id_cp = @id_cp
END
-- --------------------------------------------------------------------------------------------

-- Eliminar un codigo postal 
CREATE PROCEDURE usp_eliminar_codigo_postal
    @id_cp INT
AS
BEGIN
    DELETE FROM CODIGO_POSTAL
    WHERE id_cp = @id_cp
END
-- --------------------------------------------------------------------------------------------

-- Consultar un codigo postal
CREATE PROCEDURE usp_consultar_codigo_postal
    @id_cp INT
AS
BEGIN
    SELECT * FROM CODIGO_POSTAL
    WHERE id_cp = @id_cp
END
-- --------------------------------------------------------------------------------------------
-- Listar todos los codigos postales
CREATE PROCEDURE usp_listar_codigos_postales
AS
BEGIN
    SELECT * FROM CODIGO_POSTAL
END
-- --------------------------------------------------------------------------------------------

/* =========================================
   CRUD TABLA ENVIO
   ========================================= */

-- Insertar envio
CREATE PROCEDURE usp_insertar_envio
    @direc_envio NVARCHAR(255),
    @estado_envio NVARCHAR(30),
    @costo_envio DECIMAL(10,2),
    @metodo_envio NVARCHAR(30),
    @empresa_envio VARCHAR(50),
    @fecha_entrega DATETIME2 = NULL,
    @id_pago BIGINT,
    @id_cp INT
AS
BEGIN
    INSERT INTO ENVIO (
        direc_envio,
        estado_envio,
        costo_envio,
        metodo_envio,
        empresa_envio,
        fecha_entrega,
        id_pago,
        id_cp
    )
    VALUES (
        @direc_envio,
        @estado_envio,
        @costo_envio,
        @metodo_envio,
        @empresa_envio,
        @fecha_entrega,
        @id_pago,
        @id_cp
    )
END
-- --------------------------------------------------------------------------------------------

-- Actualizar envios
CREATE PROCEDURE usp_actualizar_envio
    @id_envio BIGINT,
    @direc_envio NVARCHAR(255),
    @estado_envio NVARCHAR(30),
    @costo_envio DECIMAL(10,2),
    @metodo_envio NVARCHAR(30),
    @empresa_envio VARCHAR(50),
    @fecha_entrega DATETIME2,
    @id_pago BIGINT,
    @id_cp INT
AS
BEGIN
    UPDATE ENVIO
    SET direc_envio = @direc_envio,
        estado_envio = @estado_envio,
        costo_envio = @costo_envio,
        metodo_envio = @metodo_envio,
        empresa_envio = @empresa_envio,
        fecha_entrega = @fecha_entrega,
        id_pago = @id_pago,
        id_cp = @id_cp
    WHERE id_envio = @id_envio
END
-- --------------------------------------------------------------------------------------------

-- Eliminar un envio
CREATE PROCEDURE usp_eliminar_envio
    @id_envio BIGINT
AS
BEGIN
    DELETE FROM ENVIO
    WHERE id_envio = @id_envio
END
-- --------------------------------------------------------------------------------------------

-- Consultar envio por id
CREATE PROCEDURE usp_consultar_envio
    @id_envio BIGINT
AS
BEGIN
    SELECT * FROM ENVIO
    WHERE id_envio = @id_envio
END
-- --------------------------------------------------------------------------------------------

-- Listar todos los envios
CREATE PROCEDURE usp_listar_envios
AS
BEGIN
    SELECT * FROM ENVIO
END
-- --------------------------------------------------------------------------------------------

-- FIN!! <3













