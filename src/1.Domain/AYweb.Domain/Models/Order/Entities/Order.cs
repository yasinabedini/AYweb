using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Order.ValueObjects;
using AIPFramework.Exceptions;
using AYweb.Domain.Models.Transaction.Enums;
using AYweb.Domain.Models.Order.Enums;

namespace AYweb.Domain.Models.Order.Entities;

public class Order : AggregateRoot
{
    #region Properties
    public OrderStatus OrderStatus { get; set; }


    public string? Notes { get; private set; }

    public List<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

    public int EndPrice { get; private set; }

    public bool InPersonDelivery { get; private set; }

    public long UserId { get; private set; }

    public long? ForwardId { get; private set; }

    public long TransactionId { get; private set; }

    public bool IsApproved { get; private set; }


    public User.Entities.User? User { get; private set; }
    public Forward? Forward { get; private set; }
    #endregion

    #region Constructor And Factories
    private Order()
    {
        OrderStatus = new OrderStatus(Enums._OrderStatus.completing.ToString());
        CreateAt = DateTime.Now;
    }
    public Order(long? userId, int? endPrice)
    {
        if (userId.HasValue) UserId = userId.Value;
        OrderStatus = new OrderStatus(Enums._OrderStatus.completing.ToString());
        CreateAt = DateTime.Now;
        if (endPrice.HasValue) EndPrice = endPrice.Value;
    }

    public static Order Create()
    {
        return new Order();
    }
    public static Order Create(long? userId, int? endPrice)
    {
        return new Order(userId, endPrice);
    }
    #endregion

    #region Command

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    }

    public void SetUserId(int userId)
    {
        UserId = userId;
        ModifiedAt = DateTime.Now;
    }

    public void ChangeEndPrice(int endPrice)
    {
        EndPrice = endPrice;
        Modified();
    }

    public int CalculateEndPrice()
    {
        int endPrice = 0;
        if (OrderLines.Count > 0)
        {
            endPrice = OrderLines.Sum(t => t.SumPrice);
        }
        return endPrice;
    }

    public List<OrderLine> GetOrderLines()
    {
        return OrderLines;
    }

    public OrderLine AddOrderLine(long productId, int unitPrice, int amount)
    {
        if (IsOrderlineAvailable(productId))
        {
            var orderLine = OrderLines.Single(t => t.ProductId == productId);
            orderLine.IncreaseProductCount(amount);
            EndPrice = CalculateEndPrice();

            return orderLine;
        }

        else
        {
            OrderLine orderLine = OrderLine.Create(productId, unitPrice, 0);
            orderLine.ChangeAmount(amount);
            OrderLines.Add(orderLine);
            EndPrice = CalculateEndPrice();

            return orderLine;
        }
    }

    public void SetNotes(string notes)
    {
        Notes = notes;
        Modified();
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
    }

    public void RejectOrder()
    {
        IsApproved = false;
        OrderStatus = new OrderStatus(_OrderStatus.TransactionFailed.ToString()); ;
        Delete();
    }

    public void SendOrder()
    {
        OrderStatus = new OrderStatus(_OrderStatus.Posted.ToString());
        Modified();
    }

    public void PaymentRequest(long transactionId, int paymentMethod)
    {
        TransactionId = transactionId;
        if (paymentMethod == (int)_PaymentMethod.CardByCard) OrderStatus = new ValueObjects.OrderStatus(Enums._OrderStatus.AwaitingPaymentConfirmation.ToString());
        else if (paymentMethod == (int)_PaymentMethod.PaymentGateway) OrderStatus = new ValueObjects.OrderStatus(Enums._OrderStatus.TransactionConfirmed.ToString());
        Modified();
    }

    public void MergeOrders(Order order)
    {
        foreach (var orderLine in order.OrderLines)
        {
            AddOrderLine(orderLine.ProductId, orderLine.UnitPrice, orderLine.Count);
        }
    }

    public void ChangeOrderLineAmount(long productId, int amount)
    {
        var orderline = OrderLines.First(t => t.ProductId == productId);
        orderline.ChangeAmount(amount);
        orderline.CalculateSumPrice();
    }

    public void EnableInPersonDelivery()
    {
        InPersonDelivery = true;
        Modified();
    }

    public void AddFroward(long forwardId)
    {
        if (!InPersonDelivery)
        {            
            ForwardId = forwardId;
            Modified();
        }
        else
        {
            throw new InvalidEntityStateException("Delivery For This Order Is In person. ");
        }        
    }
    #endregion
}
