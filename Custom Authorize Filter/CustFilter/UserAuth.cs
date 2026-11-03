using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Custom_Authorize_Filter.CustFilter
{
    public class UserAuth : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("CompanyID") == null)
            {
                context.Result = new RedirectToActionResult("Login","ManageUsers",new {area=""});
            }
        }
    }
}
