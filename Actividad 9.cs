/*
SELECT
t. transaction - id
c. first - name || ' ' || c. last - name AS customer - name,
a. accant - number,
t. tx - type,
t. amant.
FROM core transactions t
INNER JOIN core. accounts a ON t. accants - id = a. accounts - id
ORDER BY t. tx - timestamp ASC, t. transaction - id ASC;   SELECT
c. email,
a. account - number,
a. balance
FROM core. Customers c
LEFT JOIN core. accant a
ON c. customers - id = a. customer - id
AND a. balance > 0;
 * 