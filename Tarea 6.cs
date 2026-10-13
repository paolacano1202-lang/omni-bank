/*
CAUSA DEL COLAPSO: Un comando DDL directo (ALTER TABLE) ejecutado en horas pico sobre 75 millones 
de registros solicitó bloqueo absoluto. Esto congleó lecturas y escrituras mientras escaneaba la tabla completa,
saturando la base de datos y provocando el error "504" en la app y cajeros.

-PASO 1- (NOT VALID)
Agrega la regla validando solo las transacciones nuevas entrantes sin escanear
el histórico, reduciendo el bloqueo a milisegundos.

-PASO 2- (VALIDATE CONSTRAINTS)
Valida las 75 millones de filas pasadas en segundo plano con un bloqueo leve que permite seguir operando con normalidad.
 * 