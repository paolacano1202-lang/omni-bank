/*
SELECT account_id, account_type, owner_name
FROM accounts 
WHERE is_active = TRUE
AND NOT EXISTS ( SELECT 1 FROM events WHERE events_account_id = accounts_account_id
AND events_type = 'deposit');
 
SELECT COUNT (*) AS total_activas_sin_depositos
FROM accounts 
WHERE is_active = TRUE
AND NOT EXISTS ( SELECT 1 FROM events WHERE events_account_id = accounts_account_id
AND events_type = 'deposit');


CORRECCIÓN: Gracias a la técnica de subconsulta correlacionada, podemos identificar cuentas activas que no han registrado depósitos. 
La consulta principal selecciona las cuentas activas y utiliza una subconsulta para verificar la ausencia de eventos de tipo 'deposit'. 
La segunda consulta cuenta el total de estas cuentas, proporcionando un resumen cuantitativo. Me parece que la solución es correcta y eficiente,
ya que evita uniones innecesarias y se centra en la existencia de registros relevantes.


Tres cuentas activas carecen de DEPOSIT: ACCT-1001, ACCT-2001 y ACCT-3002. Las dos primeras sí tienen otros movimientos.

Reference Solution
SELECT a.account_number, a.account_type
FROM core.accounts a
LEFT JOIN core.transactions t ON t.account_id = a.account_id AND t.tx_type = 'DEPOSIT'
WHERE a.is_active AND t.transaction_id IS NULL
ORDER BY a.account_number;
Lectura de la solución: El catálogo de productos solicita una lista más operativa: cuentas activas que aún no registran un depósito. La actividad ya estableció cómo expresar ausencia; ahora la tarea aplica esa técnica a un tipo de evento concreto y conserva la comparación de pares de movimientos como evidencia.
 * 