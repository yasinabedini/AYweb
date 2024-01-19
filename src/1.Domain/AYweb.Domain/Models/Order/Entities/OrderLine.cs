using AIPFramework.Entities;

namespace AYweb.Domain.Models.Order.Entities;

public class OrderLine : Entity<long>
{
    #region Properties
    public long ProductId { get; private set; }

    public long? OrderId { get; private set; }

    public int Count { get; private set; }

    public int UnitPrice { get; private set; }

    public int SumPrice { get; private set; }

    public Product.Entities.Product Product { get; set; }

    public Order Order { get; set; }
    #endregion

    #region Constructor And Factories
    private OrderLine() { }
    public OrderLine(long productId, int count, int unitPrice)
    {
        ProductId = productId;
        Count = count;
        UnitPrice = Product.Price;
        CreateAt = DateTime.Now;
    }

    public static OrderLine Create(long productId, int unitPrice, int count)
    {
        return new OrderLine(productId, count, unitPrice);
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
