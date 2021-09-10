﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Filter
{
  
        public class Auth : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (HttpContext.Current.Session["Login"] == null)
                {
                    filterContext.Result = new RedirectResult("~/User/Login");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }
    
}