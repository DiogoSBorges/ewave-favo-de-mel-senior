using FavoDeMel.Domain.Queries.Views;
using FavoDeMel.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Queries
{
    public interface IProdutoQuery
    {
        Task<IEnumerable<ProdutoView>> ObterTodosAsync();
    }
}
