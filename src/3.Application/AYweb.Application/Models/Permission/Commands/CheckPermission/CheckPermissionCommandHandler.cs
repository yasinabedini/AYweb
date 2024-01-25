using AIPFramework.Commands;
using AYweb.Domain.Models.Permission.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Permission.Commands.CheckPermission
{
    public class CheckPermissionCommandHandler : ICommandHandler<CheckPermissionCommand, bool>
    {
        private readonly IPermissionRepository _repository;

        public CheckPermissionCommandHandler(IPermissionRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(CheckPermissionCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.CheckPermission(request.UserId, request.PermissionId));
        }
    }
}
