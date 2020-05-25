using System;
using System.Collections.Generic;
using System.Text;

namespace FavoDeMel.Domain.Exceptions
{
    public  class TesteException: AppException
    {
        public TesteException() : base("teste") { }
    }
}
