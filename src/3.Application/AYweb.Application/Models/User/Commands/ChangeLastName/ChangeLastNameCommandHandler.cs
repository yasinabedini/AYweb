using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ChangeLastName
{
    public class ChangeLastNameCommandHandler : ICommandHandler<ChangeLastNameCommand>
    {
        private readonly IUserRepository _repository;

        public ChangeLastNameCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeLastNameCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeLastName(request.Id, request.LastName);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
