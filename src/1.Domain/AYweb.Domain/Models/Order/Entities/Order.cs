using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Order.ValueObjects;
using AIPFramework.Exceptions;

namespace AYweb.Domain.Models.Order.Entities;

public class Order : AggregateRoot
{
    #region Properties
    public OrderStatus OrderStatus { get; set; }

    public int EndPrice { get; private set; }

    public Description Notes { get; private set; }

    public List<OrderLine> OrderLines { get; private set; }

    public bool InPersonDelivery { get; private set; }

    public long UserId { get; private set; }

    public int? ForwardId { get; private set; }

    public int TransactionId { get; private set; }

    public bool IsApproved { get; private set; }
    

    public User.Entities.User? User { get;private set; }
    public Forward? Forward { get;private set; }
    #endregion

    #region Constructor And Factories
    private Order() { }
    public Order(long? userId)
    {
        OrderLines = new List<OrderLine>();
        if (userId.HasValue) UserId = userId.Value;
        EndPrice = 0;
        OrderStatus = new OrderStatus(Enums._OrderStatus.completing.ToString());
        CreateAt = DateTime.Now;
    }

    public static Order Create()
    {
        return new Order();
    }
    public static Order Create(long? userId)
    {
        return new Order(userId);
    }
    #endregion

    #region Command

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void SetUserId(int userId)
    {
        UserId = userId;
        ModifiedAt = DateTime.Now;
    }

    public void CalculateEndPrice()
    {
        if (OrderLines.Count > 0)
        {
            EndPrice = OrderLines.Sum(t => t.SumPrice);
            Modified();
        }
    }

    public List<OrderLine> GetOrderLines()
    {
        return OrderLines;
    }

    public OrderLine AddOrderLine(long productId,int unitPrice,int amount)
    {
        if (IsOrderlineAvailable(productId))
        {
            var orderLine = OrderLines.Single(t => t.ProductId == productId);                        
            orderLine.IncreaseProductCount(amount);
            CalculateEndPrice();

            return orderLine;
        }

        else
        {
            OrderLine orderLine = OrderLine.Create(productId, unitPrice,amount);
            OrderLines.Add(orderLine);
            CalculateEndPrice();

            return orderLine;
        }
    }

    public bool IsOrderlineAvailable(long productId)
    {
        if (OrderLines.Any(t => t.ProductId == productId)) return true;
        return false;
    }

    public void ApproveOrder()
    {
        IsApproved = true;
        OrderStatus = new ValueObjects.OrderStatus(Enums._OrderStatus.Packing.ToString());
        Modified();
    }

    public void FailedOrder()
    {
        OrderStatus = new ValueObjects.OrderStatus(Enums._OrderStatus.TransactionFailed.ToString());
        Modified();
    }

    public void PaymentRequest(int transactionId)
    {
        TransactionId = transactionId;
        OrderStatus = new ValueObjects.OrderStatus(Enums._OrderStatus.AwaitingPaymentConfirmation.ToString());
        Modified();
    }

    public void MergeOrders(Order order)
    {
        foreach (var orderLine in order.OrderLines)
        {
            AddOrderLine(orderLine.ProductId,orderLine.UnitPrice,orderLine.Count);
        }
    }

    public void EnableInPersonDelivery()
    {
        InPersonDelivery = true;
        Modified();
    }

    public Forward AddFroward(Forward forward)
    {
        if (!InPersonDelivery)
        {
            OrderStatus = new OrderStatus(Enums._OrderStatus.Posted.ToString());
            forward.SetOrderId((int)Id);
            ForwardId = (int)forward.Id;
            Modified();
        }
        else
        {
            throw new InvalidEntityStateException("Delivery For This Order Is In person. ");
        }
        return forward;
    }
    #endregion
}
