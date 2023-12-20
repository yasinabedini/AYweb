using AYweb.Dal.Entities.Order;
using AYweb.Dal.Entities.Product;
using Microsoft.AspNetCore.Http;

namespace AYweb.Core.Services.Interfaces;

public interface IOrderService
{
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    Order GetOrderById(int id);
    void AddProductToOrder(int orderId, Product product, int count, bool IsAuthenticated);
    Order GetCurrentCart(HttpContext context);

    #region OrderLine
    void UpdateOrderLine(OrderLine orderLine);
    #endregion
}