using FavoDeMel.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavoDeMel.Application.Commands
{
    public class AdicionarTesteCommand : ICommand
    {
        public string Valor { get; }

        public AdicionarTesteCommand(string valor)
        {
            Valor = valor;
        }
    }
}
