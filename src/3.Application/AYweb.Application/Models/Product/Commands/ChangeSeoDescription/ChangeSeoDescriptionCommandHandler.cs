using AIPFramework.Commands;
using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeSeoDescription
{
    public class ChangeSeoDescriptionCommandHandler : ICommandHandler<ChangeSeoDescriptionCommand>
    {
        private readonly IProductRepository _repository;

        public ChangeSeoDescriptionCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeSeoDescriptionCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.GetById(request.Id);
            product.ChangeSeoDescription(request.SeoDescription);

            _repository.Update(product);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
