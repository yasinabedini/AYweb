using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Core.DTOs
{
    public class PayOrderViewModel
    {
        public int Id { get; set; }        
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string province { get; set; }
        public string PostalCode { get; set; }
        public string Notes { get; set; }
        public int SumPrice { get; set; }
        public int PaymentMethod { get; set; }
        public string Address { get; set; }
        public bool InPersonDelivery { get; set; }
    }
}
