using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NetCore_I2E_Sandip_poojara.Filters
{
    public class AdminOnlyFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity!.IsAuthenticated)
            {
                context.Result = new JsonResult(new
                {
                    success = false,
                    message = "Please login to continue."
                })
                { StatusCode = 401 };

                return;
            }

            if (!context.HttpContext.User.IsInRole("Admin"))
            {
                context.Result = new JsonResult(new
                {
                    success = false,
                    message = "You do not have permission to perform this action."
                })
                { StatusCode = 403 };
            }
        }
    }
}
