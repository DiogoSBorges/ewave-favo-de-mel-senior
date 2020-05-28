using FavoDeMel.Domain.Queries.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Queries
{
    public interface IComandaQuery
    {
        Task<IEnumerable<ComandaView>> ObterTodasAsync();
    }
}
