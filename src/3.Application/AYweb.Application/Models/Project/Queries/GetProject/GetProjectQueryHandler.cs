using AIPFramework.Queries;
using AYweb.Application.Models.Project.Queries.Common;
using AYweb.Domain.Models.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Project.Queries.GetProject
{
    public class GetProjectQueryHandler : IQueryHandler<GetProjectQuery, ProjectResult>
    {
        private readonly IProjectRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetProjectQueryHandler(IProjectRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ProjectResult> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = _mapper.Map<Domain.Models.Project.Entities.Project, ProjectResult>(_repository.GetById(request.Id));

            return Task.FromResult(project);
        }
    }
}
