using AIPFramework.Commands;
using AYweb.Application.Models.Product.Commands.DisableIsSpecial;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.IncreaseInventory
{
    public class IncreaseInventoryCommandHandler : ICommandHandler<IncreaseInventoryCommand>
    {
        private readonly IProductRepository _repository;

        public IncreaseInventoryCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(IncreaseInventoryCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.GetById(request.Id);
            product.IncreaseInventory(request.Amount);

            _repository.Update(product);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
