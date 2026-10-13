/*
SELECT account_id, account_type, owner_name
FROM accounts 
WHERE is_active = TRUE
AND NOT EXISTS ( SELECT 1 FROM events WHERE events_account_id = accounts_account_id
AND events_type = 'deposit');
 
SELECT COUNT (*) AS total_activas_sin_depositos
FROM accounts 
WHERE is_active = TRUE
AND NOT EXISTS ( SELECT 1 FROM events WHERE events_account_id = accounts_account_id
AND events_type = 'deposit');
 * 