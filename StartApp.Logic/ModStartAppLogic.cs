using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModStartApp.Logic
{
    public class ModStartAppLogic : ModuleLogic
    {
        bool sendDataLimits = true;
        bool sendDataWritePeriod = true;
        public ModStartAppLogic(IServerContext serverContext) : base(serverContext)
        {
        }

        public override string Code => "StartApp";

        public override void OnServiceStart()
        {
            Log.WriteAction("Модуль StartApp запущен");
        }

        public override void OnServiceStop()
        {
            Log.WriteAction("Модуль StartApp остановлен");
        }

        public override void OnIteration()
        {
            if (sendDataLimits)
            {
                SendDataLimits();
            }
            
            if(sendDataWritePeriod)
            {
                SendDataWritePeriod();
            }            
        }

        private void SendDataLimits()
        {
            CnlData curData;
            int count = RepositoryConfigLimit.LimitsValues.Count;

            for (int i = 0; i < count; i++)
            {
                curData = ServerContext.GetCurrentData(RepositoryConfigLimit.LimitsValues[i].CnlNum);

                if (curData.IsDefined)
                {
                    curData.Val = RepositoryConfigLimit.LimitsValues[i].Limit;
                    
                    ServerContext.WriteCurrentData(RepositoryConfigLimit.LimitsValues[i].CnlNum, curData);
                }
            }       
            
            sendDataLimits = false;
        }

        private void SendDataWritePeriod()
        {
            CnlData curData;
            int count = RepositoryConfigWritePeriod.LimitsValues.Count;

            for (int i = 0; i < count; i++)
            {
                curData = ServerContext.GetCurrentData(RepositoryConfigWritePeriod.LimitsValues[i].CnlNum);

                if (curData.IsDefined)
                {
                    curData.Val = RepositoryConfigWritePeriod.LimitsValues[i].SignalsWritePeriod;

                    ServerContext.WriteCurrentData(RepositoryConfigWritePeriod.LimitsValues[i].CnlNum, curData);
                }
            }

            sendDataWritePeriod = false;
        }
    }
}
