using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModStartApp.Logic.Classes
{
    public class RepositoryConfigLimit : IRepository<ConfigLimit>
    {
        public static List<ConfigLimit> LimitsValues { get; set; }

        private static DataTable? tableDatas;

        [Obsolete]
        static RepositoryConfigLimit() 
        {
            LimitsValues = new List<ConfigLimit>();
            GetDataDb();
            AddLimitsValues();
        }

        [Obsolete]
        private static void GetDataDb()
        {
            string selectQuery = $"SELECT [CnlNum], [Limit] FROM {Table.ConfigLimits.ToString()}";

            using (SqlConnection connection = new SqlConnection(ConnectionStringMssql.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                tableDatas = ds.Tables[0];
            }
        }

        private static void AddLimitsValues() 
        {
            int count = tableDatas.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                int cnlNum = int.Parse(tableDatas.Rows[i].ItemArray[0].ToString());
                double limit = double.Parse(tableDatas.Rows[i].ItemArray[1].ToString());

                LimitsValues.Add(new ConfigLimit(cnlNum, limit));
            }
        }
    }
}
