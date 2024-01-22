using AIPFramework.Commands;
using AYweb.Domain.Models.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Project.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : ICommandHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public UpdateProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(request.Project);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
