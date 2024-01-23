using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Queries.Common
{
    public class TransactionToTransactionResultAutoMapper : Profile
    {
        public TransactionToTransactionResultAutoMapper()
        {
            CreateMap<Domain.Models.Transaction.Entities.Transaction, TransactionResult>().ReverseMap();
        }
    }
}
