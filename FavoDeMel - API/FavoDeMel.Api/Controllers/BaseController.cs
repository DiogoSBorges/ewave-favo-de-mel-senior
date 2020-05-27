using FavoDeMel.Api.Filter;
using FavoDeMel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoDeMel.Api.Controllers
{
    [ExcepionActionFilter]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
