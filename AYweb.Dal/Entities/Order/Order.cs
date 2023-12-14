using System.ComponentModel.DataAnnotations;

namespace AYweb.Dal.Entities.Order;

public class Order
{
    [Key]
    public int Id { get; set; }

    public User.User User { get; set; }
    public int UserId { get; set; }
    public int ForwardId { get; set; }
    public OrderStatus Status { get; set; }

    public List<OrderLine>? OrderLines { get; set; }
    public Forward Forward { get; set; }



    

    public void SendOrder(string address, string trackingCode)
    {
        Forward = new Forward()
        {
            Address = address,
            TrackingCode = trackingCode,
        };
    }
}