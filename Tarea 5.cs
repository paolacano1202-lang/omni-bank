/*
DICTAMEN: R E C H A Z A D O
A la solicitud de implementar ON DELETE CASCADE, se mantendrá el ON DELETE STRCT

Habilitar ON DELETE CASCADE en un core bancario es un riesgo inaceptable. Un solo error humano,
script fallido o acceso no autorizado puede eliminar un gran volumen de datos de la base de datos. 
ON DELETE STRICT funciona como escudo de seguridad crítico para evaluar la pérdida accidental de datos
 * 