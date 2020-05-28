using FavoDeMel.Api.Controllers;
using FavoDeMel.Commands;
using FavoDeMel.Commands.Comanda;
using FavoDeMel.Domain.Queries;
using FavoDeMel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Web.Api.Controllers
{

    [Route("api/comanda")]
    [ApiController]
    public class ComandaController : BaseController
    {

        private readonly IComandaQuery _comandaQuery;


        public ComandaController
            (ICommandDispatcher commandDispatcher, 
            IUnitOfWork unitOfWork, 
            IComandaQuery comandaQuery) : base(commandDispatcher, unitOfWork)
        {
            _comandaQuery = comandaQuery;
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

            return Ok();
        }


        /// <summary>
        /// Busca todas comandas
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var comandas = await _comandaQuery.ObterTodasAsync();

            return Ok(comandas);
        }
    }
}
