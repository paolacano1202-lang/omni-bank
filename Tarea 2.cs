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

* 