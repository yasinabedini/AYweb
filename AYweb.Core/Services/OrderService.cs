﻿using AYweb.Core.Caching;
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
    private readonly ICacheAdaptor _cache;

    public OrderService(AYWebDbContext context, IPermissionService permissionService, ICacheAdaptor cache)
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

    public void AddOrderLine(OrderLine orderLine)
    {
        _context.OrderLines.Add(orderLine);
        _context.SaveChanges();
    }

    public void AddProductToOrder(HttpContext context, Product product, int count)
    {
        Order order = GetCurrentCart(context);

        //Auth User 
        if (context.User.Identity.IsAuthenticated)
        {
            User user = _permissionService.GetAuthonticatedUser(context);

            //If Order Is Null Should Create In DataBase For Auth User
            if (order is null)
            {
                order = Order.CreateCart();
                order.UserId = user.UserId;
                AddOrder(order);
            }

            //If the product is already in the shopping cart
            if (order.OrderLines.Any(t => t.ProductId == product.Id))
            {
                OrderLine orderLine = order.OrderLines.First(t => t.ProductId == product.Id);
                orderLine.IncreaseProductCount(count);
                orderLine.CalculateSumPrice();
            }

            //If the product is not already in the shopping cart
            else
            {
                OrderLine newOrderLine = OrderLine.AddOrderLine(order, product, count);
                AddOrderLine(newOrderLine);
            }

            order.CalculateEndPrice();
            UpdateOrder(order);
        }

        //Unknow User
        else
        {

            if (order is null)
            {
                order = Order.CreateCart();
            }

            if (order.OrderLines.Any(t => t.ProductId == product.Id))
            {
                OrderLine orderLine = order.OrderLines.First(t => t.ProductId == product.Id);
                orderLine.IncreaseProductCount(count);
                orderLine.CalculateSumPrice();
            }

            //If the product is not already in the shopping cart
            else
            {
                OrderLine newOrderLine = OrderLine.AddOrderLine(order, product, count);
                order.OrderLines.Add(newOrderLine);
            }
            order.CalculateEndPrice();

            _cache.Remove("UserCart");
            _cache.Add("UserCart", order, 28800, 21600);

        }
    }

    public Order GetCurrentCart(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            int userId = _permissionService.GetAuthonticatedUserUserId(context);
            return _context.Orders.Include(t => t.OrderLines).ThenInclude(t => t.Product).Include(t => t.Status).Include(t => t.User).FirstOrDefault(t => t.UserId == userId && t.Status.Status == "Cart");
        }
        else
        {
            Order order = _cache.Get<Order>("UserCart");
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
        return _context.Orders.Include(t => t.OrderLines).ThenInclude(t => t.Product).First(t => t.Id == id);
    }

    public void SynchronizationCart(int userId)
    {
        Order orderCache = _cache.Get<Order>("UserCart");
        if (orderCache is not null)
        {
            Order authUserCart = _context.Orders.Include(t=>t.OrderLines).ThenInclude(t=>t.Product).Include(t=>t.User).FirstOrDefault(t => t.UserId == userId && t.Status.Status == "Cart");

            //If Auth User Has A Cart
            if (authUserCart is not null)
            {
                foreach (var orderLine in orderCache.OrderLines)
                {
                    //If the product is already in the shopping cart
                    if (authUserCart.OrderLines.Any(t => t.ProductId == orderLine.ProductId))
                    {
                        var orderLineFound = authUserCart.OrderLines.First(t => t.ProductId == orderLine.ProductId);
                        orderLineFound.IncreaseProductCount(orderLine.Count);
                        orderLineFound.CalculateSumPrice();
                        UpdateOrderLine(orderLineFound);
                    }

                    //If the product is not already in the shopping cart
                    else
                    {
                        OrderLine newOrderLine = OrderLine.AddOrderLine(authUserCart, orderLine.Product, orderLine.Count);
                        AddOrderLine(newOrderLine);
                    }

                    authUserCart.CalculateEndPrice();
                    UpdateOrder(authUserCart);
                }
            }

            //If Auth User Does'nt Have Any Cart
            else
            {
                authUserCart = Order.CreateCart();
                authUserCart.CreateDate = orderCache.CreateDate;
                AddOrder(authUserCart);

                foreach (var orderLine in orderCache.OrderLines)
                {                    
                    OrderLine newOrderLine = OrderLine.AddOrderLine(authUserCart, orderLine.Product, orderLine.Count);
                    AddOrderLine(newOrderLine);

                    authUserCart.CalculateEndPrice();
                    UpdateOrder(authUserCart);
                }
            }

            _cache.Remove("UserCart");
        }
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
