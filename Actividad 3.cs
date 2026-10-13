/*
1.- Paso 1: Primera forma normal (1NF)
(Nota: Contiene una tabla esquemática con los campos transacción-id, fecha-tx, cliente-tax-id, nombre-cliente, correo, num-cliente, cuenta-número, tipo-cuenta, mon, tipo-mon, saldo, etc.)   2.- Paso 2: Segunda y Tercera Forma Normal (2NF y 3NF)
(Nota: Contiene tablas desglosadas para transacciones, cuentas y cliente)   [Cliente] (3NF)
• Cliente - tax - id (PK)
• Nombre - cliente
• Correo
• Num - Cliente   [Cuenta 5] (3NF)
• Nombre - Cliente
• tipo - Cuenta
• Cuenta - numero
• Saldo (PK)
• transacción - id (FK)   [Transacciones] (3NF)
• Cliente - tax - id (FK)
• mon
• Tipo - mon
• Tipo - Cuenta
• Cuenta - numero
• Nombre - Cliente
• fecha - tx
• transacción - id (PK) 



CORRECCIÓN: Gracias a esta tarea aprendí a transformar un monolito de datos desordenados en un esquema relacional en 3NF, 
eliminando redundancias y asegurando la integridad referencial mediante el uso de llaves primarias y foráneas. Esto me permitió 
comprender mejor cómo estructurar la información de manera eficiente y cómo las dependencias transitivas pueden afectar la normalización de una base de datos.


El estudiante deberá haber transformado el monolito de la tabla desordenada en un esquema relacional en 3NF consistente en 4 tablas: Clientes, Cuentas, Sucursales, y Transacciones, eliminando las redundancias de texto y datos multi-valorados y asegurando el uso de llaves primarias (PK) y llaves foráneas (FK) con dependencias transitivas resueltas.

Reference Solution
1. Corrección a 1NF (Atomicidad de Campos):

Desarmar cliente_nombre_y_contacto en columnas individuales: nombre, email, telefono.
Desarmar moneda_y_tipo en: moneda y tipo_cuenta.
2. Separación Relacional en 3NF:

[Sucursales] (3NF - Elimina redundancia transitiva de direcciones repetidas en cada venta)
- sucursal_id (PK)      -- Ej: S-CDMX
- direccion             -- Ej: Av. Juárez #100

[Clientes] (3NF - Elimina duplicidad masiva del cliente en cada transacción o cuenta)
- cliente_id (PK/TaxID) -- Ej: TAX-9911 (O preferentemente UUID en práctica real)
- nombre                -- Ej: Roberto Soto
- email                 -- Ej: rob@mail.com
- telefono              -- Ej: 555-9011

[Cuentas] (3NF - Dependencia directa de Cuenta a Cliente y Sucursal de apertura)
- cuenta_numero (PK)    -- Ej: CTA-100
- cliente_id (FK -> Clientes)
- sucursal_id (FK -> Sucursales)
- moneda                -- Ej: USD
- tipo_cuenta           -- Ej: Checking
- saldo_actual          -- Ej: 1300.00

[Transacciones] (3NF - Registro atómico exclusivo del evento financiero)
- transaccion_id (PK)   -- Ej: TX-0001, TX-0002
- cuenta_numero (FK -> Cuentas)
- fecha_tx
- monto_tx
 * 