/* 
Identificar las entidades
1. Clientes
2. Cuentas
3. Transacciones

Extraer los RF
1. El sistema debe registrar el nombre completo, correo, número de teléfono, fecha de nacimiento 
y ID de cliente.
2. El sistema debe registrar el número de cuenta, tipo de moneda, tipo de cuenta, saldo actual y límite de crédito.
3. El sistema debe registrar cada movimiento especificando la cuenta de origen, cuenta de destino, monto,
tipo de transacción y fecha exacta.


CORRECCIÓN: En comparación con mi demo y la corrección del profesor, he notado que no incluí la restricción de unicidad 
para el Tax ID de los clientes. Esto es importante para evitar duplicados y asegurar la integridad de los datos.



1. Lista de Entidades:

Clientes (Customers)
Cuentas (Accounts)
Transacciones (Transactions)
2. Requerimientos Funcionales (RF):

RF1: El sistema debe almacenar de los Clientes: nombre, correo, teléfono, fecha de nacimiento y Tax ID.
RF2: El sistema debe almacenar de las Cuentas: número de cuenta, moneda, tipo de cuenta, saldo actual y límite de crédito, y a qué cliente pertenecen.
RF3: El sistema debe almacenar de las Transacciones: cuenta origen, cuenta destino, monto, tipo de transacción y fecha/hora exacta.
3. Restricción de unicidad:

El sistema no debe permitir que dos clientes tengan el mismo Tax ID o número de identificación fiscal (Debe ser UNIQUE).
 * 