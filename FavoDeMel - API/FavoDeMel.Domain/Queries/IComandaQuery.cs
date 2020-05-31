using FavoDeMel.Domain.Queries.Views;
using FavoDeMel.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Queries
{
    public interface IComandaQuery
    {
        Task<IEnumerable<ComandaView>> ObterTodasAsync(PaginacaoInfo paginacao);
        Task<ComandaDetalhadaView> ObterComandaDetalhadaPorAsync(int id);
    }
}
