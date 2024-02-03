using AIPFramework.Commands;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Commands.RequestForPayTransaction
{
    public class RequestForPayTransactionCommand:ICommand
    {
        public long Id { get; set; }

        public IFormFile? Image { get; set; }

        public int PaymentMethod { get; set; }
    }
}
