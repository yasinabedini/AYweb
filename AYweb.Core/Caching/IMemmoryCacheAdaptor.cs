using AYweb.Core.Serializer;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace AYweb.Core.Caching
{
    public class IMemmoryCacheAdaptor : ISessionAdaptor
    {
        private readonly IMemoryCache _cache;
        private readonly IJsonSerializer _serializer;

        public IMemmoryCacheAdaptor(IMemoryCache cache, IJsonSerializer serializer)
        {
            _cache = cache;
            _serializer = serializer;
        }

        public void Add(string key, object value, int absoluteExpirationMinutes, int slidingExpirationMinutes)
        {
            string valueStr = _serializer.Serialize(value);
            _cache.Set(key, valueStr, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(absoluteExpirationMinutes),
                SlidingExpiration = TimeSpan.FromHours(slidingExpirationMinutes)
            });
        }

        public T Get<T>(string key)
        {
            var valueStr = _cache.Get<string>(key) ?? "";
            return _serializer.Deserialize<T>(valueStr);

        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

    }
}
