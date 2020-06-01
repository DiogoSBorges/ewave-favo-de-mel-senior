using FavoDeMel.Commands.Comanda;
using FluentAssertions;
using System;
using Xunit;

namespace FavoDeMel.Tests.commands.comanda
{
    public class FecharComandaCommandTests
    {
        [Fact]
        public void Quando_fechar_comanda_com_Id_invalido()
        {
            var act = new Action(() => new FecharComandaCommand(default(int)));
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("id");
        }
    }
}
