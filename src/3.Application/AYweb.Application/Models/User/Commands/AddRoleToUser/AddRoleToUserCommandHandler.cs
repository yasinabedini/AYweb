using AIPFramework.Commands;
using AYweb.Domain.Models.Role.Repositories;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.AddRoleToUser
{
    public class AddRoleToUserCommandHandler : ICommandHandler<AddRoleToUserCommand>
    {
        private readonly IUserRepository _repository;

        public AddRoleToUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            _repository.AddRoleToUser(request.RoleId, request.UserId);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
