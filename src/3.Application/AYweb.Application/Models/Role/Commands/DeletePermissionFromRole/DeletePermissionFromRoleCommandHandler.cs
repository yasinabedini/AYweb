using AIPFramework.Commands;
using AYweb.Domain.Models.Role.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.DeletePermissionFromRole
{
    public class DeletePermissionFromRoleCommandHandler : ICommandHandler<DeletePermissionFromRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public DeletePermissionFromRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeletePermissionFromRoleCommand request, CancellationToken cancellationToken)
        {
            _repository.DeletePermissionFromRole(request.RoleId,request.PermissionId);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
