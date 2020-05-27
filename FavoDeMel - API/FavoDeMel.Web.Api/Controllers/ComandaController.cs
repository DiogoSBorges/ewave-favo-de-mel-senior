using FavoDeMel.Api.Controllers;
using FavoDeMel.Commands.Comanda;
using FavoDeMel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FavoDeMel.Web.Api.Controllers
{

    [Route("api/comanda")]
    [ApiController]
    public class ComandaController : BaseController
    {
        public ComandaController(ICommandDispatcher commandDispatcher, IUnitOfWork unitOfWork) : base(commandDispatcher, unitOfWork)
        {
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

    }
}
