/*
 1. create domain monto_financiero AS NUMERIC (15,2)
check (VALUE > =0.00);

create domain texto_obligatorio AS VARCHAR (100)
check (VALUE <> '' AND LENGTH (TRIM(VALUE)) > 0);

2. 
>saldo_cuenta
>limite_credito
>monto_retiro
 * 