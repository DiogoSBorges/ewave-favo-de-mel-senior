using FavoDeMel.Infrastructure.Data;

namespace FavoDeMel.Domain.Models
{
    public class PedidoSituacao : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
