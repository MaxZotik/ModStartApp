using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModStartApp.Logic.Classes
{
    public class ConfigInfo
    {
        public DateTime StartDT { get; set; }

        public DateTime EndDT { get; set; }

        public ConfigInfo(DateTime start, DateTime end)
        {
            StartDT = start;
            EndDT = end;
        }
    }
}
