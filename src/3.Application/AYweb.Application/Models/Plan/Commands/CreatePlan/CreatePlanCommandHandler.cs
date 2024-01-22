using AIPFramework.Commands;
using AYweb.Domain.Models.Plan.Entities;
using AYweb.Domain.Models.Plan.Enums;
using AYweb.Domain.Models.Plan.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Commands.CreatePlan
{
    public class CreatePlanCommandHandler : ICommandHandler<CreatePlanCommand>
    {
        private readonly IPlanRepository _repository;

        public CreatePlanCommandHandler(IPlanRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(Domain.Models.Plan.Entities.Plan.Create(request.Title,request.PlanType, request.Price));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
