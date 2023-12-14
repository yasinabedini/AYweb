using AYweb.Dal.Entities.Product;

namespace AYweb.Core.Services.Interfaces;

public interface IOrderService
{
    void AddProductToOrder(int orderId, Product product, int count);
}