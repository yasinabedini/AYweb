using AIPFramework.Commands;
using AYweb.Domain.Models.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.SendOrder
{
    public class SendOrderCommandHandler : ICommandHandler<SendOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public SendOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(SendOrderCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.TrackingCode))
            {
                _repository.SendOrder(request.OrderId, request.TrackingCode);                
            }
            else
            {
                var order = _repository.GetById(request.OrderId);
                order.SendOrder();
                _repository.Update(order);
            }

            _repository.Save();
            return Task.CompletedTask;
        }
    }
}
