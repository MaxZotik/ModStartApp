using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Scada.Server.Modules.ModStartApp.Logic.Classes
{
    public class ConnectionStringMssql : IConnectDb
    {
        private static readonly string path = @"C:\Program Files\SCADA\ScadaServer\Mod\StartAppLogicConfig.xml";

        private static readonly Config config;
        public static string ConnectionString { get; set; } = "";

        static ConnectionStringMssql()
        {
            config = CreateConfig();
            InitConnectionString();
        }

        private static void InitConnectionString()
        {            
            if (config != null)
            {
                ConnectionString = $@"Data Source={config.Server};Initial Catalog={config.NameDb};User ID={config.User};Password={config.Password}";
            }           
        }

        private static Config CreateConfig()
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
                        return new Config(
                            xElem.ChildNodes[0].InnerText,
                            xElem.ChildNodes[1].InnerText,
                            xElem.ChildNodes[2].InnerText,
                            xElem.ChildNodes[3].InnerText);
                    }
                }
            }

            return null;
        }
    }
}
