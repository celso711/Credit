USE [Credit]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetCategories]    Script Date: 26/06/2022 22:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Sp_GetCategories] 
AS


DECLARE @id int
DECLARE @value  money
DECLARE @clientsector  NVARCHAR(50)

--DECLARE cursor_objects CURSOR FOR
DECLARE cursor_objects CURSOR FAST_FORWARD FOR

SELECT value, sector, input.id
FROM input
LEFT JOIN sector
ON input.clientsector = sector.ID;
    
-- Abrindo Cursor para leitura
OPEN cursor_objects
-- Lendo a próxima linha
FETCH NEXT FROM cursor_objects INTO @value, @clientsector, @id
-- Percorrendo linhas do cursor (enquanto houverem)
WHILE @@FETCH_STATUS = 0
BEGIN
    
	print 'Trade' +  CAST(@id AS VARCHAR(1000)) + ' Value = ' + CAST(@value AS VARCHAR(MAX)) + ' ClientSector = ' + CAST(@clientsector AS VARCHAR(MAX))
    FETCH NEXT FROM cursor_objects INTO @value, @clientsector, @id

END

-- Fechando Cursor para leitura
CLOSE cursor_objects

-- Desalocando o cursor
DEALLOCATE cursor_objects 
GO
