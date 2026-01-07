using Microsoft.AspNetCore.Mvc.Filters;

namespace NetCore_I2E_Sandip_poojara.Filters
{
    public class ValidateModelFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.BadRequestObjectResult(context.ModelState);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No implementation needed for this example
        }
    }
}
