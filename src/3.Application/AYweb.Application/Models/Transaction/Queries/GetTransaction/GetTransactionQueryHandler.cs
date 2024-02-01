using AIPFramework.Queries;
using AYweb.Application.Models.Transaction.Queries.Common;
using AYweb.Domain.Models.Transaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Transaction.Queries.GetTransaction
{
    public class GetTransactionQueryHandler : IQueryHandler<GetTransactionQuery, TransactionResult>
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetTransactionQueryHandler(ITransactionRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<TransactionResult> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<Domain.Models.Transaction.Entities.Transaction, TransactionResult>(_repository.GetByIdWithRelations(request.Id)));
        }
    }
}
