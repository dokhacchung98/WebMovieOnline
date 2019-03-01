using System.Web.Mvc;

namespace Website.Configuaration
{
    public class CustomRoleAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectResult("/Error/Unauthorized"); // Give error controller or Url name
            }
            else
            {
                context.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}