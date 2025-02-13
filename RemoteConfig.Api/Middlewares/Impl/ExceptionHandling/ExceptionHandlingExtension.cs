namespace RemoteConfig.Api.Middlewares.Impl.ExceptionHandling
{
    public static class ExceptionHandlingExtension
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}