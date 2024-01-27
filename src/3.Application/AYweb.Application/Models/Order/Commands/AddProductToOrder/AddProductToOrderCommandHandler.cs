using AIPFramework.Commands;
using AIPFramework.Serializer;
using AIPFramework.Session;
using AYweb.Application.Models.Order.Commands.CreateOrder;
using AYweb.Application.Models.Order.Commands.UpdateOrder;
using AYweb.Application.Models.Order.Commands.UpdateOrderLine;
using AYweb.Application.Models.Product.Queries.GetProduct;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Application.Models.User.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Http; 
using System.Text.Json;


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
                var userFound = _sender.Send(new GetUserQuery { Id = user.Id }).Result;

                //If User Has One Active Cart  
                if (userFound.HasActiveOrder())
                {
                    order = userFound.GetUserOrderWithCompletingStatus();
                }

                //If user has not any active order
                else
                {
                    order = _sender.Send(new CreateOrderCommand { UserId = user.Id }).Result;
                    
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
                if (order is not null)
                {
                    _session.Remove("UserCart");
                }


                //If User not authenticated has not any active order
                else
                {
                    order = Domain.Models.Order.Entities.Order.Create();
                }

                order.AddOrderLine(product.Id, product.Price, request.Amount);
                order.ChangeEndPrice(order.CalculateEndPrice());

                _session.Add("UserCart", order, 10800, 10800);
            }

            return Task.CompletedTask;
        }
    }
}