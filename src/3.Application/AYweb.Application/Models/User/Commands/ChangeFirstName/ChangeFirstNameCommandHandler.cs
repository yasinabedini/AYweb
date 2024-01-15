using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ChangeFirstName
{
    public class ChangeFirstNameCommandHandler : ICommandHandler<ChangeFirstNameCommand>
    {
        private IUserRepository _repository;

        public ChangeFirstNameCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeFirstNameCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.GetById(request.Id);
            user.ChangeFirstName(request.FirstName);

            _repository.Update(user);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
