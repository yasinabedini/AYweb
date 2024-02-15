using AIPFramework.Commands;
using AYweb.Domain.Models.Order.Repositories;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.DecreaseProductInventory
{
    public class DecreaseProductInventoryCommandHandler : ICommandHandler<DecreaseProductInventoryCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IOrderRepository _orderRepository;

        public DecreaseProductInventoryCommandHandler(IProductRepository repository, IOrderRepository orderRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
        }

        public Task Handle(DecreaseProductInventoryCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.GetByIdWithRelations(request.OrderId);

            foreach (var orderLine in order.OrderLines)
            {
                _repository.DecreaseInventory(orderLine.ProductId, orderLine.Count);
            }
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
