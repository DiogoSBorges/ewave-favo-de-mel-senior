using FavoDeMel.Api.Hubs;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Api.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : BaseController
    {
        private IHubContext<FavoDeMelHub> _hub;

        private readonly ICommandDispatcher _commandDispatcher;

        private readonly ITesteRepository _testeRepository;

        public ValuesController(IUnitOfWork unitOfWork,
            ICommandDispatcher commandDispatcher,
            IHubContext<FavoDeMelHub> hub,
            ITesteRepository testeRepository) : base(unitOfWork)
        {
            _commandDispatcher = commandDispatcher;
            _hub = hub;
            _testeRepository = testeRepository;
        }


        /// <summary>
        /// Faz algo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            //_hub.Clients.All.
            /*await _commandDispatcher.HandleAsync(new AdicionarTesteCommand("TESTE"));

            
         

            var teste2 = new ComandaSituacao
            {
                Id = 6,
                Nome = "Vuala6"
            };

            await _testeRepository.AddAsync(teste2);

         

            await UnitOfWork.CommitAsync();

            _hub.Clients.All.SendAsync("AlgoEnviado", "teste");
            */
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
