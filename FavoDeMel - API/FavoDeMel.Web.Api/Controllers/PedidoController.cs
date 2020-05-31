using FavoDeMel.Api.Controllers;
using FavoDeMel.Commands;
using FavoDeMel.Commands.Pedido;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FavoDeMel.Web.Api.Controllers
{

    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : BaseController
    {
        public PedidoController(ICommandDispatcher commandDispatcher, IUnitOfWork unitOfWork) : base(commandDispatcher, unitOfWork)
        {
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

            return Ok();
        }

    }
}
