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


CORRECCIÓN: Gracias a esta tarea pude aprender que la cláusula EXISTS se usa para verificar la existencia de un registro en una tabla. 
Lo que me ayuda a resolver el problema de identificar cuentas sin movimientos y movimientos superiores al promedio de su propia cuenta.


Un movimiento supera el promedio de su cuenta. ACCT-1002 y ACCT-3002 carecen de movimientos, aunque solo una está activa.

Reference Solution
SELECT t_ext.transaction_id,t_ext.account_id,t_ext.amount,
       (SELECT ROUND(AVG(t_int.amount),2)
        FROM core.transactions t_int
        WHERE t_int.account_id=t_ext.account_id) AS account_average
FROM core.transactions t_ext
WHERE t_ext.amount>(
  SELECT AVG(t_int.amount)
  FROM core.transactions t_int
  WHERE t_int.account_id=t_ext.account_id
)
ORDER BY t_ext.amount DESC;
SELECT account_id,ROUND(AVG(amount),2) AS account_average
FROM core.transactions GROUP BY account_id ORDER BY account_id;

SELECT a.account_number,a.is_active,a.balance
FROM core.accounts a
WHERE NOT EXISTS (
  SELECT 1 FROM core.transactions t WHERE t.account_id=a.account_id
)
ORDER BY a.account_number;
Lectura de la solución: El equipo de revisión busca movimientos superiores al comportamiento habitual de su propia cuenta y cuentas que nunca han registrado eventos. Comparar un movimiento de John con el promedio global de todas las cuentas respondería otra pregunta. La ausencia de eventos también debe distinguirse del estado is_active para no emitir una alerta administrativa falsa.
 * 