using Kpi.Core.Authentications;
using Kpi.Core.Helpers;
using Kpi.Core.Services;
using Microsoft.Extensions.Options;

namespace Kpi.API.Middlewares
{

    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                var userId = jwtUtils.ValidateJwtToken(token);

                if (userId.HasValue)
                {
                    var user = userService.GetById(userId.Value);

                    if (user != null)
                    {
                        context.Items["User"] = user;
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Unauthorized");
                        return;
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
            }

            // Eğer Authorization header'da token yoksa, kullanıcıya izin ver ve devam et
            await _next(context);
        }
    }

    //public class JwtMiddlerware
    //{
    //    private readonly RequestDelegate _next;
    //    private readonly AppSettings _appSettings;

    //    public JwtMiddlerware(RequestDelegate next, IOptions<AppSettings> appSettings)
    //    {
    //        _next = next;
    //        _appSettings = appSettings.Value;
    //    }

    //    public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
    //    {
    //        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
    //        var userId = jwtUtils.ValidateJwtToken(token);
    //        if (userId != null)
    //        {
    //            context.Items["User"] = userService.GetById(userId.Value);

    //        }
    //        await _next(context);
    //    }
    //}
}
