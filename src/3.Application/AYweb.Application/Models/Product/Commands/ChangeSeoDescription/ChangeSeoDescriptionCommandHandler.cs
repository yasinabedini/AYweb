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
            _repository.ChangeSeoDescription(request.Id, request.SeoDescription);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
