using AIPFramework.Commands;
using AYweb.Application.Models.User.Commands.ConfirmEmail;
using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ChangePhoneNumber
{
    public class ChangePhoneNumberCommandHandler:ICommandHandler<ChangePhoneNumberCommand>
    {
        private readonly IUserRepository _repository;

        public ChangePhoneNumberCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangePhoneNumber(request.Id, request.PhoneNumber);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
