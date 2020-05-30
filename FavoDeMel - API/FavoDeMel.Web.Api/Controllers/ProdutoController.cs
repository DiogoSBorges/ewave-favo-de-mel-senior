using FavoDeMel.Api.Controllers;
using FavoDeMel.Domain.Queries;
using FavoDeMel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FavoDeMel.Web.Api.Controllers
{

    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : BaseController
    {

        private readonly IProdutoQuery _produtoQuery;

        public ProdutoController
            (ICommandDispatcher commandDispatcher,
            IUnitOfWork unitOfWork,
            IProdutoQuery produtoQuery) : base(commandDispatcher, unitOfWork)
        {
            _produtoQuery = produtoQuery;
        }

        /// <summary>
        /// Busca todos produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var comandas = await _produtoQuery.ObterTodosAsync();

            return Ok(comandas);
        }
    }
}
