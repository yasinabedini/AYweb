using AIPFramework.Entities;
using AYweb.Domain.Models.Academy.Entities.Configs;
using AYweb.Domain.Models.Order.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Domain.Models.Order.Entities;

[EntityTypeConfiguration(typeof(OrderLineConfig))]
public class OrderLine : Entity<long>
{
    #region Properties
    public int ProductId { get; private set; }

    public int? OrderId { get; private set; }

    public int Count { get; private set; }

    public int UnitPrice { get; private set; }

    public int SumPrice { get; private set; }

    public Product.Entities.Product Product { get; set; }

    public Order Order { get; set; }
    #endregion

    #region Constructor And Factories
    private OrderLine() { }
    public OrderLine(Product.Entities.Product product, int count, int unitPrice)
    {
        ProductId = (int)product.Id;
        Count = count;
        UnitPrice = Product.Price;
        CreateAt = DateTime.Now;
    }

    public static OrderLine Create(Product.Entities.Product product, int unitPrice, int count)
    {
        return new OrderLine(product, count, unitPrice);
    }
    #endregion

    #region Command
    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void SetOrderId(int orderId)
    {
        OrderId = orderId;
    }

    public void IncreaseProductCount(int amount)
    {
        Count += amount;
        CalculateSumPrice();
        Modified();
    }

    public void DecreaseProductCount(int amount)
    {
        Count -= amount;
        CalculateSumPrice();
        Modified();
    }

    public void UpdateUnitPrice()
    {
        UnitPrice = Product.Price;
        Modified();
    }

    public void CalculateSumPrice()
    {
        SumPrice = UnitPrice * Count;
        Modified();
    } 
    #endregion
}
