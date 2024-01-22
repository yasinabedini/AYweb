using AIPFramework.Commands;
using AYweb.Domain.Models.Plan.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Commands.UpdatePlan
{
    public class UpdatePlanCommandHandler : ICommandHandler<UpdatePlanCommand>
    {
        private readonly IPlanRepository _repository;

        public UpdatePlanCommandHandler(IPlanRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(request.Plan);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
