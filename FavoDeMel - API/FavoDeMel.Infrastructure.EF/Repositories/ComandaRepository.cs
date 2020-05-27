using FavoDeMel.Domain.Models;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.EF.Data;
using FavoDeMel.Infrastructure.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FavoDeMel.Infrastructure.EF.Repositories
{
    public class ComandaRepository : Repository<Comanda>, IComandaRepository
    {
        public ComandaRepository(AppDataContext dataContext) : base(dataContext)
        {

        }  
    }
}
