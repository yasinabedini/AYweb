using StackExchange.Redis;
using System.ComponentModel.DataAnnotations;

namespace AYweb.Dal.Entities.Order;

public class Order
{
    [Key]
    public int Id { get; set; }

    public User.User? User { get; set; }
    public int? UserId { get; set; }
    public int? ForwardId { get; set; }
    public OrderStatus Status { get; set; }
    public int EndPrice { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }

    public List<OrderLine> OrderLines { get; set; }
    public Forward? Forward { get; set; }


    public static Order CreateCart()
    {
        return new Order()
        {
            Status = new OrderStatus("Cart"),
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

    public void SendOrder(string address, string trackingCode)
    {
        Forward = new Forward()
        {
            Address = address,
            TrackingCode = trackingCode,
        };
    }
  
}