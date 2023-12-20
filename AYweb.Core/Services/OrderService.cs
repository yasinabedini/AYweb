using AYweb.Core.Serializer;
using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.Order;
using AYweb.Dal.Entities.Product;
using AYweb.Dal.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Polly;

namespace AYweb.Core.Services;

public class OrderService : IOrderService
{
    private readonly AYWebDbContext _context;
    private readonly IPermissionService _permissionService;
    private readonly IDistributedCache _cache;

    public OrderService(AYWebDbContext context, IPermissionService permissionService, IDistributedCache cache)
    {
        _context = context;
        _permissionService = permissionService;
        _cache = cache;
    }

    public void AddOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void AddProductToOrder(int orderId, Product product, int count, bool IsAuthenticated)
    {
        if (IsAuthenticated)
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
        else
        {
            Order order = GetOrderById(orderId);

            if (order.OrderLines.Select(t => t.Product).Any(t => t == product))
            {
                var orderLine = _context.OrderLines.First(t => t.ProductId == product.Id && t.OrderId == orderId);
                orderLine.Count += count;
                orderLine.SumPrice = product.Price * (orderLine.Count += count);
                UpdateOrderLine(orderLine);
            }
            else
            {
                order.OrderLines.Add(new OrderLine()
                {
                    ProductId = product.Id,
                    OrderId = orderId,
                    Count = count,
                    UnitPrice = product.Price,
                    SumPrice = count * product.Price
                });
            }
            _context.Orders.Update(order);
            _context.SaveChanges();
            _cache.Remove("UserCart");
            string updateOrderString = JsonConvert.SerializeObject(order, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            _cache.SetString("UserCart", updateOrderString, new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddDays(20),
                SlidingExpiration = TimeSpan.FromDays(20)
            });
        }
    }

    public Order GetCurrentCart(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            int userId = _permissionService.GetAuthonticatedUserUserId(context);
            return _context.Orders.Include(t=>t.OrderLines).ThenInclude(t=>t.Product).Where(t => t.UserId == userId && t.Status == new OrderStatus("Cart")).FirstOrDefault();
        }
        else
        {
            string orderString = _cache.GetString("UserCart") ?? "";
            Order order = JsonConvert.DeserializeObject<Order>(orderString);            
            if (order is not null)
            {
                return order;
            }
            else
            {
                return null;
            }
        }
    }

    public Order GetOrderById(int id)
    {
        return _context.Orders.Include(t => t.OrderLines).First(t => t.Id == id);
    }

    public void UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
        _context.SaveChanges();
    }

    public void UpdateOrderLine(OrderLine orderLine)
    {
        _context.OrderLines.Update(orderLine);
        _context.SaveChanges();
    }
}
