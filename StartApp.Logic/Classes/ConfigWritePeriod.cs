using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModStartApp.Logic.Classes
{
    public class ConfigWritePeriod
    {
        public int CnlNum { get; set; }

        public double SignalsWritePeriod { get; set; }

        public ConfigWritePeriod(int cnlNum, double signalsWritePeriod) 
        { 
            CnlNum = cnlNum;
            SignalsWritePeriod = signalsWritePeriod;
        }
    }
}
