using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab5_WebApp.Data;
using Lab5_WebApp.Models;

namespace Lab5_WebApp.Midelware
{
    public class RoleInitializerMiddleware
    {
        private readonly RequestDelegate _next;
        public RoleInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await RoleInitializer.InitializeAsync(userManager, roleManager);

            await _next(context);
        }
    }
    public static class DbInitializerExtensions
    {
        public static IApplicationBuilder UseRoleInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoleInitializerMiddleware>();
        }

    }
}
