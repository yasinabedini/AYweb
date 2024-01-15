using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.SetEmail
{
    public class SetEmailCommandHandler : ICommandHandler<SetEmailCommand>
    {
        private readonly IUserRepository _repository;

        public SetEmailCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(SetEmailCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.GetById(request.Id);
            user.SetEmail(request.Email);

            _repository.Update(user);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
