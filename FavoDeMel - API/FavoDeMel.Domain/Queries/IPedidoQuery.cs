using FavoDeMel.Domain.Queries.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Queries
{
    public interface IPedidoQuery
    {
        Task<IEnumerable<PedidoItemDetalhadoView>> ObterPedidoItensPorAsync(int pedidoId);
    }
}
