using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Claims;

namespace CommonAccessAttributes
{
    public class ClientAccessAttribute : AccessBaseAttribute
    {
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            PerformAuthorization(filterContext, "Client", "Only clients are allowed in this area!");
        }
    }    
}