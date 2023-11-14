using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AYweb.Core.Security
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        //public int PermissionId { get; set; }
        //public IPermissionService _Permission { get; set; }
        //public PermissionCheckerAttribute(int permissionId)
        //{
        //    PermissionId = permissionId;
        //}
        //public void OnAuthorization(AuthorizationFilterContext context)
        //{
        //    _Permission = context.HttpContext.RequestServices.GetService(typeof(IPermissionService)) as IPermissionService;
        //    if (context.HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        string username = _Permission.GetAuthonticatedUserUsername(context.HttpContext);
        //        if (!_Permission.CheckPermission(username, PermissionId))
        //        {
        //            context.HttpContext.Response.Redirect("/Login");
        //        }
        //    }
        //    else
        //    {
        //        context.HttpContext.Response.Redirect("/Login");
        //    }
        //}
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}
