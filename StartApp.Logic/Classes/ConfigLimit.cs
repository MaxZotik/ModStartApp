using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModStartApp.Logic.Classes
{
    public class ConfigLimit
    {
        public int CnlNum { get; set; }

        public double Limit { get; set; }

        public ConfigLimit(int cnlNum, double limit)
        {
            CnlNum = cnlNum;
            Limit = limit;
        }
    }
}
