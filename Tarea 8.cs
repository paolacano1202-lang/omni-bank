/*
-CÓDIGO SQL-
SELECT 
transaction_id,
amoubt,
tx_type,
tx_timestamp,
COALESCE 
description,
'Exclusión oportunamente detectada- sin motivo de pago'
) AS description_monitoreada
FROM core.transactions
WHERE
( amount >= 10000.00
AND tx_type IN ('withdrawal', 'transfer')
)
OR 
( description ILIKE '%CRRPTO%'
OR description ILIKE '%OFFSHORE%'
OR description ILIKE '%SHELL%'
OR description ILIKE '%CASINO%'
)
OR
(
NULLIF (TRIM (description), '') IS NULL
AND tx_type != 'deposit'
)
ORDER BY amount DESC;
 *
 * 