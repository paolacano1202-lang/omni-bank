/*
Reporte 1:
SELECT
account - number,
account - type,
balance
FROM core. accounts
WHERE (balance >= 1000.00 OR account - type = 'SAVINGS')
ORDER BY balance DESC
LIMIT 2;   Reporte 2:
SELECT
First - name,
last - name,
email
FROM core. Customers.
WHERE email ILIKE '%@email.com';   Reporte 3:
transaction - id,
account - id,
amount,
tx - type,
Created - at,
COALESCE (description,
'Cobro institucional o comisión - sin receptor'
) AS description - visible
FROM core. transactions.
WHERE description IS NULL; 
 * 