IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'FavoDeMel')
BEGIN
	CREATE DATABASE [FavoDeMel];
END
GO

USE [FavoDeMel];
GO

CREATE TABLE [dbo].[ComandaSituacao] 
(
	[Id] INT NOT NULL,
	[Nome] VARCHAR(180) NOT NULL,
	CONSTRAINT [PK_ComandaSituacao] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[Comanda] 
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[Numero] INT NOT NULL UNIQUE,
	[SituacaoId] INT NOT NULL,
	CONSTRAINT [PK_Comanda] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY],
	CONSTRAINT [FK_Comanda_ComandaSituacao] FOREIGN KEY ([SituacaoId]) REFERENCES [dbo].[ComandaSituacao](Id)
)
GO

CREATE TABLE [dbo].[ComandaMovimento] 
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[DataAbertura] DATETIME NOT NULl,
	[DataFechamento] DATETIME NULl,
	[ComandaId] INT NOT NULL,
	CONSTRAINT [PK_ComandaMovimento] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY],
	CONSTRAINT [FK_ComandaMovimento_Comanda] FOREIGN KEY ([ComandaId]) REFERENCES [dbo].[Comanda](Id)
)
GO

CREATE TABLE [dbo].[ProdutoTipo] 
(
	[Id] INT NOT NULL,
	[Nome] VARCHAR(150) NOT NULl,	
	CONSTRAINT [PK_ProdutoTipo] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[Produto] 
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Nome] VARCHAR(150) NOT NULl,	
	[Observacao] VARCHAR (255) NULL,
	[TempoPreparo] INT NULL,
	[Valor]	DECIMAL(19,2) NOT NULL,
	[TipoId] INT NOT NULL
	CONSTRAINT [PK_Produto] PRIMARY KEY ([Id]) ON [PRIMARY],
	CONSTRAINT [FK_Produto_ProdutoTipo] FOREIGN KEY ([TipoId]) REFERENCES [dbo].[Produto]([Id])
)
GO

CREATE TABLE [dbo].[PedidoSituacao] 
(
	[Id] INT NOT NULL,
	[Nome] VARCHAR(150) NOT NULl,	
	CONSTRAINT [PK_PedidoSituacao] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[Pedido] 
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Observacao] VARCHAR (255) NULL,
	[Data] DATETIME NOT NULL,
	[ComandaMovimentoId] INT NOT NULL,
	[SituacaoId] INT NOT NULL,
	CONSTRAINT [PK_Pedido] PRIMARY KEY ([Id]) ON [PRIMARY],
	CONSTRAINT [FK_Pedido_ComandaMovimento] FOREIGN KEY ([ComandaMovimentoId]) REFERENCES [dbo].[ComandaMovimento]([Id]),
	CONSTRAINT [FK_Pedido_PedidoSituacao] FOREIGN KEY ([SituacaoId]) REFERENCES [dbo].[PedidoSituacao]([Id])
)
GO

CREATE TABLE [dbo].[PedidoItemSituacao] 
(
	[Id] INT NOT NULL,
	[Nome] VARCHAR(150) NOT NULl,	
	CONSTRAINT [PK_PedidoItemSituacao] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[PedidoItem] 
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Observacao] VARCHAR (255) NULL,
	[PedidoId] INT NOT NULL,
	[ProdutoId] INT NOT NULL,
	[SituacaoId] INT NOT NULL,
	CONSTRAINT [PK_PedidoItem] PRIMARY KEY ([Id]) ON [PRIMARY],
	CONSTRAINT [FK_PedidoItem_Pedido] FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedido]([Id]),
	CONSTRAINT [FK_PedidoItem_Produto] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produto]([Id]),
	CONSTRAINT [FK_PedidoItem_PedidoItemSituacao] FOREIGN KEY ([SituacaoId]) REFERENCES [dbo].[PedidoItemSituacao]([Id])
)
GO

CREATE TABLE [dbo].[PedidoItemProducaoPrioridade] 
(
	[Id] INT NOT NULL,
	[Nome] VARCHAR(150) NOT NULl,	
	CONSTRAINT [PK_PedidoItemProducaoPrioridade] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[PedidoItemProducao] 
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[DataInicio] DATETIME NULL,
	[DataFim] DATETIME NULL,
	[PedidoItemId] INT NOT NULl,	
	[PrioridadeId] INT NOT NULL,
	CONSTRAINT [PK_PedidoItemProducao] PRIMARY KEY ([Id]) ON [PRIMARY],
	CONSTRAINT [FK_PedidoItemProducao_PedidoItem] FOREIGN KEY ([PedidoItemId]) REFERENCES [dbo].[PedidoItem]([Id]),
	CONSTRAINT [FK_PedidoItemProducao_PedidoItemProducaoPrioridade] FOREIGN KEY ([PrioridadeId]) REFERENCES dbo.[PedidoItemProducaoPrioridade]([Id])
)
GO