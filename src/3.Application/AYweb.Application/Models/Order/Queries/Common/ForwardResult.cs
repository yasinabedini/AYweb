using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Queries.Common
{
    public class ForwardResult
    {
        public long Id { get; set; }

        public required long OrderId { get;  set; }

        public required string Province { get;  set; }

        public required string City { get;  set; }

        public required string PostalCode { get;  set; }

        public required string Address { get;  set; }

        public  bool IsForward { get;  set; }

        public string? TrackingCode { get;  set; }

        public required string TransfereeName { get;  set; }
        
        public required OrderResult Order { get; set; }
    }
}
