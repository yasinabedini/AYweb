using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.Order;
using AYweb.Dal.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Core.Services;

public class OrderService : IOrderService
{
    private readonly AYWebDbContext _context;

    public OrderService(AYWebDbContext context)
    {
        _context = context;
    }

    public void AddProductToOrder(int orderId, Product product, int count)
    {
        Order order = _context.Orders.Include(t => t.OrderLines).First(t => t.Id == orderId);
        if (order.OrderLines.Select(t => t.Product).Any(t => t == product))
        {
            var orderLine = _context.OrderLines.First(t => t.ProductId == product.Id && t.OrderId == orderId);
            orderLine.IncreaseProductCount(count);
            _context.Update(orderLine);
        }
        else
        {
            _context.OrderLines.Add(new OrderLine()
            {
                ProductId = product.Id,
                OrderId = orderId,
                Count = count,
                UnitPrice = product.Price,
                SumPrice = count * product.Price
            });
        }
        _context.SaveChanges();
    }
}