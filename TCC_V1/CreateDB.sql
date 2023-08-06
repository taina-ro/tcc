-- Finalidade: Script para criação do banco de dados Esquematicos
-- Autor: Taina Ribeiro

USE tempdb;
GO
set nocount on 
DECLARE @SQL nvarchar(1000);
IF EXISTS (SELECT 1 FROM sys.databases WHERE [name] = N'Dimensionamento')
BEGIN
    SET @SQL = N'USE [Dimensionamento];

                 ALTER DATABASE [Dimensionamento] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                 USE [tempdb];

                 DROP DATABASE Dimensionamento';
    EXEC (@SQL);
END;
GO

CREATE DATABASE [Dimensionamento] 
GO