/*
SELECT COUNT(*) AS total_cartesian_product
FROM transactions
CROSS JOIN accounts
CROSS JOIN customers;
 SELECT 
c.email,
a.account_id,
t.type,
t.amount,
t.transaction_date
FROM transactions t
INNER JOIN accounts a
ON t.account_id = a.account_id
WHERE c.is.active = true
AND t.amount > 100
ORDER BY t.transaction_date ASC, t.transaction_id ASC;
 * 