using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Proxy
{
    /// <summary>
    /// 动态代理要执行的方法
    /// </summary>
    public class DynamicAction
    {
        /// <summary>
        /// 执行目标方法前执行
        /// </summary>
        public Action BeforeAction { get; set; }


        /// <summary>
        /// 执行目标方法后执行
        /// </summary>
        public Action AfterAction { get; set; }
    }
}
