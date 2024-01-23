using AIPFramework.Commands;
using AYweb.Domain.Models.Role.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.AddPermissionToRole
{
    public class AddPermissionToRoleCommandHandler : ICommandHandler<AddPermissionToRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public AddPermissionToRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddPermissionToRoleCommand request, CancellationToken cancellationToken)
        {
            _repository.AddPermissionToRole(request.RoleId, request.PermissionId);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
