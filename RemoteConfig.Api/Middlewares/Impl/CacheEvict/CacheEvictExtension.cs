namespace RemoteConfig.Api.Middlewares.Impl.CacheEvict
{
    public static class CacheEvictExtension
    {
        public static IApplicationBuilder UseCacheEvict(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CacheEvictMiddleware>();
        }
    }
}