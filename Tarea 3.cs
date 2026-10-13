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
*/ 