/*
SELECT
COUNT(*) AS total_Cuentas,
CONT (*) FILTER (WHERE Status = 'inactive') AS desactivadas,
ROUND ((COUNT(*) FILTER(WHERE Status = 'Inactive"):: NUMERIC 
FROM accounts;
SELECT
tx-Id,
+x-timestamp,
+x-timestamp + INTERVAL ‘15 days’ AS Fecha_revision,
FROM transactions
ORDER BY tx_id;


CORRECCIÓN: Este tema me gustó mucho, ya que me permitió aprender a realizar consultas de agregación y filtrado en SQL, 
así como a calcular porcentajes y manejar intervalos de tiempo. Además, comprendí la importancia de mantener la consistencia de los datos y 
cómo las funciones de agregación pueden ayudar a obtener información valiosa sobre el estado de las cuentas y transacciones en una base de datos.


La semilla tiene una cuenta desactivada de cinco, por lo que el porcentaje es 20.00%. Los cuatro movimientos conservan las fechas de revisión del 16 al 19 de septiembre.

Reference Solution
SELECT COUNT(*) AS total_accounts,
       COUNT(*) FILTER (WHERE NOT is_active) AS inactive_accounts,
       ROUND(100.0*COUNT(*) FILTER (WHERE NOT is_active)::numeric
             /NULLIF(COUNT(*),0),2) AS inactive_pct
FROM core.accounts;

SELECT CONCAT(UPPER(TRIM(c.first_name)),' ',UPPER(TRIM(c.last_name))) AS customer_name,
       CONCAT('XXXX-',RIGHT(a.account_number,4)) AS masked_account,
       t.transaction_id,t.tx_timestamp,
       t.tx_timestamp + INTERVAL '15 days' AS review_on,
       AGE(TIMESTAMPTZ '2026-10-01 00:00+00',t.tx_timestamp) AS age_at_review
FROM core.transactions t
JOIN core.accounts a ON a.account_id=t.account_id
JOIN core.customers c ON c.customer_id=a.customer_id
WHERE t.tx_timestamp<TIMESTAMPTZ '2026-09-10 00:00+00'
ORDER BY t.tx_timestamp;
La división entera 1/5 trunca a cero. El literal 100.0 y el cast NUMERIC conservan la fracción. El intervalo respeta la aritmética temporal de PostgreSQL; la fecha fija hace repetible la revisión.

Lectura de la solución: El responsable operativo solicita dos indicadores derivados de los reportes de la actividad: proporción de cuentas desactivadas y antigüedad de cada evento al corte de revisión. Ambos deben ser reproducibles con la semilla y mantener claro el tipo de dato de cada operación.
/*