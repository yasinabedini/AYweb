using AYweb.Dal.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace AYweb.Dal.Entities.Order;

public class OrderLine
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int Count { get; set; }

    public int UnitPrice { get; set; }

    [Required]
    public int SumPrice { get; set; }


    public Order Order { get; set; }
    public Product.Product Product { get; set; }


    public static OrderLine AddOrderLine(Order order, Product.Product product, int count)
    {
        OrderLine orderLine = new OrderLine()
        {
            Product = product,
            ProductId = product.Id,
            Count = count,
            Order = order,
            OrderId = order.Id,
            UnitPrice = product.GetPrice(),
            SumPrice = product.GetPrice() * count
        };

        return orderLine;
    }

    public void IncreaseProductCount(int count)
    {
        this.Count += count;
    }
    public void CalculateSumPrice()
    {
        this.SumPrice = Count * Product.GetPrice();
    }
}