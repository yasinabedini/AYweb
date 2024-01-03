using Abp.CachedUniqueKeys;
using AYweb.Core.Serializer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Core.Caching
{
    public class SessionAdaptor : ISessionAdaptor
    {        
        private readonly IJsonSerializer _serializer;
        private readonly IHttpContextAccessor _context;

        public SessionAdaptor(IJsonSerializer serializer, IHttpContextAccessor context)
        {            
            _serializer = serializer;
            _context = context;            
        }


        public void Add(string key, object value, int absoluteExpirationMinutes, int slidingExpirationMinutes)
        {
            string valueStr = _serializer.Serialize(value);
            
            _context.HttpContext.Session.SetString(key, valueStr);            
        }

        public T Get<T>(string key)
        {
            var valueStr = _context.HttpContext.Session.GetString(key) ?? "";
            return _serializer.Deserialize<T>(valueStr);

        }

        public void Remove(string key)
        {
            _context.HttpContext.Session.Remove(key);
        }


    }
}
