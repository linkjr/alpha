using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.ConsoleApp
{
    public class Instance
    {
        public static IEnumerable<Type> FindInstancesByInterface<IType>()
        {
            var instances = from m in Assembly.GetExecutingAssembly().GetTypes()
                        where m.GetInterfaces().Contains(typeof(IType))
                        select m;
            return instances;
        }
    }
}
