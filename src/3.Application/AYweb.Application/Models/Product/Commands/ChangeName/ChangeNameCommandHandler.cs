﻿using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeName
{
    public class ChangeNameCommandHandler : ICommandHandler<ChangeNameCommand>
    {
        private readonly IProductRepository _repository;

        public ChangeNameCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeNameCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.GetById(request.Id);
            product.ChangeName(request.Name);
            
            _repository.Update(product);
            _repository.Save();
            
            return Task.CompletedTask;
        }
    }
}
