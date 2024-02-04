using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AYweb.Application.Models.User.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUserRepository _repository;

        public ChangePasswordCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {

            string hashPass = Security.PasswordHelper.EncodePasswordMd5(request.Password);
            _repository.ChangePassword(request.Id, hashPass);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
