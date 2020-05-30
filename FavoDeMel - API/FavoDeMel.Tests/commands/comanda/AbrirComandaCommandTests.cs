using FavoDeMel.Commands.Comanda;
using FluentAssertions;
using System;
using Xunit;

namespace FavoDeMel.Tests.commands.comanda
{
    public class AbrirComandaCommandTests
    {
        [Fact]
        public void Quando_abrir_comanda_com_Id_invalido()
        {
            var act = new Action(() => new AbrirComandaCommand(default(int)));
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("id");
        }
    }
}
