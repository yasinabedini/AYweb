using AYweb.Dal.Entities.Transaction;
using AYweb.Dal.Enums;
using StackExchange.Redis;
using System.ComponentModel.DataAnnotations;

namespace AYweb.Dal.Entities.Order;

public class Order
{
    [Key]
    public int Id { get; set; }

    public User.User? User { get; set; }
    public int UserId { get; set; }
    public int? ForwardId { get; set; }
    public OrderStatus Status { get; set; }
    public int EndPrice { get; set; }
    public DateTime CreateDate { get; set; }    
    public int TransactionId { get; set; }

    public bool IsDelete { get; set; }
    public string? Notes { get; set; }    
    public bool InPersonDelivery { get; set; }

    public List<OrderLine> OrderLines { get; set; }
    public Forward? Forward { get; set; }


    public static Order CreateCart()
    {
        return new Order()
        {
            Status = new OrderStatus(_OrderStatus.Cart.ToString()),
            CreateDate = DateTime.Now,
            EndPrice = 0,
            IsDelete = false,
            OrderLines = new List<OrderLine>()
        };
    }

    public void CalculateEndPrice()
    {
        EndPrice = OrderLines.Sum(t => t.Product.GetPrice() * t.Count);
    }   

    public Transaction.Transaction RequestPayment(string transactionScreenShot,string description)
    {
        return AYweb.Dal.Entities.Transaction.Transaction.Create(EndPrice, UserId,_TransactionType.PaymentOrder, description, transactionScreenShot);
    }

}