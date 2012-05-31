using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Claims;

namespace CommonAccessAttributes
{
    public abstract class AccessBaseAttribute : AuthorizeAttribute
    {
        const string PermissionsClaimType = @"http://schemas.appliedis.com/ws/2011/09/identity/claims/Permission";
        readonly IList<string> SuperUsers = new List<string>()
        {
            "Supervisor",
            "Admin"
        };

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            return base.AuthorizeCore(httpContext);
        }

        protected void PerformAuthorization(System.Web.Mvc.AuthorizationContext filterContext,
            string permissionType, string errorMessage = "Unauthorized to access requested resource")
        {
            var id = HttpContext.Current.User.Identity as ClaimsIdentity;
            if (null == id)
            {
                throw new UnauthorizedAccessException("User identity could not be determined");
            }
            var permission = id.Claims.FirstOrDefault(c => c.ClaimType == PermissionsClaimType);
            if (id.IsAuthenticated)
            {
                if (null == permission ||
                    (!SuperUsers.Contains(permission.Value, StringComparer.OrdinalIgnoreCase) &&
                    !permission.Value.Equals(permissionType, StringComparison.OrdinalIgnoreCase)))
                {
                    filterContext.Result = new ContentResult()
                    {
                        Content = "<h1>" + errorMessage + "</h1>"
                    };
                }
            }
            else
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
}