using AIPFramework.Commands;
using AYweb.Domain.Models.Transaction.Repositories;

namespace AYweb.Application.Models.Transaction.Commands.RejectTransaction
{
    public class RejectTransactionCommandHandler : ICommandHandler<RejectTransactionCommand>
    {

        private readonly ITransactionRepository _repository;

        public RejectTransactionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }
        public Task Handle(RejectTransactionCommand request, CancellationToken cancellationToken)
        {
            _repository.RejectTransaction(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
