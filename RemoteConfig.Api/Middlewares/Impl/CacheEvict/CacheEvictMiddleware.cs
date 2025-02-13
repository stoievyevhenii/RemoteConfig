using Microsoft.AspNetCore.OutputCaching;

namespace RemoteConfig.Api.Middlewares.Impl.CacheEvict
{
    public class CacheEvictMiddleware(
           RequestDelegate _next,
           IOutputCacheStore _cache)
    {
        private readonly IOutputCacheStore _cache = _cache;

        private readonly RequestDelegate _next = _next;

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;

            if (HttpMethods.IsPost(request.Method) ||
                HttpMethods.IsPut(request.Method) ||
                HttpMethods.IsDelete(request.Method))
            {
                await _cache.EvictByTagAsync("DefaultCachePolicy_Tag", default);
            }

            await _next(context);
        }
    }
}