/*
 1. create domain monto_financiero AS NUMERIC (15,2)
check (VALUE > =0.00);

create domain texto_obligatorio AS VARCHAR (100)
check (VALUE <> '' AND LENGTH (TRIM(VALUE)) > 0);

2. 
>saldo_cuenta
>limite_credito
>monto_retiro


CORRECCIÓN: En la demo, pude notar que los dominios bancarios de OmniBank se definen correctamente y cumplen con los requerimientos de la tarea. Lo que pude aprender es
que los dominios son una herramienta poderosa en PostgreSQL para garantizar la integridad de los datos y aplicar restricciones específicas a los tipos de datos. 
Al crear dominios personalizados, se puede asegurar que los valores ingresados cumplan con ciertas condiciones, como ser no negativos para montos financieros o 
no estar vacíos para textos obligatorios. Esto ayuda a mantener la consistencia y calidad de los datos en la base de datos.


El estudiante confeccionará sin errores sintácticos de PostgreSQL dos scripts independientes para inicializar los DOMAINs empresariales ordenados (monto_financiero y texto_obligatorio) garantizando las comprobaciones algebraicas y de limpieza textual por defecto mediante cláusulas de constraint (CHECK).

Reference Solution
1. Script SQL para Dominios Bancarios de OmniBank
-- Declaración del Dominio para blindaje monetario universal
CREATE DOMAIN monto_financiero AS NUMERIC(15, 2)
    CHECK (VALUE >= 0.00);

-- Declaración del Dominio para textos que repelen espacios en blanco o cadenas vacías ilegales
CREATE DOMAIN texto_obligatorio AS VARCHAR(100)
    CHECK (VALUE <> '' AND LENGTH(TRIM(VALUE)) > 0);
2. Identificación Transversal en Columnas
El Dominio monto_financiero impactará positivamente y reemplazará al tipo nativo en al menos estas 3 columnas decisivas de nuestra arquitectura bancaria:

La columna saldo_actual dentro de la tabla Cuentas.
La columna limite_credito dentro de la tabla Cuentas.
La columna monto_tx dentro de la tabla Transacciones.
 * 