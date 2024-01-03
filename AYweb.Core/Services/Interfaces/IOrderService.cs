using AYweb.Core.DTOs;
using AYweb.Dal.Entities.Order;
using AYweb.Dal.Entities.Product;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace AYweb.Core.Services.Interfaces;

public interface IOrderService
{
    #region Order
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    Order GetOrderById(int id);
    void AddProductToOrder(HttpContext context, Product product, int count);
    Order GetCurrentCart(HttpContext context);
    void SynchronizationCart(int userId);
    List<Order> GetOrdersByUserId(int userId);

    void OrderPayRequest(PayOrderViewModel order, IFormFile? TransactionScreenShot,bool isAuth);
    void ApproveOrder(int orderId);

    #endregion

    #region OrderLine
    void UpdateOrderLine(OrderLine orderLine);
    void AddOrderLine(OrderLine orderLine);
    void DeleteOrderLine(int productId, HttpContext context);
    void ChangeOrderLineCount(int productId, int count, HttpContext context);    
    #endregion
}