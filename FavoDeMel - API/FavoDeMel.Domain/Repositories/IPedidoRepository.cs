using FavoDeMel.Domain.Models;
using FavoDeMel.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> ObterPedidosPorAsync(int comandaMovimentoId);
    }
}
