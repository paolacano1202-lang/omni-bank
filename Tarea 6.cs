/*
CAUSA DEL COLAPSO: Un comando DDL directo (ALTER TABLE) ejecutado en horas pico sobre 75 millones 
de registros solicitó bloqueo absoluto. Esto congleó lecturas y escrituras mientras escaneaba la tabla completa,
saturando la base de datos y provocando el error "504" en la app y cajeros.

-PASO 1- (NOT VALID)
Agrega la regla validando solo las transacciones nuevas entrantes sin escanear
el histórico, reduciendo el bloqueo a milisegundos.

-PASO 2- (VALIDATE CONSTRAINTS)
Valida las 75 millones de filas pasadas en segundo plano con un bloqueo leve que permite seguir operando con normalidad.


CORRECCIÓN: Pude aprender que la solución definitiva y profesional para entornos de altísima concurrencia relacional es 
la aplicación en dos fases de la cláusula NOT VALID y la posterior orden independiente VALIDATE CONSTRAINT, 
evitando AccessExclusiveLock y permitiendo la continuidad operativa del banco.




El estudiante entregará un reporte forense post-mortem comprensivo en el que expone la causa raíz del congelamiento transaccional de 14 minutos en OmniBank, diagnosticando la intrusión mortífera provocada por el bloqueo computacional AccessExclusiveLock, e ilustrando con código real y modular la solución definitiva e industrializable de aplicación en dos fases para entornos de altísima concurrencia relacional (NOT VALID y la posterior orden independiente VALIDATE CONSTRAINT).

Reference Solution
1. Diagnóstico de Causa Raíz Computacional (AccessExclusiveLock)
El incidente inaceptable en producción fue desencadenado directamente por un desconocimiento operativo y del motor en transiciones en caliente del DBA senior. Cuando se ejecuta un mandato directo ADD CONSTRAINT ... CHECK (...) sobre una entidad que alberga ya transaccionadas en disco duro en vivacidad continua 75 millones de filas:

PostgreSQL se ve obligado irremediable a paralizar y detener las operaciones en esa tabla para garantizar una fotografía y certidumbre relacional intacta de los datos en tanto procede al escaneo secuencial e indexado computacional, revisando renglón a renglón todo su gigantesco volumen (las 75 millones de celdas transaccionales) para constatar que ninguna anterior al mediodía infrinja el largo del texto requerido ni en un solo carácter.
Para hacer eso en un motor ácido consistente, adquirió irrebatiblemente un bloqueo de nivel absoluto del sistema: un AccessExclusiveLock.
Este es el único bloqueo y de máxima gravedad en PostgreSQL que le cierra tajantemente las puertas de cara tanto a consultas entrantes de lectura (SELECT) como a transacciones operativas entrantes de modificación o inserción bancarias (INSERT / UPDATE). Durante 14 largos minutos todo intento computacional por acceder fue puesto a la fila o cola escurrido por agotamiento transaccional o cortado sistemáticamente al transcurrir el timeout de conexión en los microservicios externos de banca web y móvil (Error 504 Gateway Timeout).
2. Solución Empresarial en Dos Etapas para Despliegues Sin Interrupción (Zero-Downtime Migration)
Para blindar nuestras tablas en entornos intensivos productivos y dar carpetazo definitivo a esta clase de cataclismos operativos, establecemos el siguiente estándar procedimental e industrial en dos tiempos imperativo para el equipo de OmniBank:

-- ETAPA 1: Inyección transaccional en caliente sin escaneo retrógrado de bloqueo inquebrantable
-- Le informamos explícitamente a PostgreSQL la cláusula "NOT VALID"
ALTER TABLE core.transactions 
    ADD CONSTRAINT chk_transactions_description_valid 
    CHECK (LENGTH(TRIM(description)) >= 5) NOT VALID;
-- > ¡TERMINADO EN MENOS DE 10 MILISEGUNDOS!
-- El motor inserta pacíficamente la nueva regla en los metadatos del catálogo en un parpadeo de tiempo, 
-- aplicando instantáneamente la protección sobre CUALQUIER transaccionalidad NUEVA QUE LLEGUE EN EL FUTURO (INSERT/UPDATE)
-- sin molestarse, escanear ni estorbar a las 75 millones de filas antiguas consolidadas y en sosiego en el disco.
-- ETAPA 2: Validación Asíncrona Pasiva sin Caídas de Servicio ni bloqueos masivos
-- En una sesión o mandato posterior (ideal para ventanas de bajamar operante, o inmediatamente después de la primera)
ALTER TABLE core.transactions 
    VALIDATE CONSTRAINT chk_transactions_description_valid;
-- > ¡CERO CAÍDA TRANSACCIONAL PARA LOS CLIENTES NI CONGELAMIENTOS EN BANCA WEB!
-- Al ejecutarse en su segunda fase con VALIDATE CONSTRAINT, PostgreSQL efectúa paulatinamente en segundo plano
-- la inspección y escaneo y fiscalización gradual del histórico de los 75 millones de renglones anticuados.
-- En este ciclo especial y genial de PostgreSQL, el motor SE ABSTIENE RÍGIDAMENTE Y RENUNCIA al terrible bloqueo AccessExclusiveLock;
-- adopta únicamente un bloqueo muchísimo más ligero y amigable (ShareUpdateExclusiveLock), que PERMITE Y CONSENTIDA EN CONTINUIDAD
-- Y EN REAL TIME LA EJECUCIÓN PACÍFICA DE SELECTS E INSERCIONES operativas de los millones de clientes y del mundo entero concurrente sin inyectar latencias ni cortes transaccionales al banco.

 * 