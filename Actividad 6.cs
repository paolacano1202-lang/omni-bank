/*
CREATE TYPE core. loan - status - enum AS ENUM ('Active', 'PAID', 'DEFAULTED', 'CANCELLED');
BEGIN;
ALTER TABLE core. customers
ADD COLUMN credit - score INTEGER,
ADD CONSTRAINT chk - customers - credit - score - range
check (credit - score BETWEEN 300 AND 850);
ALTER TABLE core. accounts
ADD COLUMN iban VARCHAR (34) NULL,
ADD CONSTRAINT uq - accounts - iban
UNIQUE (iban);
ALTER TABLE core. loans
ALTER COLUMN status TYPE core. loanstatus - enum
USING status:: core. loan - status - enum;
Commit;


CORRECCIÓN: Gracias a la aplicación en dos fases de la cláusula NOT VALID y la posterior orden independiente VALIDATE CONSTRAINT,
se logró evitar el bloqueo AccessExclusiveLock y permitir la continuidad operativa del banco durante la migración de las tablas en vivo. Aprendí que la solución
definitiva y profesional para entornos de altísima concurrencia relacional es aplicar estas técnicas de manera cuidadosa y planificada, 
asegurando que las transacciones nuevas se validen sin afectar el histórico, y luego validar las restricciones en segundo plano.


Expected Result
El estudiante confeccionará con impecable sintaxis un script de migración DDL (migration_01_core_evolution.sql) que integra dentro de un bloque transaccional indivisible (BEGIN; ... COMMIT;) sentencias precisas de ALTER TABLE para modificar las tablas en vivo customers, accounts, y loans en el esquema de OmniBank.

Reference Solution
1. Script DDL Evolutivo Completo (migration_01_core_evolution.sql)
-- 1. Compilación del nuevo Tipo Enumerado en PostgreSQL para el ciclo de vida crediticio
CREATE TYPE core.loan_status_enum AS ENUM ('ACTIVE', 'PAID', 'DEFAULTED', 'CANCELLED');

-- 2. Inicio innegociable de transaccionalidad DDL en PostgreSQL
BEGIN;

-- Transformación 1: Añadir métrica de puntuación crediticia a los titulares bancarios con su constraint en duro
ALTER TABLE core.customers 
    ADD COLUMN credit_score INTEGER NULL;

ALTER TABLE core.customers 
    ADD CONSTRAINT chk_customers_credit_score_range 
    CHECK (credit_score BETWEEN 300 AND 850);

-- Transformación 2: Estandarización europea de identificación de cuentas bancarias y unicidad
ALTER TABLE core.accounts 
    ADD COLUMN iban VARCHAR(34) NULL;

ALTER TABLE core.accounts 
    ADD CONSTRAINT uq_accounts_iban UNIQUE (iban);

-- Transformación 3: Casteo estructural de columna de texto libre de préstamos a nuestro riguroso Enum catalogado
ALTER TABLE core.loans 
    ALTER COLUMN status DROP DEFAULT,
    ALTER COLUMN status TYPE core.loan_status_enum USING status::core.loan_status_enum,
    ALTER COLUMN status SET DEFAULT 'ACTIVE'::core.loan_status_enum;

-- Si ningún solo paso presentó divergencias en terminal o fallos operantes de conversión sintáctica:
COMMIT;
 * 