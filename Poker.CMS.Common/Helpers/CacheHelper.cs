using Microsoft.Extensions.Caching.Memory;
using Poker.CMS.Common.Helpers.Interface;

namespace Poker.CMS.Common.Helpers
{
    public class CacheHelper : ICacheHelper
    {
        private readonly IMemoryCache _memoryCache;

        public CacheHelper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, TimeSpan? absoluteExpirationRelativeToNow = null)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out T cacheEntry))
            {
                cacheEntry = getItemCallback();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));

                if (absoluteExpirationRelativeToNow.HasValue)
                {
                    cacheEntryOptions.SetAbsoluteExpiration(absoluteExpirationRelativeToNow.Value);
                }

                _memoryCache.Set(cacheKey, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }

        public async Task<T> GetOrSetAsync<T>(string cacheKey, Func<Task<T>> getItemCallbackAsync, TimeSpan? absoluteExpirationRelativeToNow = null)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out T cacheEntry))
            {
                cacheEntry = await getItemCallbackAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));

                if (absoluteExpirationRelativeToNow.HasValue)
                {
                    cacheEntryOptions.SetAbsoluteExpiration(absoluteExpirationRelativeToNow.Value);
                }

                _memoryCache.Set(cacheKey, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }

        public void Set<T>(string cacheKey, Func<T> getItemCallback, TimeSpan? absoluteExpirationRelativeToNow = null)
        {
            var cacheEntry = getItemCallback();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30));

            if (absoluteExpirationRelativeToNow.HasValue)
            {
                cacheEntryOptions.SetAbsoluteExpiration(absoluteExpirationRelativeToNow.Value);
            }

            _memoryCache.Set(cacheKey, cacheEntry, cacheEntryOptions);
        }
    }

}
