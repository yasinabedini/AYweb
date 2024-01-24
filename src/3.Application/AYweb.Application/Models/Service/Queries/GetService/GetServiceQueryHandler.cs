using AIPFramework.Queries;
using AYweb.Application.Models.Service.Queries.Common;
using AYweb.Domain.Models.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Service.Queries.GetService
{
    public class GetServiceQueryHandler : IQueryHandler<GetServiceQuery, ServiceResult>
    {
        private readonly IServiceRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetServiceQueryHandler(IServiceRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ServiceResult> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<Domain.Models.Service.Entities.Service, ServiceResult>(_repository.GetById(request.Id)));
        }
    }
}
