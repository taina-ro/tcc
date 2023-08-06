-- Finalidade: Script para popular as tabelas do banco de dados Esquematicos
-- Autor: Danilo Silva
-- Criado em: 08/11/2021
-- Modificado em:
-- 08/11/2021 - Inicial
--
set nocount on 
set xact_abort on 
Use Dimensionamento

-- ******************************************************
-- Deleta registros existentes
-- ******************************************************

if exists (select * from sys.tables where name = 'LocalXCircuito')
	delete from dbo.LocalXCircuito
go

if exists (select * from sys.tables where name = 'Segmento')
	delete from dbo.Segmento
go
if exists (select * from sys.tables where name = 'Carga')
	delete from dbo.Carga
go
if exists (select * from sys.tables where name = 'Ponto')
	delete from dbo.Ponto
go
if exists (select * from sys.tables where name = 'Local')
	delete from dbo.[Local]
go
if exists (select * from sys.tables where name = 'TipoDeLocal')
	delete from dbo.TipoDeLocal
go
if exists (select * from sys.tables where name = 'TipoDePonto')
	delete from dbo.TipoDePonto
go
if exists (select * from sys.tables where name = 'Circuito')
	delete from dbo.Circuito
go
if exists (select * from sys.tables where name = 'TipoDeCarga')
	delete from dbo.TipoDeCarga
go
if exists (select * from sys.tables where name = 'TipoDeEletroduto')
	delete from dbo.TipoDeEletroduto
go
if exists (select * from sys.tables where name = 'DR')
	delete from dbo.DR
go
if exists (select * from sys.tables where name = 'Residencia')
	delete from dbo.Residencia
go

-- ******************************************************    
-- Popula tabela Residencia
-- ******************************************************

USE [Dimensionamento]
GO

INSERT INTO [dbo].[Residencia]([Residencia_ID],[Residencia_Area],[Residencia_Perimetro]
           ,[Residencia_NumFases],[Residencia_NumPav],[Residencia_PadraoEnergia],[Residencia_CxDist]
           ,[Residencia_Descr])
     VALUES
           (1           ,50           ,35           ,1           ,1           ,null           ,null           ,'Projeto Inicial')
GO
Select * from Residencia
GO
-- ******************************************************    
-- Popula tabela DR
-- ******************************************************
USE [Dimensionamento]
GO
INSERT INTO [dbo].[DR]
           ([DR_ID],[DR_CorrenteNom],[DR_Descr])
     VALUES
           (10,10 ,'IDR 10A'),
		   (15,15 ,'IDR 15A'),
		   (20,20 ,'IDR 20A'),
		   (25,25 ,'IDR 25A'),
		   (40,40 ,'IDR 40A')

GO
-- ******************************************************    
-- Popula tabela Circuito
-- ******************************************************

INSERT INTO [dbo].[Circuito]
           ([Circuito_ID],[Circuito_Tensao],[Circuito_Descr],[DR_ID],[Residencia_ID],[Circuito_NumCondutores],[Circuito_SecaoFase],[Circuito_SecaoProtecao])
     VALUES
           (1 ,127,'Ilum. Social',25,1,4, 1.5, 1.5),
		   (2 ,127,'Ilum. Servico',25,1,4, 1.5, 1.5),
		   (3 ,127,'PTUG1',25,1,4, 2.5, 2.5),
		   (4 ,127,'PTUG2',25,1,4, 2.5, 2.5),
		   (5 ,127,'PTUG3',25,1,4, 2.5, 2.5),
		   (6 ,127,'PTUG4',25,1,4, 2.5, 2.5),
		   (7 ,127,'PTUG5',25,1,4, 2.5, 2.5),
		   (8 ,127,'PTUG & PTUE',25,1,4, 2.5, 2.5),
		   (9 ,127,'PTUG6',25,1,4, 2.5, 2.5),
		   (10 ,127,'PTUE',25,1,4, 2.5, 2.5),
		   (11 ,220,'Chuveiro',40,1,4, 4, 4),
		   (12 ,220,'Torneira',25,1,4, 6, 6)
		
GO
--Select * from Circuito
--GO


-- ******************************************************    
-- Popula tabela TipoDeLocal
-- ******************************************************

