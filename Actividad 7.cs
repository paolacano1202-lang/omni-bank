/*
insert into core. customers (id, first - name, last - name, email, phone, tax - id, date - of - birth)
('111 - 111 - 111', 'Jane', 'Doe', 'janedoe@gmail.com', '9995...', 'Tax - 100', '1985 - 04 - 12')
ON CONFLICT (email) DO NOTHING   insert into core. accounts (id, customer - id, account - number, account - type, balance, credit - limit)
('aaa - aaa - aaa - aaa', '111 - 111 - 111', 'ACT - 1001', 'CHECKING', '5000.00', '0.00')   insert into core. transactions (from - account - id, to - account - id, transaction - type, amount, status)
('aaa - aaa - aaa - aaa', 'bbb - bbb - bbb', 'TRANSFER', '150.00', 'COMPLETE')   UPDATE core. accounts
Where accant - number = 'ACET - 1001'
RETURNING accant - number, balance; 
 * 