/*
SELECT
t. transaction - id
c. first - name || ' ' || c. last - name AS customer - name,
a. accant - number,
t. tx - type,
t. amant.
FROM core transactions t
INNER JOIN core. accounts a ON t. accants - id = a. accounts - id
ORDER BY t. tx - timestamp ASC, t. transaction - id ASC;   SELECT
c. email,
a. account - number,
a. balance
FROM core. Customers c
LEFT JOIN core. accant a
ON c. customers - id = a. customer - id
AND a. balance > 0;


CORRECCIÓN: Aprendí que la cláusula WHERE en LEFT JOIN elimina las filas externas sin pareja elegible, 
mientras que el predicado de cuenta elegible pertenece a ON. is_active y ausencia de movimiento son atributos diferentes y no deben codificarse en el enum tx_type.


El checkpoint aporta cuatro clientes, cinco cuentas y cuatro movimientos. El recorrido de eventos devuelve cuatro filas; la consulta de ausencia devuelve ACCT-1002 desactivada y ACCT-3002 activa. El reporte de titulares con balance>0 conserva a los cuatro clientes, con columnas de cuenta nulas para Alice y Humberto. La variante con el filtro en WHERE pierde esas dos personas.

Reference Solution
SELECT (SELECT COUNT(*) FROM core.customers) AS customers,
       (SELECT COUNT(*) FROM core.accounts) AS accounts,
       (SELECT COUNT(*) FROM core.transactions) AS movements;

SELECT t.transaction_id,c.first_name,c.last_name,a.account_number,t.tx_type,t.amount
FROM core.transactions t
JOIN core.accounts a ON a.account_id=t.account_id
JOIN core.customers c ON c.customer_id=a.customer_id
ORDER BY t.tx_timestamp,t.transaction_id;

SELECT a.account_number,a.is_active,
       CASE WHEN a.is_active THEN 'ACTIVA SIN MOVIMIENTOS'
            ELSE 'DESACTIVADA SIN MOVIMIENTOS' END AS estado
FROM core.accounts a
LEFT JOIN core.transactions t ON t.account_id=a.account_id
WHERE t.transaction_id IS NULL
ORDER BY a.account_number;

SELECT c.email,a.account_number,a.balance
FROM core.customers c
LEFT JOIN core.accounts a
  ON a.customer_id=c.customer_id AND a.balance>0
ORDER BY c.email,a.account_number;

-- Comparación diagnóstica: WHERE elimina las filas externas sin pareja elegible.
SELECT c.email,a.account_number,a.balance
FROM core.customers c
LEFT JOIN core.accounts a ON a.customer_id=c.customer_id
WHERE a.balance>0
ORDER BY c.email,a.account_number;
La última consulta devuelve solo John y Jane; si se requiere preservar a los titulares, el predicado de cuenta elegible pertenece a ON. is_active y ausencia de movimiento son atributos diferentes y no deben codificarse en el enum tx_type.
 * 