INSERT INTO [dbo].[TipoDeLocal]
           ([TipoDeLocal_ID] ,[TipoDeLocal_Descr])
     VALUES
           (1,'Sala'),
		   (2,'Dormitorio'),
		   (3,'Banheiro'),
		   (4,'Hall'),
		   (5,'Copa'),
		   (6,'Cozinha'),
		   (7,'Area de Serviço'),
		   (8,'Area de Externa')

GO
--Select * from TipoDeLocal
--GO

-- ******************************************************    
-- Popula tabela Local
-- ******************************************************

INSERT INTO [dbo].[Local]
           ([Local_ID],[Local_Descr],[Local_Area],[Local_Perimetro],[TipoDeLocal_ID],[Residencia_ID])
     VALUES
           (1, 'Sala' ,9.91,12.6 ,1,1),
		   (2, 'Copa' ,9.45,12.3 ,5,1),
		   (3, 'Cozinha' ,11.43,13.6 ,6,1),
		   (4, 'Banheiro' ,4.14,null ,3,1),
		   (5, 'Hall' ,1.8,null ,4,1),
		   (6, 'Dormitorio1' ,11.05,13.3 ,2,1),
		   (7, 'Dormitorio2' ,10.71,13.1 ,2,1),
		   (8, 'Area Externa',0,null ,8,1),
		   (9, 'Area de Serviço',5.95,null ,7,1)
GO

--Select l.*, tl.TipoDeLocal_Descr
--from [local] as l 
--     join TipoDeLocal as tl
--	 on l.TipoDeLocal_ID = tl.TipoDeLocal_ID
--order by l.Local_ID
--go

-- ******************************************************    
-- Popula tabela LocalXCircuito
-- ******************************************************
INSERT INTO [dbo].[LocalXCircuito]
           ([Local_ID] ,[Circuito_ID])
     VALUES -- Ordem: (Local_ID, Circuito_ID)

           (1 ,1), -- (Sala, Ilum. Social)
		   (6 ,1), -- (Dormitorio1, Ilum. Social)
		   (7 ,1), -- (Dormitorio2, Ilum. Social)
		   (4 ,1), -- (Banheiro, Ilum. Social)
		   (5 ,1), -- (Hall, Ilum. Social)

		   (2 ,2), -- (Copa, Ilum. Servico)
		   (3 ,2), -- (Cozinha, Ilum. Servico)
		   (8 ,2), -- (Area Externa, Ilum. Servico)
		   (9 ,2), -- (Area de Serviço, Ilum. Servico)
			
		   (1 ,3), -- (Sala, PTUG1)
		   (6 ,3), -- (Dormitorio1, PTUG1)
		   (5 ,3), -- (Hall, PTUG1)

		   (4 ,4), -- (Banheiro, PTUG2)
		   (7 ,4), -- (Dormitorio2, PTUG2)

		   (2 ,5), -- (Copa, PTUG3)

		   (2 ,6), -- (Copa, PTUG4)

		   (3 ,7), -- (Cozinha, PTUG5)

		   (3 ,8), -- (Cozinha, PTUG & PTUE)

		   (9 ,9), -- (Area de Serviço, PTUG6)

		   (9 ,10), -- (Area de Serviço, PTUE)

		   (4 ,11), -- (Banheiro,Circuito Chuveiro)

		   (3 ,12) -- (Cozinha, Torneira)   
GO

--Select c.Circuito_ID, c.Circuito_Descr, l.Local_Descr
--from [local] as l 
--     join LocalXCircuito as lxc
--	 on l.Local_ID = lxc.Local_ID
--	 join Circuito as c
--	 on c.Circuito_ID = lxc.Circuito_ID
--order by c.Circuito_ID
--go

USE [Dimensionamento]
GO
-- ******************************************************    
-- Popula tabela TipoDeCarga
-- ******************************************************
INSERT INTO [dbo].[TipoDeCarga]
           ([TipoDeCarga_ID],[TipoDeCarga_Tensao],[TipoDeCarga_Pot],[TipoDeCarga_Descr])
     VALUES
           (1, 220,5600, 'Chuveiro'), 
		   (2, 127, 600, 'Geladeira'),
		   (3, 127, 100, 'Iluminaçao'),
		   (4, 127, 160, 'PTUG'),
		   (5, 127, 600, 'PTUG microondas'),
		   (6, 220, 5000, 'Torneira'),
		   (7, 127, 700, 'Secador')
