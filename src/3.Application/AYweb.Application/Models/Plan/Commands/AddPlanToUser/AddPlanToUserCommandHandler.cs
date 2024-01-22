using AIPFramework.Commands;
using AYweb.Domain.Models.Plan.Repositories;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Commands.AddPlanToUser
{
    public class AddPlanToUserCommandHandler : ICommandHandler<AddPlanToUserCommand>
    {
        private readonly IUserRepository _repository;        

        public AddPlanToUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddPlanToUserCommand request, CancellationToken cancellationToken)
        {
            _repository.AddPlanToUser(Domain.Models.User.Entities.User_Plans.Create(request.UserId,request.PlanId,request.TransactionId));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
