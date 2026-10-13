/*
WITH account_metrics AS (
SELECT
a.account_id,
a.currency,
COALESCE (SUM (t.amount), 0) AS balance,
COUNT (t.transaction_id) AS num_transactions
FROM accounts a
LEFT JOIN transactions t
ON a.account_id = t.account_id
GROUP BY a.account_id, a.currency
)
SELECT
currency,
COUNT (account_id) AS total_accounts,
SUM (total_amount) AS gross_volume,
ROUND (AVG (balance), 2) AS avg_balance,
ROUND (AVG (num_transactions), 2) AS avg_transactions
FROM account_metrics
GROUP BY currency;
 * 