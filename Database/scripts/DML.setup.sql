USE [FavoDeMel];

INSERT INTO dbo.[ComandaSituacao] ([Id], [Nome]) VALUES
(1, 'Aberta'),
(2, 'Fechada')
GO

DECLARE @ComandaCount INT = 0;
WHILE @ComandaCount < 50
BEGIN
    SET @ComandaCount = @ComandaCount + 1;

	INSERT INTO [dbo].[Comanda] ([Numero], [SituacaoId]) VALUES
	( @ComandaCount, 2 )    
END
GO

INSERT INTO [dbo].[PedidoSituacao] ([Id], [Nome]) VALUES
( 1, 'Criado'),
( 2, 'Entregue'),
( 3, 'Cancelado')
GO

INSERT INTO [dbo].[PedidoItemSituacao] ([Id], [Nome]) VALUES
( 1, 'Aguardando Produção'),
( 2, 'Em Produção'),
( 3, 'Finalizado'),
( 4, 'Entregue'),
( 5, 'Cancelado')
GO

INSERT INTO [dbo].[PedidoItemProducaoPrioridade] ([Id], [Nome]) VALUES
( 1, 'Normal'),
( 2, 'Alta'),
( 3, 'Urgente')
GO

INSERT INTO [dbo].[ProdutoTipo] ([Id], [Nome]) VALUES
( 1, 'Carne'),
( 2, 'PratoExecutivo'),
( 3, 'Massa'),
( 4, 'Saladas'),
( 5, 'Cerveja'),
( 6, 'Drink'),
( 7, 'Suco'),
( 8, 'Shake'),
( 9, 'Refrigerante')
GO

INSERT INTO [dbo].[Produto]([Nome], [Descricao], [TempoPreparo],[Valor], [TipoId]) VALUES
('Picanha Na Chapa', null, 20, 39.90 , 1),
('Parmegiana de Filé Bovino', 'Acompanha Arroz e BataFrita', 30, 35.90 , 2),
('Espaguete à carbonara', null, 30, 25.90 , 3),
('Salada Caesar', null, 10, 10 , 4),
('Brahma 600ml', null, null, 10.50 , 5),
('Cozumel Brahma', null, 5, 15 , 6),
('Suco de Laranja 1l', null, 5, 15 , 7),
('Milkshake de Chocolate 300ml', null, 8, 10 , 8),
('Coca KS', null, null, 2.75 , 9),
('Fanta KS', null, null, 2.50 , 9)
GO