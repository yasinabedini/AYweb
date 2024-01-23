using AIPFramework.Commands;
using AYweb.Domain.Models.Role.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.CreateRole
{
    public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public CreateRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(Domain.Models.Role.Entities.Role.Create(request.Title));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
