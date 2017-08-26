namespace DotNet.Common.EnyimCache
{
    using Enyim.Caching;

    public abstract class BaseService
    {
        public static MemcachedClient Client { get; set; }
       
        static BaseService()
        {
            Client = new MemcachedClient();
            Client.FlushAll();
        }
    }
}
