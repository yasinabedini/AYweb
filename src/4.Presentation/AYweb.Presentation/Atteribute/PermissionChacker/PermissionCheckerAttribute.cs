using AYweb.Application.Models.Permission.Commands.CheckPermission;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Polly;

namespace AYweb.Presentation.Atteribute.PermissionChacker
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        
        private ISender _sender;        

        public int PermissionId { get; set; }

        public PermissionCheckerAttribute(int permissionId)
        {            
            PermissionId = permissionId;            
        }

       
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _sender = context.HttpContext.RequestServices.GetService(typeof(ISender)) as ISender;

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = _sender.Send(new GetAuthenticatedUserQuery()).Result;
                if (!_sender.Send(new CheckPermissionCommand { UserId = user.Id, PermissionId = PermissionId }).Result)
                {
                    context.HttpContext.Response.Redirect("/NotPermission");
                }
            }
            else
            {
                context.HttpContext.Response.Redirect("/Login");
            }
        }
      
    }
}
