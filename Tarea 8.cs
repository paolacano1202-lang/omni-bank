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


CORRECCIÓN: Pude notar que la consulta SQL anterior, aunque funcional, no es óptima ni clara en su estructura. 
Se recomienda reescribirla para mejorar la legibilidad y eficiencia, utilizando COALESCE y NULLIF de manera más efectiva, 
así como simplificando las condiciones de filtrado.


SELECT transaction_id,account_id,tx_type,amount,
       COALESCE(NULLIF(TRIM(description),''),'SIN DESCRIPCIÓN') AS visible_description
FROM core.transactions
WHERE (tx_type IN ('TRANSFER','WITHDRAWAL') AND amount>=100)
   OR (tx_type='WITHDRAWAL' AND NULLIF(TRIM(description),'') IS NULL)
ORDER BY amount DESC,transaction_id;
Los dos TRANSFER superan el umbral didáctico. El retiro de 50 entra por descripción faltante. El depósito no cumple ninguno de los dos bloques. Una alerta exploratoria requiere revisión adicional y no constituye una acusación ni un reporte legal.
 *
 * 