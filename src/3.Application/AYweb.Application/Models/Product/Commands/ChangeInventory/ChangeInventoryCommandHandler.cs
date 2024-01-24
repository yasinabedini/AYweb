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
            _repository.ChangeInventory(request.Id, request.Inventory);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
