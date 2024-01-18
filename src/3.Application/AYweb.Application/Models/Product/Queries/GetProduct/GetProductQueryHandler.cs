using AIPFramework.Queries;
using AutoMapper;
using AYweb.Application.Models.Product.Queries.Common;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Product.Queries.GetProduct
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetProductQueryHandler(IProductRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Models.Product.Entities.Product, ProductResult>(_repository.GetById(request.Id));

            return Task.FromResult(product);
        }
    }
}
