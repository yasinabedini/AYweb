using Abp.Extensions;
using AIPFramework.Queries;
using AIPFramework.Session;
using AutoMapper;
using AYweb.Application.Models.Order.Queries.Common;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Application.Models.User.Queries.GetUser;
using AYweb.Domain.Models.Order.Entities;
using AYweb.Domain.Models.User.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Queries.GetCurrentUserCurrentOrder
{
    public class GetCurrentUserCurrentOrderQueryHandler : IQueryHandler<GetCurrentUserCurrentOrderQuery, OrderResult>
    {
        private readonly ISender _Sender;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpcontext;
        private readonly ISessionAdaptor _session;
        private readonly IUserRepository _userRepository;

        public GetCurrentUserCurrentOrderQueryHandler(ISender sender, IMapper mapper, IHttpContextAccessor httpcontext, ISessionAdaptor session, IUserRepository userRepository)
        {
            _Sender = sender;
            _mapper = mapper;
            _httpcontext = httpcontext;
            _session = session;
            _userRepository = userRepository;
        }

        public Task<OrderResult> Handle(GetCurrentUserCurrentOrderQuery request, CancellationToken cancellationToken)
        {
            Domain.Models.Order.Entities.Order? order = null;

            if (_httpcontext.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = _Sender.Send(new GetAuthenticatedUserQuery()).Result;
                var userFound = _userRepository.GetByIdWithGraph(user.Id);

                order = userFound.GetUserOrderWithCompletingStatus() ;
            }
            else
            {
                order = _session.Get<Domain.Models.Order.Entities.Order>("UserCart");
            }

            return Task.FromResult(_mapper.Map<Domain.Models.Order.Entities.Order, OrderResult>(order));

        }
    }
}
