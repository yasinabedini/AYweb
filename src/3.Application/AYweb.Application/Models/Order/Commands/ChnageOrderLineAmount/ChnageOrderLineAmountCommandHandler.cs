using AIPFramework.Commands;
using AIPFramework.Session;
using AYweb.Application.Models.Order.Queries.GetCurrentUserCurrentOrder;
using AYweb.Application.Models.Order.Queries.GetOrderOrderLines;
using AYweb.Application.Models.Product.Queries.GetProduct;
using AYweb.Domain.Models.Order.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.ChnageOrderLineAmount
{
    public class ChnageOrderLineAmountCommandHandler : ICommandHandler<ChnageOrderLineAmountCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly ISender _sender;
        private readonly IHttpContextAccessor _context;
        private readonly ISessionAdaptor _session;

        public ChnageOrderLineAmountCommandHandler(IOrderRepository repository, ISender sender, IHttpContextAccessor context, ISessionAdaptor session)
        {
            _repository = repository;
            _sender = sender;
            _context = context;
            _session = session;
        }

        public Task Handle(ChnageOrderLineAmountCommand request, CancellationToken cancellationToken)
        {
            var userOrder = _sender.Send(new GetCurrentUserCurrentOrderQuery()).Result;            

            if (_context.HttpContext.User.Identity.IsAuthenticated)
            {
                var order = _repository.GetById(userOrder.Id);
                order.ChangeOrderLineAmount(request.ProductId, request.Amount);

                var orderlines = _sender.Send(new GetOrderOrderLinesQuery() { Id = order.Id }).Result;
                order.ChangeEndPrice(orderlines.Sum(t => t.SumPrice));

                _repository.Update(order);
                _repository.Save();
            }
            else
            {
                var orderLine = userOrder.OrderLines.First(t => t.ProductId == request.ProductId);                
                orderLine.Count = request.Amount;
                orderLine.SumPrice = orderLine.UnitPrice * request.Amount;
                userOrder.EndPrice = userOrder.OrderLines.Sum(t => t.SumPrice);
                _session.Remove("UserCart");
                _session.Add("UserCart", userOrder, 20000, 2000);

            }
            return Task.CompletedTask;
        }
    }
}
