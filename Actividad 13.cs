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
 * 