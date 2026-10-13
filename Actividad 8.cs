/*
Reporte 1:
SELECT
account - number,
account - type,
balance
FROM core. accounts
WHERE (balance >= 1000.00 OR account - type = 'SAVINGS')
ORDER BY balance DESC
LIMIT 2;   Reporte 2:
SELECT
First - name,
last - name,
email
FROM core. Customers.
WHERE email ILIKE '%@email.com';   Reporte 3:
transaction - id,
account - id,
amount,
tx - type,
Created - at,
COALESCE (description,
'Cobro institucional o comisión - sin receptor'
) AS description - visible
FROM core. transactions.
WHERE description IS NULL; 


CORRECCIÓN: Pude aprender que la solución definitiva y profesional para entornos de altísima concurrencia relacional es la 
aplicación en dos fases de la cláusula NOT VALID y la posterior orden independiente VALIDATE CONSTRAINT, evitando AccessExclusiveLock y
permitiendo la continuidad operativa del banco.


El estudiante entregará en formato de guion SQL (query_01_core_retrieval.sql) tres reportes analíticos para OmniBank sin incurrir al anti-patrón de comodín (SELECT *), aplicando filtros condicionales combinados, búsquedas difusivas sin sensibilidad con ILIKE y resolviendo la Lógica Tri-Valuada en el tratamiento de vacíos interbancarios sustituyendo el ilegal = NULL por IS NULL y proyectando confirmaciones pulidas con COALESCE.

Reference Solution
1. Guion SQL de Extracción Gerencial (query_01_core_retrieval.sql)
-- REPORTE 1: Extracción Quirúrgica de Cuentas Prioritarias en OmniBank
-- Excluye celdas ruidosas (UUIDs, created_at, etc.) mediante proyección explícita
SELECT 
    account_number,
    account_type,
    balance
FROM core.accounts
WHERE (balance >= 1000.00 OR account_type = 'SAVINGS')
ORDER BY balance DESC
LIMIT 2;

-- REPORTE 2: Búsqueda Insensible por Patrones en Clientes Bancarios
-- Atrapa por igual '@email.com', '@EMAIL.COM' sin alterar el motor
SELECT 
    first_name,
    last_name,
    email
FROM core.customers
WHERE email ILIKE '%@email.com';

-- REPORTE 3: Resolución de la Lógica Tri-Valuada y Salvaguarda con COALESCE
-- Corrige el fallo del analista interino (= NULL -> IS NULL) y purga vacíos
SELECT 
    account_id,
    amount,
    tx_type,
    COALESCE(description, 'COBRO INSTITUCIONAL O COMISIÓN - SIN RECEPTOR') AS descripcion_visible
FROM core.transactions
WHERE description IS NULL AND tx_type = 'WITHDRAWAL';
 * 