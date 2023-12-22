using AYweb.Dal.Entities.Order;
using AYweb.Dal.Entities.Product;
using Microsoft.AspNetCore.Http;

namespace AYweb.Core.Services.Interfaces;

public interface IOrderService
{
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    Order GetOrderById(int id);
    void AddProductToOrder(HttpContext context,Product product, int count);
    Order GetCurrentCart(HttpContext context);
    void SynchronizationCart(int userId);

    #region OrderLine
    void UpdateOrderLine(OrderLine orderLine);
    void AddOrderLine(OrderLine orderLine);
    #endregion
}