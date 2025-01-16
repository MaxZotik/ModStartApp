using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModStartApp.View
{
    public class ModStartAppView : ModuleView
    {
        public override string Name => "Модуль ModStartApp";
        public override string Descr => "Модуль устанавливает настройки уставок из БД и даты последнего пользовательского отчета";
    }
}
