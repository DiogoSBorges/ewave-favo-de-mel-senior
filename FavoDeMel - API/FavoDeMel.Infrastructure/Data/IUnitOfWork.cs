using System.Threading.Tasks;

namespace FavoDeMel.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
