using AIPFramework.Commands;
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

        private readonly ITransactionRepository _repository;

        public ApproveTransactionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ApproveTransactionCommand request, CancellationToken cancellationToken)
        {
            _repository.ApproveTransaction(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
