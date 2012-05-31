using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Claims;

namespace CommonAccessAttributes
{
    public class PartnerAccessAttribute : AccessBaseAttribute
    {
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            PerformAuthorization(filterContext, "Partner");
        }
    }    
}