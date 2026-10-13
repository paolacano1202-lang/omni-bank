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
 * 