using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.ConsoleApp.Tasks
{
    public class CloneTask : BaseTask
    {
        public override void Init()
        {
            var cloneObject = new CloneObject();
            cloneObject.Name = "N1";
            Console.WriteLine(string.Format("拷贝对象的名称为：{0}", cloneObject.Name));
            var shallowCloneObject = cloneObject;
            var deepCloneObject = cloneObject.Clone() as CloneObject;
            cloneObject.Name = "N2";
            Console.WriteLine(string.Format("执行拷贝完成，修改拷贝对象名称为：{0}", cloneObject.Name));
            Console.WriteLine(string.Format("潜拷贝对象的名称为：{0}；深拷贝对象的名称为：{1}", shallowCloneObject.Name, deepCloneObject.Name));
        }
    }

    /// <summary>
    /// 表示可以深拷贝的对象。
    /// </summary>
    public class CloneObject : ICloneable
    {
        public string Name { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
