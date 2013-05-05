﻿using System;
using System.Web;
using System.Web.Security;
using CQRS.Base.DDD.Domain.Annotations;
using CQRS.Security.Application.Extensions;
using CQRS.Security.Interfaces.Application;
using CQRS.Security.Interfaces.Application.Services;

namespace CQRS.Security.Application.Services
{
    [DomainService]
    public class AuthCookieService : IAuthCookieService
    {
        public CustomPrincipalInfo GetUserCookiesInfo()
        {
            // TODO: Move the dependency to an external service or to the consumer
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null) return null;

            var ticket = cookie.GetFormsAuthenticationTicket();
            return ticket.GetCustomPrincipalInfo();
        }

        public void UpdateUserCookiesInfo(CustomPrincipalInfo info)
        {
            // TODO: Move the dependency to an external service or to the consumer
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = cookie.GetFormsAuthenticationTicket();
            var updated = ticket.RecreateAuthenticationCookie(info, DateTime.Now);
            HttpContext.Current.Response.Cookies.Add(updated);
        }
    }
}
