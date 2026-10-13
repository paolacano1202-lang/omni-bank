/*
DICTAMEN: R E C H A Z A D O
A la solicitud de implementar ON DELETE CASCADE, se mantendrá el ON DELETE STRCT

Habilitar ON DELETE CASCADE en un core bancario es un riesgo inaceptable. Un solo error humano,
script fallido o acceso no autorizado puede eliminar un gran volumen de datos de la base de datos. 
ON DELETE STRICT funciona como escudo de seguridad crítico para evaluar la pérdida accidental de datos


CORRECCIÓN: Logré notar que la instrucción de baja lógica (is_active) es la forma correcta de manejar la eliminación de registros en un entorno bancario. 
Esto asegura que los datos históricos se mantengan intactos para auditorías y cumplimiento regulatorio, mientras que los registros inactivos no interfieren 
con las operaciones actuales. La corrección de la instrucción de baja lógica es esencial para mantener la integridad de los datos y cumplir con las normativas 
legales y fiscales.



El estudiante confeccionará un dictamen ejecutivo contundente rechazando de plano el peligroso pedimento de implementar ON DELETE CASCADE en las relaciones transaccionales del banco, sosteniéndose en la gravedad de la pérdida irreversible de registros fiscales contables e instruyendo a los equipos en el uso obligado y estandarizado de la Baja Lógica (is_active).

Reference Solution
1. El Riesgo Catastrófico en Producción (ON DELETE CASCADE)
El argumento presentado por el equipo de testing para agilizar limpiezas automatizadas incurre en un gravísimo vicio metodológico: nunca se debe relajar la seguridad o integridad de un modelo productivo para complacer la pereza de las pruebas unitarias automáticas (donde muy bien pueden limpiar el entorno en orden inverso o usar sentencias TRUNCATE ... CASCADE aisladas al ambiente temporal efímero).
Habilitar una restricción ON DELETE CASCADE sobre core.customers o core.accounts convertiría cualquier descuido de un operador administrativo del sistema o intento malintencionado en producción en un arma destructiva masiva que fulmina inexorablemente sin previa confirmación de seguridad en una sola fracción de segundo cientos de miles de transferencias, créditos activos y cobros bancarios vinculados transaccionalmente al sujeto o entidad en disco.

2. Obligación de Auditoría Contable y Rastro Legal Fiscal
En el ámbito financiero profesional y bajo leyes mundiales de cumplimiento tributario e inversión auditada (como las normas Sarbanes-Oxley [SOX], regulaciones antiblanqueo [AML], o el secreto fiscal bancario), un registro histórico de transacción y movimiento patrimonial es un documento legal civil inviolable, inalterable y perpetuo por mandato público legal. Borrar ciegamente esas filas del motor (DELETE FROM core.transactions) ante la baja de una persona rompe el balance de comprobación general del libro contable mayor de OmniBank, derivando en sanciones multimillonarias, auditorías desaprobadas e intervenciones de organismos reguladores contra el banco al destruir irremplazablemente la evidencia real transaccional monetaria del sistema.

3. Instrucciones sobre el Estándar Empresarial: La Baja Lógica
Para asegurar armonía en los procesos operacionales de nuestro banco de nivel mundial, instruiremos la adopción irrestricta de los siguientes pasos cuando una cuenta o usuario sea removida de las actividades operacionales del mercado:

Jamás se emitirá una orden DELETE en caliente sobre tablas maestras transaccionales ni personales en nóminas comerciales. El borrado físico queda terminantemente bloqueado y proscrito para las aplicaciones clientes, resguardado tras nuestro muro de hierro ON DELETE RESTRICT programado dentro en los constraints relacionales del DDL.
Se implementa el proceso técnico de Baja Lógica: la inactivación oficial del usuario o el congelamiento final del cobro se ejecuta alterando y actualizando pacíficamente las banderas booleanas no funcionales proyectadas especialmente en nuestro esquema DDL en los pasados talleres:
-- Instrucción estándar legítima ante un cierre bancario de un cliente comercial:
UPDATE core.customers SET is_active = false WHERE customer_id = 'c13c7f99-...';

-- Las cuentas asociadas cesan actividad cambiándose equivalentemente en la base:
UPDATE core.accounts SET is_active = false, updated_at = CURRENT_TIMESTAMP WHERE customer_id = 'c13c7f99-...';
Al conservarse las celdas en el disco duro transaccional resguardo tras is_active = false, ni un solo reporte histórico analítico contable sufrirá pérdidas computacionales transaccionales ante inspecciones tributario-financieras.
 * 