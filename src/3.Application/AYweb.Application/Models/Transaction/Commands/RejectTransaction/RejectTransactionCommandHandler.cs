using AIPFramework.Commands;
using AYweb.Domain.Models.Order.Repositories;
using AYweb.Domain.Models.Transaction.Enums;
using AYweb.Domain.Models.Transaction.Repositories;

namespace AYweb.Application.Models.Transaction.Commands.RejectTransaction
{
    public class RejectTransactionCommandHandler : ICommandHandler<RejectTransactionCommand>
    {

        private readonly ITransactionRepository _repository;
        private readonly IOrderRepository _orderRepository;

        public RejectTransactionCommandHandler(ITransactionRepository repository, IOrderRepository orderRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
        }
        public Task Handle(RejectTransactionCommand request, CancellationToken cancellationToken)
        {
            _repository.RejectTransaction(request.Id);

            if (_repository.GetByIdWithRelations(request.Id).Type.Value == _TransactionType.PaymentOrder.ToString())
            {
                var order = _orderRepository.GetList().SingleOrDefault(t => t.TransactionId == request.Id);
                order.RejectOrder();
                _orderRepository.Update(order);
            }

            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
