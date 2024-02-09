using AIPFramework.Commands;
using AYweb.Domain.Models.Order.Repositories;
using AYweb.Domain.Models.Transaction.Enums;
using AYweb.Domain.Models.Transaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Commands.ApproveTransaction
{
    public class ApproveTransactionCommandHandler : ICommandHandler<ApproveTransactionCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITransactionRepository _repository;

        public ApproveTransactionCommandHandler(ITransactionRepository repository, IOrderRepository orderRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
        }

        public Task Handle(ApproveTransactionCommand request, CancellationToken cancellationToken)
        {
            _repository.ApproveTransaction(request.Id);
            _repository.Save();


            if (_repository.GetById(request.Id).Type.Value == _TransactionType.PaymentOrder.ToString())
            {
                var order = _orderRepository.GetList().SingleOrDefault(t => t.TransactionId == request.Id);
                if (order is not null)
                {
                    order.ApproveOrder();                    
                    _orderRepository.Update(order);
                    _orderRepository.Save();
                }
            }

            return Task.CompletedTask;
        }
    }
}
