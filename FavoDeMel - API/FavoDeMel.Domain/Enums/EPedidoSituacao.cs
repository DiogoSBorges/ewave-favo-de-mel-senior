using System.ComponentModel;

namespace FavoDeMel.Domain.Enums
{
    public enum EPedidoSituacao
    {
        [Description("Criado")]
        Criado = 1,

        [Description("Entregue")]
        Entregue = 2,
    }
}
