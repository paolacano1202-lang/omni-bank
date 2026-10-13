/*
SELECT COUNT(*) AS total_cartesian_product
FROM transactions
CROSS JOIN accounts
CROSS JOIN customers;
 SELECT 
c.email,
a.account_id,
t.type,
t.amount,
t.transaction_date
FROM transactions t
INNER JOIN accounts a
ON t.account_id = a.account_id
WHERE c.is.active = true
AND t.amount > 100
ORDER BY t.transaction_date ASC, t.transaction_id ASC;


CORRECCIÓN: Pude aprender que la solución definitiva y profesional para entornos de altísima concurrencia relacional es 
la aplicación en dos fases de la cláusula NOT VALID y la posterior orden independiente VALIDATE CONSTRAINT, 
evitando AccessExclusiveLock y permitiendo la continuidad operativa del banco.


Los recuentos de la semilla son 4, 5 y 4: el producto es 80. El reporte con claves muestra tres eventos de al menos 100, no 80 operaciones.

Reference Solution
SELECT (SELECT COUNT(*) FROM core.customers) AS customers,
       (SELECT COUNT(*) FROM core.accounts) AS accounts,
       (SELECT COUNT(*) FROM core.transactions) AS transactions;
SELECT COUNT(*) AS combinations
FROM core.customers CROSS JOIN core.accounts CROSS JOIN core.transactions;

SELECT c.email,a.account_number,t.tx_type,t.amount,t.tx_timestamp
FROM core.transactions t
JOIN core.accounts a ON a.account_id=t.account_id
JOIN core.customers c ON c.customer_id=a.customer_id
WHERE c.is_active AND t.amount>=100
ORDER BY t.tx_timestamp,t.transaction_id;
El CROSS JOIN enumera todas las combinaciones posibles de las tres relaciones. La unión con claves preserva la pertenencia de cada movimiento a una cuenta y de esta a un cliente. El número de combinaciones por sí solo no determina el plan físico, la memoria usada ni el tiempo de respuesta.

Lectura de la solución: Una consulta exploratoria sin condiciones de unión puede producir muchas combinaciones que parecen operaciones bancarias pero que no corresponden a ninguna relación real. El área de revisión quiere cuantificar ese error lógico antes de incorporar el reporte al repositorio. La tarea extiende los JOIN de la actividad y deja un archivo reutilizable para los días de agregaciones.
 * 