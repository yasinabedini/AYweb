using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeImageName
{
    internal class ChangeImageCommandHandler : ICommandHandler<ChangeImageCommand>
    {
        private readonly IProductRepository _repository;

        public ChangeImageCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeImageCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.GetById(request.Id);
            product.ChangeImageName(request.ImageName);

            _repository.Update(product);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
