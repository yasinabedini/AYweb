using AIPFramework.Commands;
using AYweb.Domain.Models.Academy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Academy.Commands.ChangeProjectCount
{
    public class ChangeProjectCountCommandHandler : ICommandHandler<ChangeProjectCountCommand>
    {
        private readonly IAcademyRepository _repository;

        public ChangeProjectCountCommandHandler(IAcademyRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeProjectCountCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeProjectCount(request.ProjectCount);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
