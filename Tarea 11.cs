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
/*