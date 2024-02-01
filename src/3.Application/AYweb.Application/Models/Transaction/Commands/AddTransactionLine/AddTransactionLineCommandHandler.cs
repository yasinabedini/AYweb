using AIPFramework.Commands;
using AYweb.Domain.Models.Transaction.Entities;
using AYweb.Domain.Models.Transaction.Repositories;

namespace AYweb.Application.Models.Transaction.Commands.AddTransactionLine
{
    public class AddTransactionLineCommandHandler : ICommandHandler<AddTransactionLineCommand>
    {
        private readonly ITransactionLineRepository _repository;

        public AddTransactionLineCommandHandler(ITransactionLineRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddTransactionLineCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(TransactionLine.Create(request.TransactionId, request.Commodity, request.Amount, request.UnitPrice));
            _repository.Save();
            
            return Task.CompletedTask;
        }
    }
}
