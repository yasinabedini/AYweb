using AIPFramework.Commands;
using AYweb.Domain.Models.Transaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand>
    {
        private readonly ITransactionRepository _repository;

        public CreateTransactionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(Domain.Models.Transaction.Entities.Transaction.Create(request.UserId, request.Price, request.Type, request.PaymentMethod, request.Description, request.TransactionScreenShot));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
