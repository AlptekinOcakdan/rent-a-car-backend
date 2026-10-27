using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Microsoft {
    public class MemoryCacheManager : ICacheManager {
        IMemoryCache _memoryCache;

        public MemoryCacheManager() {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration) {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key) {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key) {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key) {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key) {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern) {
            // The private EntriesCollection property used here before no longer exists on .NET 7+ (NullReferenceException); MemoryCache.Keys is public since .NET 9
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = ((MemoryCache)_memoryCache).Keys.Where(k => regex.IsMatch(k.ToString())).ToList();

            foreach (var key in keysToRemove) {
                _memoryCache.Remove(key);
            }
        }
    }
}
