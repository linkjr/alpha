using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Proxy
{
    /// <summary>
    /// 动态代理类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicProxy<T> : RealProxy
    {
        public DynamicAction[] ProxyMethods { get; set; }

        public DynamicProxy()
            : base(typeof(T))
        {
        }

        public override IMessage Invoke(IMessage msg)
        {
            var callMessage = msg as IMethodCallMessage;
            if (callMessage == null)
                return new ReturnMessage(new Exception("Invoke Faile"), null);

            var target = Activator.CreateInstance<T>() as MarshalByRefObject;
            if (target == null)
                return new ReturnMessage(new Exception("Invoke Faile,请把目标对象 继承自 System.MarshalByRefObject"), callMessage);

            foreach (var actions in this.ProxyMethods)
            {
                if (actions != null && actions.BeforeAction != null)
                    actions.BeforeAction();
            }

            var returnMessage = RemotingServices.ExecuteMessage(target, callMessage);

            foreach (var actions in this.ProxyMethods)
            {
                if (actions != null && actions.AfterAction != null)
                    actions.AfterAction();
            }
            return returnMessage;
        }
    }
}
