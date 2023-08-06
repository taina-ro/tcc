-- Finalidade: Script para criação dos objetos do banco de dados Residencia
-- Autor: Taina Ribeiro

set nocount on 


Use Dimensionamento
go
if exists (select * from sys.tables where name = 'CircuitoXSegmento')
	Drop table dbo.CircuitoXSegmento
go
if exists (select * from sys.tables where name = 'LocalXCircuito')
	Drop table dbo.LocalXCircuito 
go
if exists (select * from sys.tables where name = 'Carga')
	Drop table dbo.Carga 
go
if exists (select * from sys.tables where name = 'Circuito')
	Drop table dbo.Circuito 
go
if exists (select * from sys.tables where name = 'Segmento')
	Drop table dbo.Segmento
go
if exists (select * from sys.tables where name = 'Ponto')
	Drop table dbo.Ponto 
go
if exists (select * from sys.tables where name = 'Local')
	Drop table dbo.[Local] 
go
if exists (select * from sys.tables where name = 'TipoDeLocal')
	Drop table dbo.TipoDeLocal
go
if exists (select * from sys.tables where name = 'TipoDePonto')
	Drop table dbo.TipoDePonto 
go
if exists (select * from sys.tables where name = 'TipoDeCarga')
	Drop table dbo.TipoDeCarga 
go
if exists (select * from sys.tables where name = 'TipoDeEletroduto')
	Drop table dbo.TipoDeEletroduto 
go
if exists (select * from sys.tables where name = 'DR')
	Drop table dbo.DR 
go
if exists (select * from sys.tables where name = 'Residencia')
	Drop table dbo.Residencia 
go

-- *************************************************************************************************
-- Cria Tabela Residencia
-- *************************************************************************************************
Create table dbo.Residencia (
	Residencia_ID			int		not null 
	   constraint PK_Residencia primary key (Residencia_ID), -- Identificação do Residencia (PK)
	Residencia_Area float not null,
	Residencia_Perimetro float not null,
	Residencia_NumFases tinyint not null,
	Residencia_NumPav tinyint not null,
    Residencia_PadraoEnergia			varchar (255) null,     -- Descrição do padrao de energia 
	Residencia_CxDist		 varchar (255)	null,
	Residencia_Descr			varchar (255)	not null     -- Descrição do Residencia (UN)
	   constraint UN_Residencia_Descr Unique (Residencia_Descr)) 
GO

---- *************************************************************************************************
---- Cria Tabela DR
---- *************************************************************************************************
Create table dbo.DR (
	DR_ID			int		not null 
	   constraint PK_DR primary key (DR_ID), -- Identificação do DR (PK)
	DR_CorrenteNom int not null, -- valor comercial de corrente para DR
    DR_Descr			varchar (255)	not null     -- Descrição do Protecao (UN)
	   constraint UN_DR_CorrenteNom Unique  ( DR_CorrenteNom))    
GO

---- *************************************************************************************************
---- Cria Tabela Circuito
---- *************************************************************************************************
Create table dbo.Circuito (
	Circuito_ID			int		not null 
	   constraint PK_Circuito primary key (Circuito_ID), -- Identificação do circuito (PK)
	Circuito_Tensao int not null,

	Circuito_Descr			varchar (255)	not null     -- Descrição do circuito (UN)
	   constraint UN_Circuito_Descr Unique (Circuito_Descr),
	Residencia_ID			int		not  null 
	   constraint FK_Circuito_Residencia foreign key (Residencia_ID) references Residencia,
	DR_ID				int			not null
		constraint FK_Circuito_DR foreign key (DR_ID) references DR,
	Circuito_NumCondutores int not null,
	Circuito_SecaoFase float not null,
	Circuito_SecaoProtecao float not null )

GO

---- *************************************************************************************************
---- Cria Tabela TipoDeLocal
---- *************************************************************************************************
Create table dbo.TipoDeLocal (
	TipoDeLocal_ID			int		not null 
	   constraint PK_TipoDeLocal primary key (TipoDeLocal_ID), -- Identificação do TipoDeComodo (PK)
    TipoDeLocal_Descr			varchar (255)	not null     -- Descrição do TipoDeComodo (UN)
	   constraint UN_TipoDeLocal_Descr Unique (TipoDeLocal_Descr))    
GO

---- *************************************************************************************************
---- Cria Tabela Local
---- *************************************************************************************************
Create table dbo.Local (
	Local_ID			int		not null 
	   constraint PK_Local primary key (Local_ID),				-- Identificação do Local (PK)
	Local_Descr			varchar (255)	not null				-- Descrição do Local (UN)
	   constraint UN_Localo_Descr Unique (Local_Descr),
	Local_Area			float	not null,						-- Area do local, exemplo da Sala de Estar
	Local_Perimetro			float		 null,					-- Perimetro do local, exemplo da Sala de Estar
	TipoDeLocal_ID int not null									-- Identificaçao externa do TipoDeLocal
	constraint FK_Local_TipoDeLocal foreign key (TipoDeLocal_ID) references TipoDeLocal, 
	Residencia_ID			int		not null					-- Identificaçao externa da Residencia
	constraint FK_Local_Residencia foreign key (Residencia_ID) references Residencia)    
