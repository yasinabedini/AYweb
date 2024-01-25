using AYweb.Application.Models.Permission.Commands.CheckPermission;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AYweb.Presentation.Atteribute.PermissionChacker
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly ISender _sender;

        public int PermissionId { get; set; }
        public PermissionCheckerAttribute(int permissionId, ISender sender)
        {
            PermissionId = permissionId;
            _sender = sender;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = _sender.Send(new GetAuthenticatedUserQuery()).Result;
                if (!_sender.Send(new CheckPermissionCommand { UserId = user.Id, PermissionId = PermissionId }).Result)
                {
                    context.HttpContext.Response.Redirect("/Login");
                }
            }
            else
            {
                context.HttpContext.Response.Redirect("/Login");
            }
        }
      
    }
}
