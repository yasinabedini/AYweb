﻿using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Order.Entities;
using AYweb.Domain.Models.Order.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;

namespace AYweb.Infrastructure.Models.Order.Repositories;

public class OrderRepository : BaseRepository<Domain.Models.Order.Entities.Order>, IOrderRepository, IOrderLineRepository, IForwardRepository
{
    private readonly AyWebDbContext _context;
    public OrderRepository(AyWebDbContext context) : base(context)
    {
        _context = context; 
    }

    #region OrderLine
    public void Add(OrderLine entity)
    {
        _context.Add(entity);
    }

    public void Update(OrderLine entity)
    {
        _context.Update(entity);
    }

    OrderLine IRepository<OrderLine>.GetById(long id)
    {
        return _context.OrderLines.Find(id);
    }

    List<OrderLine> IRepository<OrderLine>.GetList()
    {
        return _context.OrderLines.ToList();
    }

    public List<OrderLine> GetOrderOrderLines(long orderId)
    {
        return _context.OrderLines.Where(t => t.OrderId == orderId).ToList();
    }
    #endregion

    #region Forward
    public void Add(Forward entity)
    {
        _context.Forwards.Add(entity);
    }

    public void Update(Forward entity)
    {
        _context.Forwards.Update(entity);
    }

    Forward IRepository<Forward>.GetById(long id)
    {
        return _context.Forwards.Find(id);
    }

    List<Forward> IRepository<Forward>.GetList()
    {
        return _context.Forwards.ToList();
    } 
    #endregion
}
