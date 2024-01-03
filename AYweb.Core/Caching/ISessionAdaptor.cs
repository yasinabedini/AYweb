using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Core.Caching
{
    public interface ISessionAdaptor
    {
        void Add(string key, object value, int absoluteExpirationMinutes, int slidingExpirationMinutes);
        void Remove(string key);
        T Get<T>(string key);
    }
}
