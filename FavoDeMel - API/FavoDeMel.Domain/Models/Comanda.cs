namespace FavoDeMel.Domain.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        public int SituacaoId { get; set; }
        public virtual ComandaSituacao Situacao { get; set; }
    }
}
