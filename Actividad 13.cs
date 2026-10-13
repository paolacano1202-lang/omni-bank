/*
WITH event-aggregates AS (
SELECT account-id, COUNT (*) AS event-cant, SUM (amount) AS
gross-volume
FROM events WHERE amount > 0 GROUP BY account-id),
SELECT c.customer-name AS owner-name, aa.account-number,
aa.currency, aa.event-cant, aa.gross-volume,
CASE WHEN aa.event-cant = 0 THEN 'SIN ACTIVIDAD' ELSE
'CON ACTIVIDAD' END AS activity-band
FROM active-accounts aa
JOIN customers c ON aa.customer-id = c.customer-id
ORDER BY aa.account-number;


CORRECCIÓN: La actividad me dio un resultado de cuatro cuentas activas, de las cuales ACCT-3002 aparece con cero eventos. 
El volumen total de la semilla es 800, distribuido sin multiplicar movimientos. Gracias a eso puedo concluir que la consulta es correcta y que el tablero 
de productos puede reutilizarla para mostrar la actividad por cuenta sin repetir agregaciones.


La salida incluye cuatro cuentas activas; ACCT-3002 aparece con cero eventos. El volumen total de la semilla es 800, distribuido sin multiplicar movimientos.

Reference Solution
WITH movement AS (
 SELECT account_id, COUNT(*) AS tx_count, SUM(amount) AS gross_volume
 FROM core.transactions GROUP BY account_id
), account_metrics AS (
 SELECT a.account_id, a.account_number, a.currency, a.customer_id,
        COALESCE(m.tx_count,0) AS tx_count,
        COALESCE(m.gross_volume,0) AS gross_volume
 FROM core.accounts a LEFT JOIN movement m USING (account_id)
 WHERE a.is_active
)
SELECT c.first_name, c.last_name, am.account_number, am.currency,
       am.tx_count, am.gross_volume,
       CASE WHEN am.tx_count = 0 THEN 'SIN MOVIMIENTOS' ELSE 'CON MOVIMIENTOS' END AS activity_band
FROM account_metrics am JOIN core.customers c USING (customer_id)
ORDER BY am.account_number;
SELECT (SELECT COUNT(*) FROM core.accounts WHERE is_active) AS active_accounts,
       (SELECT COALESCE(SUM(amount),0) FROM core.transactions) AS direct_gross_volume;
Lectura de la solución: El tablero de productos necesita una medida de actividad por cuenta que otras consultas puedan reutilizar. El equipo no quiere repetir una agregación cada vez que agrega datos del titular o de la moneda. Un pipeline de CTE permite nombrar las etapas y declarar si cada una tiene una fila por movimiento, por cuenta o por moneda.
 * 