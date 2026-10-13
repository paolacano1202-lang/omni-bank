/*
WITH sample-data AS (
SELECT Val FROM (VALUES (10000.0), (0.0), (0.0), (NOLO)) AS (val)
SELECT
AVG (val) AS AVG-ignoring-null,
COUNT (val) AS cant-ignoring-null,
ANG (COALESCE (val, 0)) AS aug-with-Coalesce,
COUNT (COALESCE (val, O)) AS count-with-cadesce FROM sample-data;
SELECT
a, account-id, a balance,
COUNT (t. transaction id) AS volumen-bruto-registrado
FROM accounts a
LEFT JOIN transactions + ON a account-id =+. account -id
WHERE aaccant-type = "CREDIT'
AND aris-active = TRUE
GROUP BY a account-id, a.balance
HAVING COUNT (t. transaction-id) = 0
OR COALESCE (SUM (t, amant), 0) >=300;
 * 