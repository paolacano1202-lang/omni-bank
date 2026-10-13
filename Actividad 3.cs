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
 * 