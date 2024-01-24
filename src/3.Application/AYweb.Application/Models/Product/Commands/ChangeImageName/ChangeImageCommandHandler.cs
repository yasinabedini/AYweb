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
            _repository.ChangeImageName(request.Id, request.ImageName);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
