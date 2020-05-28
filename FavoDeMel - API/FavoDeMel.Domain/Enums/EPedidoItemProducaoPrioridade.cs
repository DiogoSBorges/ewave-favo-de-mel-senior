using System.ComponentModel;

namespace FavoDeMel.Domain.Enums
{
    public enum EPedidoItemProducaoPrioridade
    {
        [Description("Normal")]
        Normal = 1,

        [Description("Alta")]
        Alta = 2,

        [Description("Urgente")]
        Urgente = 3
    }
}
