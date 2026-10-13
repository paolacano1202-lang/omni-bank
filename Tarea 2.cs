/*
 CLIENTES:
id_cliente (UUID)
nombre (VARCHAR)
email (VARCHAR)

CUENTAS:
id_cuenta (UUID)
id_cliente (FK)
tipo_cuenta (VARCHAR)
saldo (DECIMAL)

TRANSACCIONES:
id_transaccion (UUID)
id_cuenta_origen (UUID)
id_cuenta_destino (UUID)
monto (DECIMAL)

CLIENTE |---------------< CUENTAS
CUENTA  |---------------< TRANSACCIONES >--------------> CUENTAS


CORRECCIÓN: Está actividad requiere que se realicen cambios en el ERD base para reflejar los tipos de datos correctos y las 
restricciones necesarias. A continuación, se detallan los cambios requeridos por el profesor:



El ERD base de la actividad debe haber sido actualizado para incluir los tipos de datos en las llaves (UUID en lugar de enteros), constraints anotados (ej. saldos no negativos, UNIQUE para el tax_id), y las nuevas columnas extraídas de los NFRs del Día 1.

Reference Solution
[Clientes] 1 ------------ N [Cuentas]
- cliente_id (PK, UUID)       - cuenta_id (PK, UUID)
- nombre                      - cliente_id (FK, UUID)
- correo                      - moneda
- telefono                    - tipo_cuenta
- fecha_nacimiento            - saldo_actual (CHECK: >= 0)
- tax_id (UNIQUE)             - limite_credito
- is_active (Soft Delete)     - updated_at (Timestamp NFR)

                   (Cuenta Origen)
[Cuentas] 1 ------------------------- N [Transacciones]
                                          - transaccion_id (PK, UUID)
                   (Cuenta Destino)       - from_account (FK, UUID -> Cuentas)
[Cuentas] 1 ------------------------- N   - to_account (FK, UUID -> Cuentas)
                                          - monto
                                          - tipo_transaccion
                                          - fecha_completada
* 