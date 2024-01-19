using AIPFramework.Commands;
using AYweb.Domain.Models.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.UpdateOrderLine
{
    public class UpdateOrderLineCommandHandler : ICommandHandler<UpdateOrderLineCommand>
    {
        private readonly IOrderLineRepository _repository;

        public UpdateOrderLineCommandHandler(IOrderLineRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateOrderLineCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(request.OrderLine);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
