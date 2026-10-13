/*
1.- El espacio modular:
CREATE SCHEMA IF NOT EXIST CORE;   2.- Construyendo la entidad Raíz:
Create table core. customers (
Customer - id UUID default gen - random - uuid(),
Full - name VARCHAR (150) not null,
phone VARCHAR (100) NOT NULL,
email VARCHAR (100) NOT NULL,
is - active BOOLEAN DEFAULT true NOT NULL,
Created - at TIMESTAMPTZ DEFAULT CURRENT - TIMESTAMP NOT NULL
);   3.- Construyendo las Entidades hijas:
Create table core. accounts (
account - id UUID default gen - random - uuid(),
account - type core. tipo - cuenta NOT NULL,
currency core. tipo - moneda default 'MXN' NOT NULL,
balance numeric (15, 2) default 0.00 NOT NULL
);   4.- Eslabón operacional transaccional:
Create table core. transactions (
transaction - id UUID default gen - random - uuid(),
account - id UUID NOT NULL
transaction - type core. tipo - transaction NOT NULL,
amant NUMERIC (15, 2) NOT NULL.
);  
 * 