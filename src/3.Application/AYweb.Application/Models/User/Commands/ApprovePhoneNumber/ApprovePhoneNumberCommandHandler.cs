using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ApprovePhoneNumber
{
    public class ApprovePhoneNumberCommandHandler : ICommandHandler<ApprovePhoneNumberCommand>
    {
        private readonly IUserRepository _repository;

        public ApprovePhoneNumberCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ApprovePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.GetUSerByPhoneNumber(request.PhoneNumber);
            user.ConfirmPhoneNumber();

            _repository.Update(user);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
