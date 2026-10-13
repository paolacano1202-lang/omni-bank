/*
1- Evaluación de la Teoría:
El auditor tiene razón, según la 3NF, saldo-actual es un dato derivado y redundante, ya que auede
ya que puede calcularse algebraicamenteSumando los registros de la tabla Transacciones. 
Guardar atributos calculados contraviene la regla pura de omitir datos que puedan recalcularse. 
Sin embargo, no se trata de una dependencia transitiva clásica
dentro de la misma tabla, sino de un atributo derivado inter-tabla que en entornos aladémicos se 
elimina para evitar anomalías, pero que en la práctica requiere un análisis de costo computacional.
2: El problema del rendimiento (la justificación del mundo real):
En el mundo real, ejecutar un SUM() Sobre 250,000 transacciones en cada
consulta web satuvaría la CPU y la memoria de PostgreSQL 
elevando las latencias a varios segundos y Violando los ARRa de rendimiento.
Por ello, en banca empresarial usamos una desnormalización controlada manteniendo 
saldo-actual para obtener respuestas imediatas.



CORRECCIÓN: Viendo y comparando la demo con la clave del profesor, pude concluir que la solución de la demo es correcta y cumple con los requerimientos de la tarea. 
Pude aprender con este tema que la normalización es importante para evitar redundancia y mantener la integridad de los datos, 
pero también es crucial considerar el rendimiento en sistemas de alta demanda. La desnormalización controlada, como se hace con saldo_actual, 
puede ser una estrategia válida cuando se justifica por necesidades de rendimiento y se implementa con mecanismos que aseguren la consistencia de los datos.



El estudiante emitirá un dictamen arquitectónico comprensivo que reconoce que la columna saldo_actual es, en estricto rigor purista, un dato derivado (y por tanto infractor técnico de la 3NF canónica), pero argumentando sólidamente su conservación y permanencia obligada como una desnormalización controlada de grado empresarial motivada por necesidades extremas de rendimiento (OLTP).

Reference Solution
1. Respuesta al Auditor (Evaluación Teórica)
El auditor junior tiene la razón desde una perspectiva puramente académica y teórica de normalización. En una base de datos en 3NF estricta y absoluta, no se deberían almacenar valores derivados que puedan calcularse a partir de otros campos transaccionales (como sería un SUM(monto) del historial), dado que se añade riesgo de inconsistencia al duplicar o derivar estados sin dependencia funcional directa indivisible.

2. Dictamen de Arquitectura (La Realidad del Rendimiento Empresarial - OLTP)
En sistemas bancarios o comerciales de escala empresarial con volúmenes intensivos, calcular el saldo al vuelo (SUM(monto)) cada vez que un usuario consulta un ATM, hace un pago en un punto de venta (POS), o abre su aplicación bancaria generaría los siguientes problemas catastróficos:

Colapso del CPU e I/O de disco: Escanear e indexar 250,000 filas por consulta masiva (incluso en memoria con Índices) destruiría por completo el tiempo de respuesta del servidor relacional al escalar a millones de cuentas concurrentes (fallando los NFRs de latencia < 10ms).
Incapacidad de bloqueo rápido para salvedades concurrentes: Al transferir dinero es imperativo verificar inmediatamente en microsegundos que saldo_actual >= monto_a_retirar sin latencias de agregación previa que induzcan a condiciones de carrera transaccional o fraudes por desajustes de concurrencia temporal.
Solución y Mitigación Empresarial: Mantenemos saldo_actual como una desnormalización controlada. Para evitar que este saldo se desajuste en relación con las filas reales de Transacciones, delegamos al motor PostgreSQL la exigencia estricta de actualizar el saldo única y exclusivamente mediante Procedimientos Almacenados atómicos o Triggers transaccionales blindados bajo propiedades ACID con bloqueos de fila (FOR UPDATE), prohibiendo alteraciones manuales en la tabla o el cálculo errante en la capa del Frontend.
*/ 