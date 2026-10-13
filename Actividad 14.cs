/*
SELECT e1.account-id, e1.event-id ev1, e2.event-id ev2
FROM events e1 JOIN events e2
ON e1.account-id = e2.account-id AND e1.event-id < e2.event-id
AND e2.created-at <= e1.created-at + INTERVAL '48 hours';   SELECT c.customers-name, t.account-type
FROM customers c CROSS JOIN (SELECT DISTINCT account-type
FROM accounts)
WHERE NOT EXISTS (
SELECT 1 FROM accounts a
WHERE a.customer-id = c.customer-id AND a.account-type =
t.account-type
); 
 * 