using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModStartApp.Logic.Interfaces
{
    public interface ICreateObject<T>
    {
        static T ObejctConfig { get; set; }
    }
}
