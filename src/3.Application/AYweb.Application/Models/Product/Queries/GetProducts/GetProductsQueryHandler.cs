using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPFramework.Queries;
using AYweb.Application.Models.Product.Queries.Common;
using MediatR;
using AYweb.Domain.Models.Product.Repositories;
using Zamin.Extensions.ObjectMappers.Abstractions;
using AYweb.Domain.Models.Product.Entities;

namespace AYweb.Application.Models.Product.Queries.GetProducts
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, PagedData<ProductResult>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetProductsQueryHandler(IProductRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PagedData<ProductResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = _repository.GetList();
            var products = _mapper.Map<List<Domain.Models.Product.Entities.Product>, List<ProductResult>>(productList.Skip(request.SkipCount).Take(request.PageSize).ToList());

            return Task.FromResult(new PagedData<ProductResult>() { QueryResult = products, PageNumber = request.PageNumber, PageSize = request.PageSize,TotalCount = productList.Count});
        }
    }
}
