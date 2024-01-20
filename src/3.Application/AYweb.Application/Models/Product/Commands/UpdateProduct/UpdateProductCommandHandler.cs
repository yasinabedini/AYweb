using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler:ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(request.Product);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
