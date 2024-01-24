using AIPFramework.Commands;
using AYweb.Domain.Models.Academy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Academy.Commands.ChnageName
{
    public class ChangeNameCommandHandler : ICommandHandler<ChangeNameCommand>
    {
        private readonly IAcademyRepository _repository;

        public ChangeNameCommandHandler(IAcademyRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeNameCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeName(request.Name);
            _repository.Save();

                return Task.CompletedTask;
        }
    }
}
