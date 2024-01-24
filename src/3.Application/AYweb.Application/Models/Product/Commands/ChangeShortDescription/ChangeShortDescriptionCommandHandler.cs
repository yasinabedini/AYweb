using AIPFramework.Commands;
using AYweb.Application.Models.Product.Commands.ChangeSeoDescription;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeShortDescription
{
    public class ChangeShortDescriptionCommandHandler : ICommandHandler<ChangeShortDescriptionCommand>
    {
        private readonly IProductRepository _repository;

        public ChangeShortDescriptionCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeShortDescriptionCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeShortDescription(request.Id, request.ShortDescription);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
