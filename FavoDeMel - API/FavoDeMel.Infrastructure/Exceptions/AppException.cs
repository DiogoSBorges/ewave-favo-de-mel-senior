using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FavoDeMel.Domain.Exceptions
{
    public abstract class AppException : Exception
    {

        public HttpStatusCode Code { get; }

        protected AppException(string message) : base(message)
        {
            Code = HttpStatusCode.BadRequest;
        }

        protected AppException(string message, HttpStatusCode code) : base(message)
        {
            Code = code;
        }
    }
}
