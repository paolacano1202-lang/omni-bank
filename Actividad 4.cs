/*
1.- Diseña los tipos enumerados (ENUMs) del banco:
• Create type tipo - moneda AS ENUM ("USD", "EUR", "MXN")
• Create type tipo - cuenta AS ENUM ("Cheking", "Savings", "Credit")
• Create type tipo - trans AS ENUM ("deposit", "withdrawal", "transfer")   
2.- Corrección de tipos nativos y especificación relacional.  
DATO TIPO DE DATO   Cuenta - id (PK)UUID   Cliente - id (FK)UUID   tipo - Cuentatipo - Cuenta (ENUM)   monedatipo - moneda (ENUM)   SaldoNUMERIC (15, 2)   Fecha_actTIESTAMPTZ   


CORRECCIÓN: Pude notar que el borrador del desarrollador contenía errores en la especificación de tipos de datos para los atributos críticos de las 
tablas relacionales. Se requería que pudiera corregir los tipos de datos para garantizar la integridad y precisión de la información financiera. 
A continuación, se presentan las correcciones realizadas:


El estudiante compilará con éxito en su cliente local las tres declaraciones en firme de tipos enumerados (ENUMs) con sintaxis pura de PostgreSQL y corregirá el borrador incompleto del desarrollador, asignando NUMERIC, TIMESTAMPTZ y UUID en sus tablas relacionales.

Reference Solution
1. Creación de Tipos Enumerados Bancarios (ENUMs)
-- Monedas admitidas
CREATE TYPE core.tipo_moneda AS ENUM ('USD', 'EUR', 'MXN', 'GBP');

-- Tipos de cuentas de clientes
CREATE TYPE core.tipo_cuenta AS ENUM ('CHECKING', 'SAVINGS', 'CREDIT');

-- Categorizaciones transaccionales permitidas
CREATE TYPE core.tipo_transaccion AS ENUM ('DEPOSIT', 'WITHDRAWAL', 'TRANSFER');
(Nota: Incluir o no el esquema core. delante de los tipos es opcional en esta etapa inicial en tanto sean creados de forma consistente).

2. Especificación Relacional Corregida (Diccionario y Campos)
Tabla Cuentas (Corrección de atributos críticos):

saldo_actual: NUMERIC(15, 2) (Sustituye por completo al erróneo e impreciso FLOAT(8) con 15 dígitos de longitud en total y dos decimales bancarios inviolables y exactos).
updated_at: TIMESTAMPTZ (Provee protección en timestamps preservados bajo Tiempo Universal UTC).
Tipo de Llaves para Clientes, Cuentas y Transacciones:

Todo atributo utilizado en función de Llaves Primarias (PK) y Llaves Foráneas (FK) portará inexorablemente el tipo nativo UUID de 128-bits. Su uso anula ataques de adivinanza o enumeración secuencial en los APIs de consulta del banco e incrementa el aislamiento distribuido.

 * 