//RNF1: La base de datos debe impedir a nivel de motor que el saldo de las cuentas quede en números
//negativos
//RNF2: La base de datos debe prohibir la eliminación física de cualquier registro de cliente una vez
//insertado. Si un cliente cierra su cuenta la base de datos solo debe permitir la baja lógica
//marcando al cliente como "inactivo" con fines de auditorías financieras
//RNF3: La base de datos debe registrar obligatoriamente la fecha y hora exacta de la última actualización
//cada vez que se modifique.