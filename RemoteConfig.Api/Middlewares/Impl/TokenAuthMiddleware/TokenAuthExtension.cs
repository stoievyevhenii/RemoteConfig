namespace RemoteConfig.Api.Middlewares.Impl.TokenAuthMiddleware
{
    public static class TokenAuthExtension
    {
        public static IApplicationBuilder UseTokenAuth(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TokenAuthMiddleware>();
        }
    }
}