using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Scada.Server.Modules.ModStartApp.Logic.Classes
{
    public class RepositoryConfigInfo : ICreateObject<ConfigInfo>
    {
        private static readonly string path = @"C:\Program Files\SCADA\ScadaServer\Mod\StartAppLogicConfigPath.xml";
        private static string pathConfigInfo;

        public static readonly int cnlNumStartDate = 2700;
        public static readonly int cnlNumEndDate = 2701;


        static RepositoryConfigInfo() 
        {
            SetPathConfigInfo();
            CreateObjectFromFile();
        }

        public static ConfigInfo ObejctConfig { get; set; }


        private static void SetPathConfigInfo()
        {
            if (File.Exists(path))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlElement? root = xDoc.DocumentElement;

                if (root != null)
                {
                    foreach (XmlElement xElem in root)
                    {
                        pathConfigInfo = xElem.ChildNodes[0].InnerText;
                    }
                }
            }
        }

        private static void CreateObjectFromFile()
        {
            if (File.Exists(pathConfigInfo))
            {
                string[] read_result_array = File.ReadAllLines(pathConfigInfo, Encoding.Default);

                ObejctConfig = new ConfigInfo(Convert.ToDateTime(read_result_array[0]), Convert.ToDateTime(read_result_array[1]));
            }
            else
            {
                ObejctConfig = new ConfigInfo(new DateTime(), new DateTime());
            }
        }
    }
}
