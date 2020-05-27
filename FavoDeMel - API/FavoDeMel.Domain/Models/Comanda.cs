using FavoDeMel.Infrastructure.Data;

namespace FavoDeMel.Domain.Models
{
    public class Comanda : IEntity
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        public int SituacaoId { get; set; }
        public virtual ComandaSituacao Situacao { get; set; }
    }
}
