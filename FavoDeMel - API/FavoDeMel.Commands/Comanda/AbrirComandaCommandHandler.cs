using FavoDeMel.Domain.Commands;
using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Exceptions;
using FavoDeMel.Domain.Models;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.Extensions;
using System;
using System.Threading.Tasks;

namespace FavoDeMel.Commands.Comanda
{
    public class AbrirComandaCommandHandler : ICommandHandler<AbrirComandaCommand>
    {

        private readonly IComandaRepository _comandaRepository;

        public AbrirComandaCommandHandler(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }

        public async Task HandleAsync(AbrirComandaCommand command)
        {
            var comanda = await _comandaRepository.GetByAsync(command.Id);
            if (comanda.IsNull()) throw new ComandaNaoEncontradaException();

            if (comanda.SituacaoId == (int) EComandaSituacao.Aberta) throw new ComandaJaAbertaException();

            comanda.SituacaoId = (int)EComandaSituacao.Aberta;

            comanda.Movimentos.Add(new ComandaMovimento { DataAbertura = DateTime.Now });
        }
    }
}
