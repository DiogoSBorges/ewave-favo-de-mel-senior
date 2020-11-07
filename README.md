# Processo Seletivo Sênior - Ewave

### Back-End
- .Net Core 3.1
- Swagger
- DDD
- SignalR
- EntityFramework
-  UnitOfWork 
- Dapper
- CQRS

### Front-end 

- Angular 9
- RxJS
- Ngrx 
- Ngx-bootstrap
- Bootstrap
- Font-Awesome (V. 4.7)

### Database

- Sql Server
- Modelagem [aqui](Assets/FavoDeMel.png) 


## Desafio
O maior desafio aqui foi tentar encontrar alguma arquitetura viável para criar uma solução em realtime até porque foi a minha primeira experiência com esse tipo de tecnologia. Porém por se tratar de um MVP deixei para aprofundar em arquitetura posteriormente, então se puderem observar estou fazendo a emissão de menssagens do WS(SignalR) direto na execução do controller. O outro porém foi que por eu utilizar CQRS e implementar o mesmo, não fiz teste dos CommandsHandler porque seria uma idéia criar um TestFixture no furturo para deixar o código mais diâmica e não apenas instanciar uma classe com um monte de mocks.

## Bugs Identificados
### Front-End
- SideBar não fecha automaticamente em modo responsivo ao clicar na rota.


## Funcionalidades
Obs: As principais telas da aplicação funcionam em real time. Ou seja, abra várias instancias da tela :)

###  Abrir/ Fechar Comanda
É a funcionalidade base da solução sendo que a mesma gera o movimento para para cada vez que é aberta onde posso ter um histórico da comanda.

### Detalhe de Comanda
A funcionalidade principal da aplicação onde fica disponíveis todas as ações que o Garçon poderá fazer, como "cancelar produção", "priorizar produção", "marcar item como entregue" e "fechar a comanda"

### Fazer Pedido
Onde você pode criar vários pedidos e cada pedido você pode adicionar vários produtos, os quais podem ser produzidos (vão para cozinha) ou não (produtos a pronta entrega).

### Produção
É a funcionalidade voltada para a cozinha, onde o cozinheiro pode ver os itens de ordem prioriza e pode executar ações como "Iniciar Produção" e "Finalizar Produção (Deixa o produto disponível para o garçon fazer a entrega)" 

## Implementações futuras

### Funções
- ACL- Controle de Acesso
- Criar Comanda
- Criar Produto
- Relatórios de Comandas/ Pedidos
- Dashboard em RealTime com Contatores de Produção
- Melhorar a troca de Mensagem com o SignalR salvando o clientId para disparar mensagens com mais eficiência sem disparar para todos os clients uma mensagem simples

### BackEnd
- Criar um Context da propria aplicação para enviar as mensagens pro SignalR na ação do UnitOfWork
- Implementar TestFixture para testar os commands handlers

### FrontEnd
- Melhorias em UX
- Implementar TestFixture para testar os commands handlers
- Usar o Husky para rodar o linting e tests do projeto antes de fazer um commit.

# Executar o Projeto

Para executar o projeto, é necessário [docker](https://www.docker.com  "docker") instalado e rodando na sua máquina com containers base em LINUX e portas 1433, 8000 e 9000 disponíveis.
```
> git clone https://github.com/DiogoSBorges/ewave-favo-de-mel-senior.git
> cd ewave-favo-de-mel-senior
> docker-compose up
```
Após finalização da execução do docker você pode accessar :
- api : clicando [aqui](http://localhost:9000/swagger  "aqui").
- aplicação: clicando [aqui](http://localhost:8000/  "aqui").

 