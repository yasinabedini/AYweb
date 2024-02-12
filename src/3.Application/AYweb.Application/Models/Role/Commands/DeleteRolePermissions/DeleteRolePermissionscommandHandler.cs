using AIPFramework.Commands;
using AYweb.Domain.Models.Role.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.DeleteRolePermissions
{
    public class DeleteRolePermissionscommandHandler : ICommandHandler<DeleteRolePermissionsCommand>
    {
        private readonly IRoleRepository _repository;

        public DeleteRolePermissionscommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteRolePermissionsCommand request, CancellationToken cancellationToken)
        {
            _repository.DeleteRolePermissions(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
