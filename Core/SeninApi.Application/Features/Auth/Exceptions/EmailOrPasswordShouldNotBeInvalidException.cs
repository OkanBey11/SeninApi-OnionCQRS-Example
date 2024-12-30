using SeninApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeninApi.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseExceptions
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Kullanıcı adı veya şifre yanlıştır.") { }
    }
}
