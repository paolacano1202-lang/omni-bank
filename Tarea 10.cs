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



CORRECCIÓN: Gracias a la corrección del profesor pude aprender que el reporte de la solución crediticia es un ejemplo de la cláusula WITH, 
que permite crear una tabla temporal con datos de prueba para el reporte.


La muestra arroja 3333.33 si se ignora NULL y 2500.00 si se convierte a cero. ACCT-3001 aparece con balance 0 y volumen bruto 300.

Reference Solution
WITH sample(x) AS (VALUES (NULL::numeric),(10000::numeric),(0::numeric),(0::numeric))
SELECT ROUND(AVG(x),2) AS ignores_null,
       ROUND(AVG(COALESCE(x,0)),2) AS treats_null_as_zero
FROM sample;

SELECT c.email,a.account_number,a.balance AS stored_balance,
       COUNT(t.transaction_id) AS movement_count,
       COALESCE(SUM(t.amount),0) AS recorded_gross_volume
FROM core.customers c JOIN core.accounts a USING (customer_id)
LEFT JOIN core.transactions t USING (account_id)
WHERE a.account_type='CREDIT' AND a.is_active
GROUP BY c.customer_id,c.email,a.account_id,a.account_number,a.balance
HAVING COALESCE(SUM(t.amount),0)>=300 OR COUNT(t.transaction_id)=0
ORDER BY recorded_gross_volume DESC;
Lectura de la solución: La revisión crediticia necesita un ejemplo en el que AVG ignore un NULL de forma visible, además de una fila de prueba para CREDIT. El objetivo es explicar el denominador real de AVG y enlazarlo con el reporte agregado construido en la actividad, no inventar un límite crediticio que el esquema no guarda.
 * 