using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.DeleteAllUserRoles
{
    public class DeleteAllUserRolesCommandHandler : ICommandHandler<DeleteAllUserRolesCommand>
    {
        private readonly IUserRepository _repository;

        public DeleteAllUserRolesCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteAllUserRolesCommand request, CancellationToken cancellationToken)
        {
            _repository.DeleteAllUserRoles(request.UserId);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
