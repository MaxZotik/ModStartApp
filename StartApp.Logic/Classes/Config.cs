using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModStartApp.Logic.Classes
{
    public class Config
    {
        public string Server {  get; set; }

        public string NameDb { get; set; }

        public string User {  get; set; }

        public string Password { get; set; }

        public Config(string server, string nameDb, string user, string password) 
        {
            Server = server;
            NameDb = nameDb;
            User = user;
            Password = password;
        }
    }
}
