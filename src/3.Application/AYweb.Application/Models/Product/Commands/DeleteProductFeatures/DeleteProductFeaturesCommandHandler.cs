using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.DeleteProductFeatures
{
    public class DeleteProductFeaturesCommandHandler : ICommandHandler<DeleteProductFeaturesCommand>
    {
        private readonly IProductRepository _repository;

        public DeleteProductFeaturesCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteProductFeaturesCommand request, CancellationToken cancellationToken)
        {
            _repository.DeleteProductFeatures(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
