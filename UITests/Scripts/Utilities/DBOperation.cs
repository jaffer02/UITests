using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Scripts.Utilities
{
    class DBOperation
    {
        public static void setDBConnection()
        {
            var username = CommonOperations.getUserIDUpperCase();
            //var dbnames = "";
            if (Globalclass.envToTest.Equals("QA"))
            {
                Globalclass.dbEnv = ConfigurationManager.AppSettings["sqlKey_QA"];
            }
            else if (Globalclass.envToTest.Equals("DEV"))
            {
                Globalclass.dbEnv = ConfigurationManager.AppSettings["sqlKey_Dev"];
            }
            Globalclass.dbconnection = new SqlConnection(Globalclass.dbEnv);
            Globalclass.dbconnection.Open();
            //log.Info("DB Connection Open...");
        }

        static private List<string> QuerySQLServer(String sql)
        {
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(sql, Globalclass.dbconnection);
            myCommand.CommandTimeout = 60000;
            myReader = myCommand.ExecuteReader();
            int columns = myReader.FieldCount;
            //log.Info("Total number of columns: " + columns);
            String rowcontent = "";
            List<string> columncontents = new List<string>();
            while (myReader.Read())
            {
                for(int i = 0; i < columns; i++)
                {
                    if (!myReader[i].ToString().Equals(""))
                    {
                        rowcontent = rowcontent + "#/#" + myReader[i].ToString();
                    }
                    else
                    {
                        rowcontent = rowcontent + "#/#" + myReader[i].ToString().Trim();
                    }
                }
                columncontents.Add(rowcontent.Substring(3));
                rowcontent = "";
            }
            myReader.Close();
            return columncontents;
        }
    }
}
