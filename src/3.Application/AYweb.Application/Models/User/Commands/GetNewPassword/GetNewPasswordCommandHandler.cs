using AIPFramework.Commands;
using AYweb.Application.Generators;
using AYweb.Application.Security;
using AYweb.Application.Senders;
using AYweb.Domain.Models.User.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.GetNewPassword
{
    public class GetNewPasswordCommandHandler : ICommandHandler<GetNewPasswordCommand>
    {
        private readonly IUserRepository _repository;
        private ISender _sender;

        public GetNewPasswordCommandHandler(IUserRepository repository, ISender sender)
        {
            _repository = repository;
            _sender = sender;
        }

        public Task Handle(GetNewPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.GetUSerByPhoneNumber(request.PhoneNumber);
            var newPassword = Generator.GenerateDefaultPassword();
            var newHashPass = PasswordHelper.EncodePasswordMd5(newPassword);
            user.ChangePassword(newHashPass);
            _repository.Update(user);
            _repository.Save();
            Sms.SendNewPassword(user.PhoneNumber.Value, newPassword);

            return Task.CompletedTask;
        }
    }
}
