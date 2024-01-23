using AIPFramework.Commands;
using AYweb.Domain.Models.Transaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler : ICommandHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionRepository _repository;

        public DeleteTransactionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

                return Task.CompletedTask;
        }
    }
}
