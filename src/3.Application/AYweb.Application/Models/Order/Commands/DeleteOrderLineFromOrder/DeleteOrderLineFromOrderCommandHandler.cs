using AIPFramework.Commands;
using AIPFramework.Session;
using AYweb.Application.Models.Order.Queries.GetCurrentUserCurrentOrder;
using AYweb.Application.Models.Order.Queries.GetOrderOrderLines;
using AYweb.Domain.Models.Order.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.DeleteOrderLineFromOrder
{
    public class DeleteOrderLineFromOrderCommandHandler : ICommandHandler<DeleteOrderLineFromOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly ISender _sender;
        private readonly ISessionAdaptor _session;

        public DeleteOrderLineFromOrderCommandHandler(IOrderRepository orderRepository, IOrderLineRepository orderLineRepository, IHttpContextAccessor accessor, ISender sender, ISessionAdaptor session)
        {
            _orderRepository = orderRepository;
            _orderLineRepository = orderLineRepository;
            _accessor = accessor;
            _sender = sender;
            _session = session;
        }

        public Task Handle(DeleteOrderLineFromOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _sender.Send(new GetCurrentUserCurrentOrderQuery()).Result;

            if (_accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var orderLine = _orderLineRepository.GetById(order.OrderLines.SingleOrDefault(t => t.ProductId == request.productId).Id);
                orderLine.Delete();
                _orderLineRepository.Update(orderLine);
                _orderLineRepository.Save();

                var mainOrder = _orderRepository.GetByIdWithRelations(orderLine.OrderId.Value);
                mainOrder.OrderLines.Remove(orderLine);
                mainOrder.ChangeEndPrice(mainOrder.CalculateEndPrice());

                if (mainOrder.OrderLines.Count <= 0)
                {
                    mainOrder.Delete();
                }

                _orderRepository.Update(mainOrder);
                _orderRepository.Save();
            }
            else
            {
                var orderline = order.OrderLines.SingleOrDefault(t => t.ProductId == request.productId);
                order.OrderLines.Remove(orderline);
                order.EndPrice = order.OrderLines.Sum(t => t.UnitPrice * t.Count);

                _session.Remove("UserCart");

                if (order.OrderLines.Count > 0)
                {
                    _session.Add("UserCart", order, 20000, 2000);
                }
            }

            return Task.CompletedTask;
        }
    }
}
