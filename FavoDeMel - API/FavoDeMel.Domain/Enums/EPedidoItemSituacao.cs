using System.ComponentModel;

namespace FavoDeMel.Domain.Enums
{
    public enum EPedidoItemSituacao
    {
        [Description("Aguardando Produção")]
        AgardandoProducao = 1,

        [Description("Em Produção")]
        EmProducao = 2,

        [Description("Finalizado")]
        Finalizado = 3,

        [Description("Entregue")]
        Entregue = 4,

        [Description("Cancelado")]
        Cancelado = 5
    }
}
