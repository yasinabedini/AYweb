using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeMainDescription
{
    public class ChangeMainDescriptionCommandHandler : ICommandHandler<ChangeMainDescriptionCommand>
    {
        private readonly IProductRepository _repository;

        public ChangeMainDescriptionCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeMainDescriptionCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.GetById(request.Id);
            product.ChangeMainDescription(request.MainDescription);

            _repository.Update(product);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
