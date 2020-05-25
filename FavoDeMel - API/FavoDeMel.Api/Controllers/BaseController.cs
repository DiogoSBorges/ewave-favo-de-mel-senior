using FavoDeMel.Api.Filter;
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
    }
}
