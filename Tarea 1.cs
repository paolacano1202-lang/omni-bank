//RNF1: La base de datos debe impedir a nivel de motor que el saldo de las cuentas quede en números
//negativos
//RNF2: La base de datos debe prohibir la eliminación física de cualquier registro de cliente una vez
//insertado. Si un cliente cierra su cuenta la base de datos solo debe permitir la baja lógica
//marcando al cliente como "inactivo" con fines de auditorías financieras
//RNF3: La base de datos debe registrar obligatoriamente la fecha y hora exacta de la última actualización
//cada vez que se modifique.



/*
CORRECCIÓN: Gracias a la corrección del profesor, pude aprender que los NFR (Non Functional Requirements) 
son requerimientos no funcionales que se aplican a la base de datos y no a la aplicación en sí. 
Por lo tanto, los NFR deben ser implementados a nivel de base de datos para garantizar la integridad y consistencia de los datos.



NFR1 (Consistencia Matemática): La base de datos debe impedir que las cuentas queden con saldos en números negativos.
NFR2 (Auditoría / Soft Delete): La base de datos debe impedir la eliminación física de un registro de cliente, y en su lugar debe poder marcarse como inactivo.
NFR3 (Timestamps): La base de datos debe registrar y actualizar automáticamente la fecha y hora exacta (updated_at) cada vez que el registro de una cuenta es modificado.



/*