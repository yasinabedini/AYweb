using AIPFramework.Commands;
using AYweb.Domain.Models.Academy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Academy.Commands.ChnageTeamCount
{
    public class ChnageTeamCountCommandHandler : ICommandHandler<ChnageTeamCountCommand>
    {
        private readonly IAcademyRepository _repository;

        public ChnageTeamCountCommandHandler(IAcademyRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChnageTeamCountCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeTeamCount(request.TeamCount);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
