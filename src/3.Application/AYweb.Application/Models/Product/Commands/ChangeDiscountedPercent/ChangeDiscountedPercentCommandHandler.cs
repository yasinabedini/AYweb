using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeDiscountedPercent
{
    public class ChangeDiscountedPercentCommandHandler : ICommandHandler<ChangeDiscountedPercentCommand>
    {
        private readonly IProductRepository _repository;

        public ChangeDiscountedPercentCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeDiscountedPercentCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeDiscountedPercent(request.Id, request.DiscountedPercent);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
