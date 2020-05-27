using FavoDeMel.Infrastructure.Data;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Models
{
    public class Comanda : IEntity
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        public int SituacaoId { get; set; }
        public virtual ComandaSituacao Situacao { get; set; }

        public virtual ICollection<ComandaMovimento> Movimentos { get; set; } = new HashSet<ComandaMovimento>();

    }
}
