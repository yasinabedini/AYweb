using AIPFramework.Queries;
using AYweb.Domain.Models.Academy.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Academy.Queries.GetAcademy
{
    public class GetAcademyQueryHandler : IQueryHandler<GetAcademyQuery, AcademyResult>
    {
        private readonly IAcademyRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetAcademyQueryHandler(IAcademyRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<AcademyResult> Handle(GetAcademyQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<Domain.Models.Academy.Entities.Academy, AcademyResult>(_repository.Get()));
        }
    }
}
