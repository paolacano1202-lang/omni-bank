/*
-SOLUCIÓN RECOMENDADA-
>Redactar un análisis crítico que prohiba el read-before-write y explique sus fallas en rendimiento.
>Escribir la sentencia SQL con INSERT INTO core customers...
ON CONFLICT (email) DO UPDATE SET... usando la tabla EXCLUDED para actualizar únicamente first_name y last_name.
y phone_number sin alterar el ID ni created_at.
>Añadir RETURNING al final del comando para devolver customer_id y email al microservicio en una sola operación.
 * 