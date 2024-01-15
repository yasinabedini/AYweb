using AIPFramework.Commands;
using AYweb.Application.Models.User.Commands.ConfirmEmail;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AYweb.Application.Models.User.Commands.ConfirmPhoneNumber
{
    public class ConfirmPhoneNumberCommandHandler : ICommandHandler<ConfirmPhoneNumberCommand>
    {
        private readonly IUserRepository _repository;

        public ConfirmPhoneNumberCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ConfirmPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.GetById(request.Id);
            user.ConfirmPhoneNumber();

            _repository.Update(user);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
