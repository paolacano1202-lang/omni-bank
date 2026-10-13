/*
SELECT
C.email,
a.account-number,
UPPER (c.first-name, c.last-name, RIGHT (a.account-number, 4))
AS display-label, as status.
FROM accounts a
JOIN customers c ON a.customers-id = c.customers-id
ORDER BY a.account-number;
 * 
