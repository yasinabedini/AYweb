using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Product.Commands.AddFeature
{
    public class AddFeatureCommandHandler : ICommandHandler<AddFeatureCommand>
    {
        private readonly IFeatureRepository _repository;
        private readonly IMapperAdapter _mapper;

        public AddFeatureCommandHandler(IFeatureRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task Handle(AddFeatureCommand request, CancellationToken cancellationToken)
        {
            Feature feature = Feature.Create();
            feature = _mapper.Map<AddFeatureCommand, Feature>(request);

            _repository.Add(feature);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