GO

--Select * from TipoDeCarga
--GO

--Select c.*, tc.TipoDeCarga_Descr
--from Carga as c
--     join TipoDeCarga as tc
--	 on c.TipoDeCarga_ID = tc.TipoDeCarga_ID
--order by c.TipoDeCarga_ID
--go


-- ******************************************************    
-- Popula tabela TipoDePonto
-- ******************************************************
USE [Dimensionamento]
GO
INSERT INTO [dbo].[TipoDePonto]
           ([TipoDePonto_ID],[TipoDePonto_Imagem],[TipoDePonto_Descr])
     VALUES
		   (0, 0x0, 'Quadro de distribuiçao'),
           (1,0x0 ,'PTUG simples'),
		   (2,0x0 ,'PTUG dupla'),
		   (3,0x0 ,'Conector chuveiro'),
		   (4,0x0 ,'Ponto de luz'),
		   (5,0x0 ,'Conector microondas'),
		   (6,0x0 ,'Conector Ar-condicionado'),
		   (7, 0x0, 'Conector secador')
		  		  
GO

--Select p.* from TipoDePonto as p
--GO

-- ******************************************************    
-- Popula tabela Ponto
-- ******************************************************

USE [Dimensionamento]
GO

INSERT INTO [dbo].[Ponto]
           ([Ponto_ID] ,[Ponto_PosicaoX],[Ponto_PosicaoY],[Ponto_PosicaoZ],[Local_ID],[TipoDePonto_ID])
     VALUES
		   (0,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Sala'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'Quadro de distribuiçao') ),

           (1,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Sala'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'Ponto de luz') ),
		   (2,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Dormitorio1'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'Ponto de luz') ),
		   (3,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Dormitorio2'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'Ponto de luz') ),
		   (4,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Banheiro'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'Ponto de luz') ),
		   (5,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Hall'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'Ponto de luz') ),

		   (6,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Copa'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'Ponto de luz') ),
		   (7,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Cozinha'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'Ponto de luz') ),
		   (8,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Area de Serviço'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'Ponto de luz') ),
		   (9,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Area Externa'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'Ponto de luz') ),
		   
		   (10,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Sala'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'PTUG simples') ),
		   (11,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Dormitorio1'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'PTUG simples') ),
		   (12,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Hall'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'PTUG simples') ),
		   (13,50.0,10.1,1.2,(Select Local_ID from Local where Local_Descr = 'Sala'),(Select TipoDePonto_ID from TipoDePonto where TipoDePonto_Descr = 'PTUG simples') )
GO

--select * from Ponto



-- ******************************************************    
-- Popula tabela Carga
-- ******************************************************
USE [Dimensionamento]
GO

INSERT INTO [dbo].[Carga]
           ([Carga_ID],[Ponto_ID],[Circuito_ID],[Carga_Pot],[TipoDeCarga_ID])
     VALUES
           (1,6,3,100,4),	-- PTUG simples na sala, no circuito de ID 3 com potencia de 100 VA e o tipo de carga PTUG
		   (1,10,5,600,5),	-- PTUG simples na sala, no circuito de ID 3 com potencia de 100 VA e o tipo de carga PTUG
		   (2,10,5,600,5)
		   

GO

-- ******************************************************    
-- Popula tabela TipoDeEletroduto
-- ******************************************************

USE [Dimensionamento]
GO

INSERT INTO [dbo].[TipoDeEletroduto]
           ([TipoDeEletroduto_ID],[TipoDeEletroduto_TamNom])
     VALUES
           (1,16),
		   (2,20),
		   (3,25),
		   (4,32)
GO

-- ******************************************************    
-- Popula tabela [Segmento]
-- ******************************************************
USE [Dimensionamento]
GO

INSERT INTO [dbo].[Segmento]
           ([Ponto_ID_A],[Ponto_ID_B],[TipoDeEletroduto_ID])
     VALUES
			(0,1, 1), -- quadro de dist -> lamp da sala : 16 tam nom
		    (1,10, 1), -- lamp da sala  -> PTUG1 sala : 16 tam nom
		    (1,13, 1) -- lamp da sala  -> PTUG2 sala : 16 tam nom
GO



