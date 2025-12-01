namespace Poker.CMS.Common.Helpers.Interface
{
    public interface ICacheHelper
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, TimeSpan? absoluteExpirationRelativeToNow = null);

        void Set<T>(string cacheKey, Func<T> getItemCallback, TimeSpan? absoluteExpirationRelativeToNow = null);

        Task<T> GetOrSetAsync<T>(string cacheKey, Func<Task<T>> getItemCallbackAsync, TimeSpan? absoluteExpirationRelativeToNow = null);
    }
}