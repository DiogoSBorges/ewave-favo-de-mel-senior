using FavoDeMel.Api.Controllers;
using FavoDeMel.Api.Hubs;
using FavoDeMel.Commands.Comanda;
using FavoDeMel.Domain.Queries;
using FavoDeMel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace FavoDeMel.Web.Api.Controllers
{

    [Route("api/comanda")]
    [ApiController]
    public class ComandaController : BaseController
    {

        private readonly IComandaQuery _comandaQuery;
        private IHubContext<FavoDeMelHub> _hub;


        public ComandaController
            (ICommandDispatcher commandDispatcher,
            IUnitOfWork unitOfWork,
            IComandaQuery comandaQuery,
            IHubContext<FavoDeMelHub> hub) : base(commandDispatcher, unitOfWork)
        {
            _comandaQuery = comandaQuery;
            _hub = hub;
        }

        /// <summary>
        /// Abrir Comanda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}/abrir")]
        public async Task<IActionResult> AbrirAsync(int id)
        {
            var command = new AbrirComandaCommand(id);
            await CommandDispatcher.HandleAsync(command);

            await UnitOfWork.CommitAsync();

            _hub.Clients.All.SendAsync("ComandaAberta");

            return Ok();
        }


        /// <summary>
        /// Busca todas comandas
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> ObterTodosAsync([FromQuery] PaginacaoInfo paginacao)
        {
            var comandas = await _comandaQuery.ObterTodasAsync(paginacao);

            return Ok(comandas);
        }
    }
}
