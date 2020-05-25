using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Api.Hubs;
using FavoDeMel.Application.Commands;
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

        public ValuesController(ICommandDispatcher commandDispatcher, IHubContext<FavoDeMelHub> hub)
        {
            _commandDispatcher = commandDispatcher;
            _hub = hub;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {


            await _commandDispatcher.HandleAsync(new AdicionarTesteCommand("TESTE"));

            _hub.Clients.All.SendAsync("EnviarAlgo", "teste");
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
