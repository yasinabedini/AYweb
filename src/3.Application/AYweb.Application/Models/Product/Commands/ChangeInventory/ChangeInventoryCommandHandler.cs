using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeInventory
{
    public class ChangeInventoryCommandHandler : ICommandHandler<ChangeInventoryCommand>
    {
        private readonly IProductRepository _repository;

        public ChangeInventoryCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public Task Handle(ChangeInventoryCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.GetById(request.Id);
            product.ChangeInventory(request.Inventory);

            _repository.Update(product);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
