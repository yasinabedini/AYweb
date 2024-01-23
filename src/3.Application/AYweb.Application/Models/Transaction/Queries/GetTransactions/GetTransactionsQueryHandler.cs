using AIPFramework.Queries;
using AYweb.Application.Models.Transaction.Queries.Common;
using AYweb.Domain.Models.Transaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Transaction.Queries.GetTransactions
{
    public class GetTransactionsQueryHandler : IQueryHandler<GetTransactionsQuery, PagedData<TransactionResult>>
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetTransactionsQueryHandler(ITransactionRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PagedData<TransactionResult>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = _repository.GetList();

            var transactionList = _mapper.Map<List<Domain.Models.Transaction.Entities.Transaction>, List<TransactionResult>>(transactions.Skip(request.SkipCount).Take(request.PageSize).ToList());

            return Task.FromResult(new PagedData<TransactionResult> { QueryResult = transactionList, PageNumber = request.PageNumber, PageSize = request.PageSize, TotalCount = transactions.Count });
        }
    }
}
