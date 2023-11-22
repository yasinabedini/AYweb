using System.ComponentModel.DataAnnotations;

namespace AYweb.Dal.Entities.Order;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int Count { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int SumPrice { get; set; }

    public int StatusId { get; set; }

    public OrderStatus Status  { get; set; }
    public List<OrderLine>? OrderLines { get; set; }
}