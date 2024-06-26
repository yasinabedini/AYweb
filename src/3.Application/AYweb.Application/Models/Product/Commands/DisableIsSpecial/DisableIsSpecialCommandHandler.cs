﻿using AIPFramework.Commands;
using AYweb.Application.Models.Product.Commands.DeleteProduct;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.DisableIsSpecial
{
    public class DisableIsSpecialCommandHandler : ICommandHandler<DisableIsSpecialCommand>
    {
        private readonly IProductRepository _repository;

        public DisableIsSpecialCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DisableIsSpecialCommand request, CancellationToken cancellationToken)
        {
            _repository.DisableIsSpecial(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
