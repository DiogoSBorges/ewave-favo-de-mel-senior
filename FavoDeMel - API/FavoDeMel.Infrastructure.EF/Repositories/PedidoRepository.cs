using FavoDeMel.Domain.Models;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.EF.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoDeMel.Infrastructure.EF.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDataContext dataContext) : base(dataContext)
        {

        }

        public Task<IEnumerable<Pedido>> ObterPedidosPorAsync(int comandaMovimentoId)
        {
            var pedidos =  DataContext.Set<Pedido>().Select(x=>x).Where(x=>x.ComandaMovimentoId == comandaMovimentoId);
            return Task.FromResult(pedidos.AsEnumerable());
        }
    }
}
