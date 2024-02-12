using AIPFramework.Commands;
using AYweb.Domain.Models.Role.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public UpdateRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _repository.GetById(request.Id);
            role.ChangeTitle(request.Title);
            
            _repository.Update(role);
            _repository.Save();

            return Task.CompletedTask; 
        }
    }
}
