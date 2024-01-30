using AIPFramework.Commands;
using Microsoft.AspNetCore.Http;

namespace AYweb.Application.Models.Order.Commands.PayOrder
{
    public class PayOrderCommand:ICommand
    {
        public long Id { get; set; }
        public required string CustomerName { get; set; }
        public required string City { get; set; }
        public required string province { get; set; }
        public required string PostalCode { get; set; }
        public string? Notes { get; set; }
        public int SumPrice { get; set; }
        public int PaymentMethod { get; set; }
        public required string Address { get; set; }
        public bool InPersonDelivery { get; set; }
        public IFormFile? TransactionScreenShot { get; set; }
    }
}
