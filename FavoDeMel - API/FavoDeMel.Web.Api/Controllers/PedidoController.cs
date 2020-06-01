using FavoDeMel.Api.Controllers;
using FavoDeMel.Api.Hubs;
using FavoDeMel.Commands;
using FavoDeMel.Commands.Pedido;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Queries;
using FavoDeMel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace FavoDeMel.Web.Api.Controllers
{

    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : BaseController
    {
        private IHubContext<FavoDeMelHub> _hub;
        private readonly IPedidoQuery _pedidoQuery;

        public PedidoController(
            ICommandDispatcher commandDispatcher, 
            IUnitOfWork unitOfWork,
            IHubContext<FavoDeMelHub> hub,
            IPedidoQuery pedidoQuery) : base(commandDispatcher, unitOfWork)
        {
            _hub = hub;
            _pedidoQuery = pedidoQuery;
        }

        /// <summary>
        /// Criar um pedido com com itens á comanda
        /// </summary>
        [HttpPost("criar")]
        public async Task<IActionResult> CriarAsync([FromBody] PedidoDto dto)
        {
            var command = new CriarPedidoCommand(dto.ComandaId, dto.Observacao, dto.Itens);
            await CommandDispatcher.HandleAsync(command);

            await UnitOfWork.CommitAsync();
            _hub.Clients.All.SendAsync("PedidoCriado");
            return Ok();
        }

        /// <summary>
        /// Busca pedido itens producao AguardandoProducao e Em producao
        /// </summary>
        /// <returns></returns>
        [HttpGet("pedido-item-producao")]
        public async Task<IActionResult> ObterPedidoitensProducaoAsync()
        {
            var pedidosItensProducao = await _pedidoQuery.ObterPedidoItenProducaoAsync();

            return Ok(pedidosItensProducao);
        }

       /// <summary>
       /// Inicia a produção de um item de pedido
       /// </summary>
       /// <param name="id"></param>
       /// <param name="pedidoItemId"></param>
       /// <returns></returns>
        [HttpPut("{id:int}/item/{pedidoItemId:int}/iniciar-producao")]
        public async Task<IActionResult> IniciarProducaoDeItemAsync(int id, int pedidoItemId)
        {
            var command = new IniciarProducaoPedidoItemCommand(id, pedidoItemId);
            await CommandDispatcher.HandleAsync(command);

            await UnitOfWork.CommitAsync();
            _hub.Clients.All.SendAsync("PedidoItemProducaoIniciada");

            return Ok();
        }

        /// <summary>
        /// Finaliza a produção de um item de pedido
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pedidoItemId"></param>
        /// <returns></returns>
        [HttpPut("{id:int}/item/{pedidoItemId:int}/finalizar-producao")]
        public async Task<IActionResult> FinalizarProducaoDeItemAsync(int id, int pedidoItemId)
        {
            var command = new FinalizarProducaoPedidoItemCommand(id,pedidoItemId);
            await CommandDispatcher.HandleAsync(command);

            await UnitOfWork.CommitAsync();
            _hub.Clients.All.SendAsync("PedidoItemProducaoFinalizada");

            return Ok();
        }

        /// <summary>
        /// Cancela um item de pedido
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pedidoItemId"></param>
        /// <returns></returns>
        [HttpPut("{id:int}/item/{pedidoItemId:int}/cancelar")]
        public async Task<IActionResult> CancelarItemAsync(int id, int pedidoItemId)
        {
            var command = new CancelarPedidoItemCommand(id, pedidoItemId);
            await CommandDispatcher.HandleAsync(command);

            await UnitOfWork.CommitAsync();
            _hub.Clients.All.SendAsync("PedidoItemCancelado");

            return Ok();
        }

        /// <summary>
        /// Entrega um item de pedido
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pedidoItemId"></param>
        /// <returns></returns>
        [HttpPut("{id:int}/item/{pedidoItemId:int}/entregar")]
        public async Task<IActionResult> EntregarItemAsync(int id, int pedidoItemId)
        {
            var command = new EntregarPedidoItemCommand(id, pedidoItemId);
            await CommandDispatcher.HandleAsync(command);

            await UnitOfWork.CommitAsync();
            _hub.Clients.All.SendAsync("PedidoItemEntregue");

            return Ok();
        }
    }
}
