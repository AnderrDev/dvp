-- sql server management studio
-- Vamos a crear un perfil developer con la contraseña abc123ABC

-- primero usar la base de datos master

USE master;

-- crear el login

CREATE LOGIN developer WITH PASSWORD = 'abc123ABC';

-- crear el usuario

CREATE USER developer FOR LOGIN developer;

-- darle permisos de administrador

ALTER SERVER ROLE sysadmin ADD MEMBER developer;

-- crear la base de datos LabDev si no existe

IF NOT EXISTS (SELECT *
FROM sys.databases
WHERE name = 'LabDev')
BEGIN
    USE master;
    CREATE DATABASE LabDev;
END
-- imprimir el mensaje
PRINT 'Base de datos creada';


-- create table bill in LabDev

USE LabDev;

CREATE TABLE bill
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    broadcast_date DATETIME NOT NULL,
    client_id INT NOT NULL,
    num_bill INT NOT NULL,
    num_total_products INT NOT NULL,
    sub_total DECIMAL(18,2) NOT NULL,
    tax DECIMAL(18,2) NOT NULL,
    total DECIMAL(18,2) NOT NULL
);

-- create table bill_detail in LabDev

CREATE TABLE bill_detail
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    bill_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(18,2) NOT NULL,
    sub_total DECIMAL(18,2) NOT NULL,
    notes VARCHAR(200) NOT NULL
);

-- create table product in LabDev

CREATE TABLE product
(
    -- product image
    -- precio unitario
    -- ext
    id INT IDENTITY(1,1) PRIMARY KEY,
    product_name VARCHAR(50) NOT NULL,
    product_description VARCHAR(200) NOT NULL,
    product_price DECIMAL(18,2) NOT NULL,
    product_stock INT NOT NULL,
);

-- create table user in LabDev

CREATE TABLE client
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL
);

-- create table user_role in LabDev

CREATE TABLE user_type
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    role VARCHAR(50) NOT NULL
);