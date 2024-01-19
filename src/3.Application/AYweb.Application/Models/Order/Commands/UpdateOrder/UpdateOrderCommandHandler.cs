using AIPFramework.Commands;
using AYweb.Domain.Models.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(request.Order);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
