using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.SendOrder
{
    public class SendOrderCommand:ICommand
    {
        public long OrderId { get; set; }
        public required string TrackingCode { get; set; }
    }
}
