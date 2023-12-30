using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Core.DTOs
{
    public class PlanCheckOutViewModel
    {
        public int PaymentMethod { get; set; } = 0;
        public int Price { get; set; }
        public int PlanId { get; set; }
    }
}
