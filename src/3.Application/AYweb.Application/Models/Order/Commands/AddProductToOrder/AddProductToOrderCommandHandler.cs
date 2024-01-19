using AIPFramework.Commands;
using AIPFramework.Session;
using AYweb.Application.Models.Order.Commands.UpdateOrder;
using AYweb.Application.Models.Order.Commands.UpdateOrderLine;
using AYweb.Application.Models.Product.Queries.GetProduct;
using AYweb.Application.Models.User.Queries.GetAllUserQuery;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Domain.Models.Order.Entities;
using AYweb.Domain.Models.Order.Repositories;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Domain.Models.User.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace AYweb.Application.Models.Order.Commands.AddProductToOrder
{
    public class AddProductToOrderCommandHandler : ICommandHandler<AddProductToOrderCommand>
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly ISender _sender;
        private readonly ISessionAdaptor _session;       

        public AddProductToOrderCommandHandler(IHttpContextAccessor httpContext, ISender sender, ISessionAdaptor session)
        {
            _httpContext = httpContext;            
            _sender = sender;
            _session = session;
        }

        public Task Handle(AddProductToOrderCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.Order.Entities.Order order;

            var product = _sender.Send(new GetProductQuery { Id = request.ProductId }).Result;

            //If User Is Authenticated
            if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = _sender.Send(new GetAuthenticatedUserQuery()).Result;


                //If User Has One Active Cart  
                if (user.HasActiveOrder())
                {
                    order = user.GetUserOrderWithCompletingStatus();
                }

                //If user has not any active order
                else
                {
                    order = Domain.Models.Order.Entities.Order.Create(user.Id);
                }

                var orderline = order.AddOrderLine(product.Id, product.Price, request.Amount);

                _sender.Send(new UpdateOrderLineCommand { OrderLine = orderline });

                _sender.Send(new UpdateOrderCommand { Order = order });              
            }

            //If User Is Not Authenticated
            else
            {
                order = _session.Get<Domain.Models.Order.Entities.Order>("UserCart");

                //If User not authenticated has active order
                if (order != null)
                {
                    _session.Remove("UserCart");
                }


                //If User not authenticated has not any active order
                else
                {
                    order = Domain.Models.Order.Entities.Order.Create();
                }

                order.AddOrderLine(product.Id, product.Price, request.Amount);

                _session.Add("UserCart", JsonSerializer.Serialize(order), 10800, 10800);
            }

            return Task.CompletedTask;
        }
    }
}