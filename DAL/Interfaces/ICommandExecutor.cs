using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICommandExecutor
    {
        T ExecuteSelect<T>(string commandText);
        void Execute(string commandText);
    }
}
