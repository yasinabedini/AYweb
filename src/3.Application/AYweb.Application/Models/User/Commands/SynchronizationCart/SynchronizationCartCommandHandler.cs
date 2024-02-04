using Abp.Runtime.Caching;
using AIPFramework.Commands;
using AIPFramework.Session;
using AYweb.Application.Models.Order.Queries.GetCurrentUserCurrentOrder;
using AYweb.Application.Models.Order.Queries.GetOrderOrderLines;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Domain.Models.Order.Entities;
using AYweb.Domain.Models.Order.Enums;
using AYweb.Domain.Models.Order.Repositories;
using AYweb.Domain.Models.User.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.SynchronizationCart
{
    public class SynchronizationCartCommandHandler : ICommandHandler<SynchronizationCartCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly ISessionAdaptor _session;
        private readonly ISender _sender;

        public SynchronizationCartCommandHandler(IOrderRepository orderRepository, ISessionAdaptor session, ISender sender, IOrderLineRepository orderLineRepository)
        {
            _orderRepository = orderRepository;
            _session = session;
            _sender = sender;
            _orderLineRepository = orderLineRepository;
        }

        public Task Handle(SynchronizationCartCommand request, CancellationToken cancellationToken)
        {
            var orderCache = _session.Get<Domain.Models.Order.Entities.Order>("UserCart");

            if (orderCache is not null)
            {
                var currentUser = _sender.Send(new GetAuthenticatedUserQuery()).Result;

                var currentUserCart = _orderRepository.GetOrdersByUserId(currentUser.Id).SingleOrDefault(t=>t.OrderStatus.Value==_OrderStatus.completing.ToString());


                //If Auth User Has A Cart
                if (currentUserCart is not null)
                {
                    foreach (var orderLine in orderCache.OrderLines)
                    {
                        //If the product is already in the shopping cart
                        if (currentUserCart.OrderLines.Any(t => t.ProductId == orderLine.ProductId))
                        {
                            var orderLineFound = _orderLineRepository.GetOrderOrderLines(currentUserCart.Id).First(t => t.ProductId == orderLine.ProductId);
                            orderLineFound.IncreaseProductCount(orderLine.Count);
                            orderLineFound.CalculateSumPrice();
                            _orderLineRepository.Update(orderLineFound);
                            _orderLineRepository.Save();
                        }

                        //If the product is not already in the shopping cart
                        else
                        {
                            var newOrderLine = OrderLine.Create(orderLine.ProductId, orderLine.UnitPrice, orderLine.Count);
                            newOrderLine.SetOrderId( currentUserCart.Id);
                            _orderLineRepository.Add(newOrderLine);                            
                        }
                        _orderLineRepository.Save();

                        currentUserCart.ChangeEndPrice(currentUserCart.OrderLines.Sum(t=>t.SumPrice));
                        _orderRepository.Update(currentUserCart);
                        _orderRepository.Save();
                    }
                }

                //If Auth User Does'nt Have Any Cart
                else
                {
                    var userOrder = Domain.Models.Order.Entities.Order.Create(currentUser.Id, orderCache.EndPrice);
                  
                    _orderRepository.Add(userOrder);
                    _orderRepository.Save();

                    userOrder.MergeOrders(orderCache);
                    _orderRepository.Update(userOrder);
                    _orderRepository.Save();
                }

                _session.Remove("UserCart");
            }

            return Task.CompletedTask;
        }
    }
}
