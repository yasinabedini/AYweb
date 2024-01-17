using AIPFramework.Commands;
using AYweb.Application.Models.Product.Commands.DecreaseInventory;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.GetById(request.Id);
            product.DeleteProduct();

            _repository.Update(product);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
