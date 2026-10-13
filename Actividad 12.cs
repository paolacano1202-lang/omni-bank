/*
SELECT c.event-id, e.account-id, e.amount
FROM events e
WHERE e.amount > (
SELECT AVG(e2.amount)
FROM events e2
WHERE e2.account-id = e.account-id
);   SELECT account-id, AVG (amount) AS avg-amount
FROM events
GROUP BY account-id;   SELECT account-number, is-active
FROM accounts a
WHERE NOT EXISTS (
SELECT 1
FROM events e
WHERE e.account-id = a.account-id
)
ORDER BY account-number;
 * 