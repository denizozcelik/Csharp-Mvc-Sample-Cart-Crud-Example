using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSepet.AuthenticationClass
{

    public class EmployeeAuthentication : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["uye"] != null)
            {
                return true;
            }
            else
            {
                string a = "Uye Olmamıssınız";
                httpContext.Response.Redirect($"/Home/Login/{a}");
                return false;
            }
        }

    }
}