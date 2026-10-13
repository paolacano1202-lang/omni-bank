/*
SELECT e1.account-id, e1.event-id ev1, e2.event-id ev2
FROM events e1 JOIN events e2
ON e1.account-id = e2.account-id AND e1.event-id < e2.event-id
AND e2.created-at <= e1.created-at + INTERVAL '48 hours';   SELECT c.customers-name, t.account-type
FROM customers c CROSS JOIN (SELECT DISTINCT account-type
FROM accounts)
WHERE NOT EXISTS (
SELECT 1 FROM accounts a
WHERE a.customer-id = c.customer-id AND a.account-type =
t.account-type
); 


CORRECCIÓN: Gracias a la solución del profesor, pude aprender que la solución definitiva y profesional para entornos de altísima concurrencia relacional es la 
aplicación en dos fases de la cláusula NOT VALID y la posterior orden independiente VALIDATE CONSTRAINT, evitando AccessExclusiveLock y permitiendo la 
continuidad operativa del banco.



John ofrece un par de movimientos iniciales en la misma cuenta. La matriz muestra posibilidades faltantes sin inventar sucursales ni relaciones por moneda.

Reference Solution
SELECT t1.account_id, t1.transaction_id AS earlier_id, t2.transaction_id AS later_id
FROM core.transactions t1 JOIN core.transactions t2
 ON t1.account_id = t2.account_id
 AND (t1.tx_timestamp,t1.transaction_id) < (t2.tx_timestamp,t2.transaction_id)
 AND t2.tx_timestamp <= t1.tx_timestamp + INTERVAL '48 hours'
ORDER BY t1.account_id, t1.tx_timestamp;

WITH types AS (
 SELECT unnest(enum_range(NULL::core.tipo_cuenta)) AS account_type
)
SELECT c.customer_id, c.email, ty.account_type
FROM core.customers c CROSS JOIN types ty
LEFT JOIN core.accounts a ON a.customer_id = c.customer_id AND a.account_type = ty.account_type
WHERE a.account_id IS NULL ORDER BY c.email, ty.account_type;
Lectura de la solución: Producto quiere comparar movimientos de una misma cuenta y conocer qué combinaciones de titular y tipo de cuenta aún no existen. Son dos preguntas distintas: el self JOIN examina pares de eventos reales; la matriz de productos enumera posibilidades y el anti JOIN señala ausencias. Compartir moneda no convierte dos cuentas en sucursales ni en la misma relación.
 * 