﻿using FavoDeMel.Api.Controllers;
using FavoDeMel.Api.Hubs;
using FavoDeMel.Commands;
using FavoDeMel.Commands.Pedido;
using FavoDeMel.Domain.Dto;
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
        public PedidoController(
            ICommandDispatcher commandDispatcher, 
            IUnitOfWork unitOfWork,
            IHubContext<FavoDeMelHub> hub) : base(commandDispatcher, unitOfWork)
        {
            _hub = hub;
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
    }
}
