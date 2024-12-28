using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModStartApp.Logic.Classes
{
    public class RepositoryConfigWritePeriod : IRepository<ConfigWritePeriod>
    {
        public static List<ConfigWritePeriod> LimitsValues { get; set; }

        private static DataTable? tableDatas;

        [Obsolete]
        static RepositoryConfigWritePeriod()
        {
            LimitsValues = new List<ConfigWritePeriod>();
            GetDataDb();
            AddLimitsValues();
        }

        [Obsolete]
        private static void GetDataDb()
        {
            string selectQuery = $"SELECT [CnlNum], [SignalsWritePeriod] FROM {Table.ConfigWritePeriod.ToString()}";

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
                double signalsWritePeriod = double.Parse(tableDatas.Rows[i].ItemArray[1].ToString());

                LimitsValues.Add(new ConfigWritePeriod(cnlNum, signalsWritePeriod));
            }
        }
    }
}