GO

---- *************************************************************************************************
---- Cria Tabela LocalXCircuito
---- *************************************************************************************************
Create table dbo.LocalXCircuito (
	Local_ID			int		not null, 
	Circuito_ID			int		not null,
	constraint PK_LocalXCircuito primary key (Local_ID, Circuito_ID),
	constraint FK_LocalXCircuito_Local foreign key (Local_ID) references Local,
	constraint FK_LocalXCircuito_Circuito foreign key (Circuito_ID) references Circuito)
GO


---- *************************************************************************************************
---- Cria Tabela TipoDePonto
---- *************************************************************************************************
Create table dbo.TipoDePonto (
	TipoDePonto_ID			int		not null 
	   constraint PK_TipoDePonto primary key (TipoDePonto_ID), -- Identificação do TipoDePonto (PK)
	TipoDePonto_Imagem varbinary(max) not null, -- Png da imagem
    TipoDePonto_Descr			varchar (255)	not null     -- Descrição do TipoDePonto (UN)
	   constraint UN_TipoDePonto_Descr Unique (TipoDePonto_Descr))    
GO

---- *************************************************************************************************
---- Cria Tabela Ponto
---- *************************************************************************************************
Create table dbo.Ponto (
	Ponto_ID			int		not null 
	   constraint PK_Ponto primary key (Ponto_ID), -- Identificação do Ponto (PK)
	Ponto_PosicaoX float not null,
	Ponto_PosicaoY float not null,
	Ponto_PosicaoZ float not null,
	Local_ID int not null
	constraint FK_Ponto_Local foreign key (Local_ID) references [Local],
	TipoDePonto_ID int not null
	constraint FK_Ponto_TipoDePonto foreign key (TipoDePonto_ID) references TipoDePonto)    
GO

---- *************************************************************************************************
---- Cria Tabela TipoDeCarga
---- *************************************************************************************************
Create table dbo.TipoDeCarga (
	TipoDeCarga_ID			int		not null 
	   constraint PK_TipoDeCarga primary key (TipoDeCarga_ID), -- Identificação do TipoDeCarga (PK)
	TipoDeCarga_Tensao		int		not null,
	TipoDeCarga_Pot		int		not null,
    TipoDeCarga_Descr			varchar (255)	not null     -- Descrição do TipoDeCarga (UN)
	   constraint UN_TipoDeCarga_Descr Unique (TipoDeCarga_Descr))    
GO

---- *************************************************************************************************
---- Cria Tabela Carga
---- *************************************************************************************************
Create table dbo.Carga (
	Carga_ID			tinyint		not null,
	Ponto_ID			int		    not null,
	Circuito_ID			int			not null,
	Carga_Pot			int				null,
	TipoDeCarga_ID		int			not null,
	Constraint PK_Carga primary key (Circuito_ID, Ponto_ID, Carga_ID), -- Identificação da Carga (PK)
	Constraint FK_Carga_TipoDeCarga foreign key (TipoDeCarga_ID) references TipoDeCarga,
	Constraint FK_Carga_Ponto foreign key (Ponto_ID) references Ponto,
	Constraint FK_Carga_Circuito foreign key (Circuito_ID) references Circuito

	)
GO


---- *************************************************************************************************
---- Cria Tabela TipoDeEletroduto
---- *************************************************************************************************
Create table dbo.TipoDeEletroduto (
	TipoDeEletroduto_ID			int		not null 
	   constraint PK_TipoDeEletroduto primary key (TipoDeEletroduto_ID), -- Identificação do TipoDeEletroduto (PK)
	TipoDeEletroduto_TamNom int not null 
		constraint UN_TipoDeEletroduto_TamNom Unique (TipoDeEletroduto_TamNom))   
GO

------ *************************************************************************************************
------ Cria Tabela Segmento
------ *************************************************************************************************
Create table dbo.Segmento (
	Ponto_ID_A int not null, -- Um Eletroduto conecta um ponto A a um ponto B
	Ponto_ID_B int not null,
	TipoDeEletroduto_ID int not null, 

	constraint PK_Segmento primary key (Ponto_ID_A, Ponto_ID_B) ,
	constraint FK_Segmento_Ponto_A foreign key (Ponto_ID_A) references Ponto,
	constraint FK_Segmento_Ponto_B foreign key (Ponto_ID_B) references Ponto,
	constraint FK_Segmento_TipoDeEletroduto foreign key (TipoDeEletroduto_ID) references TipoDeEletroduto) 
GO

---- *************************************************************************************************
---- Cria Tabela CircuitoXSegmento
---- *************************************************************************************************
Create table dbo.CircuitoXSegmento (
	Circuito_ID			int		not null,
	Ponto_ID_A			int		not null, 
	Ponto_ID_B			int not null,
	constraint PK_CircuitoXSegmento primary key (Ponto_ID_A,Ponto_ID_B, Circuito_ID),
	constraint FK_CircuitoXSegmento_Circuito foreign key (Circuito_ID) references Circuito,
	constraint FK_CircuitoXSegmento_Segmento foreign key (Ponto_ID_A,Ponto_ID_B) references Segmento)
GO

















