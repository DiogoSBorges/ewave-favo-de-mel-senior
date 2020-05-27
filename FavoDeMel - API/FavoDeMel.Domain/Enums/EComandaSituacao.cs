using System.ComponentModel;

namespace FavoDeMel.Domain.Enums
{
    public enum EComandaSituacao
    {
        [Description("Aberta")]
        Aberta = 1,

        [Description("Fechada")]
        Fechada = 2,
    }
}
