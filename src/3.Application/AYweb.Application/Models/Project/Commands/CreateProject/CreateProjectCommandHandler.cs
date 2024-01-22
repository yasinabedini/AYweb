using AIPFramework.Commands;
using AYweb.Domain.Models.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Project.Commands.CreateProject
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public CreateProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(Domain.Models.Project.Entities.Project.Create(request.Title, request.ShortDescription, request.Description, request.ShamsiDateString, request.CustomerName, request.RelatedService, request.Link));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
