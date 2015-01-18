using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace exportrecfile
{
    /// <summary>
    /// DBアクセス失敗例外
    /// </summary>
    class DBAccessException : Exception
    {
        public DBAccessException(string msg) : base(msg) { }
    }

    /// <summary>
    /// DBアクセサ
    /// </summary>

    class DBAccessor
    {
        // Logger
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<string[]> GetRecordingData(string sql)
        {
            logger.Info("SQL発行:" + sql);
            try
            {
                List<string[]> ret = new List<string[]>();
                
                //DBから ***************
                //using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBConnectString))
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBConnectString2))

                {

                    // DB接続
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    command.CommandTimeout = Properties.Settings.Default.DBTimeOut;

                    using (SqlDataReader reader = command.ExecuteReader())

                    {
                        while(reader.Read())
                        {
                            string[] columns = new string[reader.FieldCount];
                            for (int i=0;i<reader.FieldCount;i++)
                            {
                                if(reader.IsDBNull(i))
                                {
                                    columns[i]=string.Empty;
                                }
                                else
                                {
                                    columns[i]=reader.GetString(i).Trim();
                                }
                            }
                            ret.Add(columns); 
                        }
                    }
                }
                return ret;
                
            }
            catch (SqlException e)
            {
                throw new DBAccessException(string.Format(Properties.Resources.LMSG_E_100_DB_ERR,e.Message));
            }

        }

    }

}
