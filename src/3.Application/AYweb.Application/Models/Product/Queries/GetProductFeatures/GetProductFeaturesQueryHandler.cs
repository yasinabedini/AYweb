using AIPFramework.Queries;
using AYweb.Application.Models.Product.Queries.Common;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Product.Queries.GetProductFeatures
{
    public class GetProductFeaturesQueryHandler : IQueryHandler<GetProductFeaturesQuery, List<FeatureResult>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetProductFeaturesQueryHandler(IProductRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<FeatureResult>> Handle(GetProductFeaturesQuery request, CancellationToken cancellationToken)
        {
            var productFeatures = _repository.GetProductFeatures(request.Id) ?? new List<Feature>();

            return Task.FromResult(_mapper.Map<List<Feature>, List<FeatureResult>>(productFeatures));
        }
    }
}
