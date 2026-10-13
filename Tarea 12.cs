/*
SELECT
account_id FROM accounts 
WHERE is_active = TRUE
AND NOT EXISTS ( SELECT 1 FROM events WHERE events_account_id = accounts_account_id);

SELECT account_id FROM accounts 
WHERE NOT EXISTS ( SELECT 1 FROM events WHERE events_account_id = accounts_account_id 
AND events_type = 'deposit');
 * 