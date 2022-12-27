using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.Filters;
using MyFramework.Tools.Authentication;
using System.Reflection;

namespace ServiceHost
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerPermission =
                (NeedPermissionAttribute)context.HandlerMethod.MethodInfo.GetCustomAttribute(
                    typeof(NeedPermissionAttribute));

            if (handlerPermission == null)
                return;

            var permissions = _authHelper.GetPermissions();

            if (_authHelper.GetPermissions().All(x=>x != handlerPermission.Permission))
            {
                context.HttpContext.Response.Redirect("/Account");
            }
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}
