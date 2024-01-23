using AIPFramework.Commands;
using AYweb.Domain.Models.Transaction.Repositories;

namespace AYweb.Application.Models.Transaction.Commands.RequestForPayTransaction
{
    public class RequestForPayTransactionCommandHandler : ICommandHandler<RequestForPayTransactionCommand>
    {
        private readonly ITransactionRepository _repository;

        public RequestForPayTransactionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(RequestForPayTransactionCommand request, CancellationToken cancellationToken)
        {
            _repository.RequestForPayTransaction(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
