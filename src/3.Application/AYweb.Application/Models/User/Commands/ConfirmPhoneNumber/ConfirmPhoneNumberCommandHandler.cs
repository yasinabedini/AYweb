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
    public class ConfirmPhoneNumberCommandHandler : ICommandHandler<ConfirmPhoneNumberCommand,bool>
    {
        private readonly IUserRepository _repository;

        public ConfirmPhoneNumberCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(ConfirmPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            bool isSuccess = false;
            if (request.Code == request.VereficationCode)
            {
                _repository.ConfirmPhoneNumber(request.PhoneNumber);
                _repository.Save();
                isSuccess = true;
            }


            return Task.FromResult(isSuccess);
        }
    }
}
