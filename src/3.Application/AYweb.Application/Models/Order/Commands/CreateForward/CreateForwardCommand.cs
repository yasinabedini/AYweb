using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.CreateForward
{
    public class CreateForwardCommand:ICommand<long>
    {
        public required long OrderId { get;  set; }

        public required string Province { get;  set; }

        public required string City { get;  set; }

        public required string PostalCode { get;  set; }

        public required string Address { get;  set; }                

        public required string TransfereeName { get;  set; }
    }
}
