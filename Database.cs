using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLtietkiem
{
    class Database
    {
        private SqlConnection mycon;
        private SqlDataAdapter ad;
        private SqlCommandBuilder com;
        private static Database singleton = null;
        public static Database Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new Database();
                }
                return singleton;
            }
        }
        public Database()
        {
            string sqlcon = @"Data Source=DESKTOP-7N23OPA\HQTCSDL;Initial Catalog=QLtietkiem;Integrated Security=True";
            this.mycon = new SqlConnection(sqlcon);
        }
        public DataTable LoadData (string sql )
        {
            DataTable dt = new DataTable();
            ad = new SqlDataAdapter(sql, this.mycon);
            ad.Fill(dt);
            return dt;
        }
    }
}
