using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Api.Hubs;
using FavoDeMel.Application.Commands;
using FavoDeMel.Domain.Exceptions;
using FavoDeMel.Domain.Models;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FavoDeMel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseController
    {
        private IHubContext<FavoDeMelHub> _hub;

        private readonly ICommandDispatcher _commandDispatcher;

        private readonly ITesteRepository _testeRepository;

        public ValuesController(IUnitOfWork unitOfWork, 
            ICommandDispatcher commandDispatcher, 
            IHubContext<FavoDeMelHub> hub,
            ITesteRepository testeRepository ) :base(unitOfWork)
        {
            _commandDispatcher = commandDispatcher;
            _hub = hub;
            _testeRepository = testeRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {


            await _commandDispatcher.HandleAsync(new AdicionarTesteCommand("TESTE"));

            var teste = new ComandaSituacao
            {
                Id = 4,
                Nome = "Vuala4"
            };

            var teste2 = new ComandaSituacao
            {
                Id = 5,
                Nome = "Vuala5"
            };

            await _testeRepository.AddAsync(teste);

            throw new TesteException();

            await _testeRepository.AddAsync(teste2);

            await UnitOfWork.CommitAsync();

            _hub.Clients.All.SendAsync("AlgoEnviado", "teste");
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
