using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.ConsoleApp.Tasks
{
    public interface ITask
    {
        void Init();

        Task Execute();
    }
}
