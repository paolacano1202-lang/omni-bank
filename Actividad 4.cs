/*
1.- Diseña los tipos enumerados (ENUMs) del banco:
• Create type tipo - moneda AS ENUM ("USD", "EUR", "MXN")
• Create type tipo - cuenta AS ENUM ("Cheking", "Savings", "Credit")
• Create type tipo - trans AS ENUM ("deposit", "withdrawal", "transfer")   
2.- Corrección de tipos nativos y especificación relacional.  
DATO TIPO DE DATO   Cuenta - id (PK)UUID   Cliente - id (FK)UUID   tipo - Cuentatipo - Cuenta (ENUM)   monedatipo - moneda (ENUM)   SaldoNUMERIC (15, 2)   Fecha_actTIMESTAMPTZ   
 * 