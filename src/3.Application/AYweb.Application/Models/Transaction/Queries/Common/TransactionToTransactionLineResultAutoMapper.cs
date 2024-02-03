using AutoMapper;
using AYweb.Domain.Models.Transaction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Queries.Common
{
    public class TransactionToTransactionLineResultAutoMapper : Profile
    {
        public TransactionToTransactionLineResultAutoMapper()
        {
            CreateMap<TransactionLine, TransactionLineResult>().ReverseMap();
        }
    }
}
