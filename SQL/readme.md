Instructions:

1- Run the script that creates the database: SQL\Banco.sql
2- Run the scripts that creates the tables, use the sequence number: SQL\Tabelas
3- Run the scripts that insert the data, use the sequence number: SQL\Dados 
4- Run the scripts that creates the procedures: SQL\Procedures
5- Run these two Procedures:
exec Sp_GetCategories
exec Sp_GetTradeCategories

Expected output:

Trade1 Value = 2000000.00 ClientSector = Private
Trade2 Value = 400000.00 ClientSector = Public
Trade3 Value = 500000.00 ClientSector = Public
Trade4 Value = 3000000.00 ClientSector = Public
tradeCategories = { 
HIGHRISK
LOWRISK
LOWRISK
MEDIUMRISK
}

Horário de conclusão: 2022-06-26T22:38:27.1584845-03:00