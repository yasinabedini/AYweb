using AYweb.Core.Serializer;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Core.Caching
{
    public class DistributedCacheAdaptor : ICacheAdaptor
    {
        private readonly IDistributedCache _cache;
        private readonly IJsonSerializer _serializer;

        public DistributedCacheAdaptor(IDistributedCache cache, IJsonSerializer serializer)
        {
            _cache = cache;
            _serializer = serializer;
        }

        public void Add(string key, object value, int absoluteExpirationMinutes, int slidingExpirationMinutes)
        {
            string valueStr = _serializer.Serialize(value);
            _cache.SetString(key, valueStr, new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(absoluteExpirationMinutes),
                SlidingExpiration = TimeSpan.FromHours(slidingExpirationMinutes)
            });
        }

        public T Get<T>(string key)
        {
            var valueStr = _cache.GetString(key) ?? "";
            return _serializer.Deserialize<T>(valueStr);

        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

     
    }
}
