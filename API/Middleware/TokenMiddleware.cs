using BLL.Services.Interfaces;

namespace API.Middleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITokenService _tokenService;

        public TokenMiddleware(RequestDelegate next, ITokenService tokenService)
        {
            _next = next;
            _tokenService = tokenService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.Add("Authorization", "Bearer " + _tokenService.GetToken());
            await _next(context);
        }
    }
}
