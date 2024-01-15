using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(t => t.FirstName)
                .NotEmpty().NotNull().MaximumLength(100);

            RuleFor(t => t.LastName)
                .NotEmpty().NotNull().MaximumLength(100);

            RuleFor(t => t.PhoneNumber)
                .NotEmpty().NotNull().MaximumLength(15);

            RuleFor(t => t.Password)
                .NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
