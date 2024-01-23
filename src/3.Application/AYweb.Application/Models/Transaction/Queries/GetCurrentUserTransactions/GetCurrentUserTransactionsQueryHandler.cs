using AIPFramework.Queries;
using AYweb.Application.Models.Transaction.Queries.Common;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Domain.Models.Transaction.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Transaction.Queries.GetCurrentUserTransactions
{
    public class GetCurrentUserTransactionsQueryHandler : IQueryHandler<GetCurrentUserTransactionsQuery, List<TransactionResult>>
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapperAdapter _mapper;
        private readonly ISender _sender;
        public GetCurrentUserTransactionsQueryHandler(ITransactionRepository repository, IMapperAdapter mapper, ISender sender)
        {
            _repository = repository;
            _mapper = mapper;
            _sender = sender;
        }

        public Task<List<TransactionResult>> Handle(GetCurrentUserTransactionsQuery request, CancellationToken cancellationToken)
        {
            var user = _sender.Send(new GetAuthenticatedUserQuery()).Result;
            return Task.FromResult(_mapper.Map<List<Domain.Models.Transaction.Entities.Transaction>, List<TransactionResult>>(_repository.GetTransactionByUserId(user.Id)));
        }
    }
}
