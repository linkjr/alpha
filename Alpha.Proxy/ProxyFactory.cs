using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Proxy
{
    /// <summary>
    /// 代理工厂
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ProxyFactory
    {
        public static T Create<T>(params DynamicAction[] proxyMethods)
        {
            var proxy = new DynamicProxy<T>()
            {
                ProxyMethods = proxyMethods
            };
            return (T)proxy.GetTransparentProxy();
        }
    }
}
