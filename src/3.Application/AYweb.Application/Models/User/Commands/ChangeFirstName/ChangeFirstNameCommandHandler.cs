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
           _repository.ChangeFirstName(request.Id,request.FirstName);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
