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
 * 