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
 * 