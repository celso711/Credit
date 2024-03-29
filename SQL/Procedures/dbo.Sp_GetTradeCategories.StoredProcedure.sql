USE [Credit]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetTradeCategories]    Script Date: 26/06/2022 22:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Sp_GetTradeCategories] 
AS

DECLARE @value  money
DECLARE @clientsector  NVARCHAR(50)

--DECLARE cursor_objects CURSOR FOR
DECLARE cursor_objects CURSOR FAST_FORWARD FOR

SELECT value, sector
FROM input
LEFT JOIN sector
ON input.clientsector = sector.ID;
    
-- Abrindo Cursor para leitura
OPEN cursor_objects
-- Lendo a próxima linha
print 'tradeCategories = { '
FETCH NEXT FROM cursor_objects INTO @value, @clientsector
-- Percorrendo linhas do cursor (enquanto houverem)
WHILE @@FETCH_STATUS = 0
BEGIN
    
	if(@value < 1000000 and @clientsector = 'Public')
	print 'LOWRISK'
	if (@value > 1000000 and @clientsector = 'Public')
	print 'MEDIUMRISK'
	IF (@value > 1000000 and @clientsector = 'Private')
	print 'HIGHRISK'
	
    FETCH NEXT FROM cursor_objects INTO @value, @clientsector
	
END
print '}'
-- Fechando Cursor para leitura
CLOSE cursor_objects

-- Desalocando o cursor
DEALLOCATE cursor_objects 
GO
