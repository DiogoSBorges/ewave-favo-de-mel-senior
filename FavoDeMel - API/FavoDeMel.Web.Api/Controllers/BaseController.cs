using FavoDeMel.Api.Filter;
using FavoDeMel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.Api.Controllers
{
    [ExcepionActionFilter]
    public class BaseController : ControllerBase
    {

        protected readonly ICommandDispatcher CommandDispatcher;
        protected readonly IUnitOfWork UnitOfWork;

        public BaseController(ICommandDispatcher commandDispatcher, IUnitOfWork unitOfWork)
        {
            CommandDispatcher = commandDispatcher;
            UnitOfWork = unitOfWork;
        }
    }
}
