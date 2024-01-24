using AIPFramework.Queries;
using AYweb.Application.Models.Service.Queries.Common;
using AYweb.Application.Models.Service.Queries.GetService;
using AYweb.Domain.Models.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Service.Queries.GetServices
{
    public class GetServicesQueryHandler : IQueryHandler<GetServicesQuery, List<ServiceResult>>
    {
        private readonly IServiceRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetServicesQueryHandler(IServiceRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<ServiceResult>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<Domain.Models.Service.Entities.Service>, List<ServiceResult>>(_repository.GetList()));
        }
    }
}
