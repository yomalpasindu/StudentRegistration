using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentRegistration.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var controllerName = context.RouteData.Values["controller"].ToString();

            if (controllerName != "Authentication"&&!context.HttpContext.User.Identity.IsAuthenticated)
            {
                //context.Result = new UnauthorizedResult();
            }
        }
    }
}
