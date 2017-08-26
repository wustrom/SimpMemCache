using System;

namespace DotNet.Common.EnyimCache
{
    using Enyim.Caching.Memcached;

    public class CacheReaderService : BaseService, ICacheReaderService
    {

        public int TimeOut
        {
            get;
            set;
        }

        public CacheReaderService()
        {

        }

        public object Get(string key)
        {
            object obj = null;
            Client.TryGet(key, out obj);
            return obj;
        }

        public T Get<T>(string key)
        {
            object obj = Get(key);
            T result = default(T);
            if (obj != null)
            {
                result = (T)obj;
            }
            return result;
        }

        public bool isExists(string key)
        {
            object obj = Get(key);
            return (obj == null) ? false : true;
        }
    }

    public class CacheWriterService : BaseService, ICacheWriterService
    {
        public int TimeOut
        {
            get;
            set;
        }

        public CacheWriterService()
        {

        }

        public CacheWriterService(int timeOut)
        {
            this.TimeOut = timeOut;
        }

        public void Add(string key, object obj)
        {
            if (TimeOut > 0)
            {
                Client.Store(StoreMode.Add, key, obj, DateTime.Now.AddMinutes(TimeOut));
            }
            else
            {
                Client.Store(StoreMode.Add, key, obj);
            }
        }

        public void Add<T>(string key, T obj)
        {
            if (TimeOut > 0)
            {
                Client.Store(StoreMode.Add, key, obj, DateTime.Now.AddMinutes(TimeOut));
            }
            else
            {
                Client.Store(StoreMode.Add, key, obj);
            }
        }

        public bool Remove(string key)
        {
            return Client.Remove(key);
        }

        public bool Modify(string key, object destObj)
        {
            return Client.Store(StoreMode.Set, key, destObj);
        }

        /// <summary>
        /// 清空缓存 TO DO
        /// </summary>
        /// <returns></returns>
        public bool Release()
        {
            throw new NotImplementedException();
        }
    }
}
