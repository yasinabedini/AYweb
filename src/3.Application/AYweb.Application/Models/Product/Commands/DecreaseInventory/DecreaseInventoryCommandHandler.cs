using AIPFramework.Commands;
using AYweb.Application.Models.Product.Commands.ChangeShortDescription;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.DecreaseInventory
{
    public class DecreaseInventoryCommandHandler : ICommandHandler<DecreaseInventoryCommand>
    {
        private readonly IProductRepository _repository;

        public DecreaseInventoryCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DecreaseInventoryCommand request, CancellationToken cancellationToken)
        {
            _repository.DecreaseInventory(request.Id, request.Amount);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
