/*
SELECT accant-type,
COUNT AS cantidad-cuentas, SUM (balance) AS saldo-total, MIN (balance)
AS saldo-minimo, MAX (balance) AS saldo-maximo, AVG (balance)
AS saldo-promedio
FROM core.accounts
WHERE is_active = TRUE
GROUP BY accant-type
ORDER BY saldo-total, accant type;   SELECT c.Customers-id,
cant (t.transactions-id) As movimientos, COALESCE(SUM(t.amant), 0)
As volumen-bruto
FROM core.Customers c
LEFT JOIN core.accounts a ON a.customer_id = c.customer-id
LEFT JOIN core.transactions t ON t.account-id = a.account-id
GROUP BY c.customer-id
HAVING COUNT (t.transactions-id) >= 2
OR COALESCE(SUM (t.amant), 0) > 100
ORDER BY volumen-bruto DESC, c.customer-id;   SELECT
COUNT (transaction-id) AS movimientos,
SUM (amount) AS volumen-bruto
FROM core.transactions; 


CORRECCIÓN: Con la tarea realizada pude aprender que la semilla de datos de OmniBank contiene cuatro cuentas activas y cuatro eventos, y 
que la cuenta CREDIT de Alice tiene saldo almacenado cero y un depósito histórico de 300. La coexistencia no obliga a corregir ningún dato: 
la semilla solo registra parte de la historia. La condición de HAVING se evalúa después de agrupar; moverla a WHERE no compila como condición agregada. Entendí mucho mejor que
mientras la cuenta CREDIT de Alice tiene saldo almacenado cero, su depósito histórico de 300 no se refleja en el balance actual.
Esto significa que la información almacenada en la base de datos no siempre coincide con los eventos históricos, y es importante tener en cuenta estas 
diferencias al analizar los datos. Además, comprendí que las consultas SQL deben ser cuidadosamente estructuradas para obtener resultados precisos y relevantes, 
especialmente cuando se trabaja con agregaciones y condiciones de filtrado.



Las cuatro cuentas activas suman 19 950: CHECKING 4 950, SAVINGS 15 000 y CREDIT 0. El segmento de actividad contiene a Alice y Jane con volumen bruto 300, y a John con 200 y dos eventos. Los cuatro eventos suman 800. Ninguna de esas sumas de eventos representa el saldo de una cuenta.

Reference Solution
-- Grano: account_type. balance procede solo de accounts.
SELECT account_type,
       COUNT(*) AS account_count,
       SUM(balance) AS stored_balance_total,
       MIN(balance) AS smallest_stored_balance,
       MAX(balance) AS largest_stored_balance,
       ROUND(AVG(balance),2) AS average_stored_balance
FROM core.accounts
WHERE is_active
GROUP BY account_type
ORDER BY stored_balance_total DESC,account_type;

-- Grano: cliente. transaction_id cuenta eventos reales, no filas externas.
SELECT c.customer_id,c.first_name,c.last_name,c.email,
       COUNT(t.transaction_id) AS recorded_event_count,
       COALESCE(SUM(t.amount),0) AS recorded_gross_volume
FROM core.customers c
LEFT JOIN core.accounts a ON a.customer_id=c.customer_id
LEFT JOIN core.transactions t ON t.account_id=a.account_id
GROUP BY c.customer_id,c.first_name,c.last_name,c.email
HAVING COUNT(t.transaction_id)>=2 OR COALESCE(SUM(t.amount),0)>100
ORDER BY recorded_gross_volume DESC,c.email;

-- Controles independientes: cada medida se obtiene en su tabla de origen.
SELECT COUNT(*) AS active_accounts,SUM(balance) AS stored_balance_total
FROM core.accounts WHERE is_active;
SELECT COUNT(*) AS recorded_events,SUM(amount) AS recorded_gross_volume
FROM core.transactions;
La cuenta CREDIT de Alice tiene saldo almacenado cero y un depósito histórico de 300. La coexistencia no obliga a corregir ningún dato: la semilla solo registra parte de la historia. La condición de HAVING se evalúa después de agrupar; moverla a WHERE no compila como condición agregada.
 * 