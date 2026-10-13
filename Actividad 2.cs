/*
Clientes | Cuentas | Transacciones   • Cliente - id (PK)
• Cuenta - id (PK)
• transacción - id (PK)   Cuenta:
cuenta - id
tipo - moneda
tipo - cuenta
saldo - actual
límite - crédito   Cliente:
nombre - cliente
correo - elect.
num - teléfono
Fecha - nacimiento
Cliente - id   transacción:
Cuenta - origen
Cuenta - destino
monto
tipo - transacción
Fecha exacta   • La relación Cliente - Cuenta es 1:N
• La relación Cuenta - Cliente es 1:1   [Cliente] -------- [Cuenta]   La relación Cuenta - transacción es 1:N
La relación transacción - Cuenta es N:1   [Cuenta] -------< [transacción]  


CORRECCIÓN: Logré aprender a diseñar un diagrama ER con tres tablas conectadas correctamente mediante llaves foráneas. 
Las cardinalidades clave son: 1 Cliente -> Muchas Cuentas. Y la tabla Transacciones tiene DOS llaves foráneas apuntando a Cuentas,
una para la cuenta de origen y otra para la cuenta de destino. Esto permite registrar transacciones entre diferentes cuentas de clientes,
manteniendo la integridad referencial en la base de datos.


El estudiante debe haber diseñado un diagrama ER con tres tablas conectadas correctamente mediante llaves foráneas. Las cardinalidades clave son: 1 Cliente -> Muchas Cuentas. Y la tabla Transacciones debe tener DOS llaves foráneas apuntando a Cuentas.

Reference Solution
[Clientes] 1 ------------ N [Cuentas]
- cliente_id (PK)             - cuenta_id (PK)
- nombre                      - cliente_id (FK)
- correo                      - moneda
- telefono                    - tipo_cuenta
- fecha_nacimiento            - saldo_actual
- tax_id                      - limite_credito

                   (Cuenta Origen)
[Cuentas] 1 ------------------------- N [Transacciones]
                                          - transaccion_id (PK)
                   (Cuenta Destino)       - from_account (FK -> Cuentas)
[Cuentas] 1 ------------------------- N   - to_account (FK -> Cuentas)
                                          - monto
                                          - tipo_transaccion
                                          - fecha_completada
 * 