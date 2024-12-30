using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeninApi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshtokenCommandValidator : AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshtokenCommandValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty();

            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
