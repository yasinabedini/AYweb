using AIPFramework.Commands;
using AYweb.Domain.Models.Role.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.CreateRole
{
    public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand,long>
    {
        private readonly IRoleRepository _repository;

        public CreateRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public Task<long> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = Domain.Models.Role.Entities.Role.Create(request.Title);
            _repository.Add(role);
            _repository.Save();

            return Task.FromResult(role.Id);
        }
    }
}
