using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IMapperAdapter _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.Product.Entities.Product product = Domain.Models.Product.Entities.Product.Create();  
            product = _mapper.Map<CreateProductCommand, Domain.Models.Product.Entities.Product>(request);

            _repository.Add(product);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
