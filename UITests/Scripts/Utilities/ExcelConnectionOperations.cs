using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Scripts.Utilities
{
    class ExcelConnectionOperations
    {
        static public string returnConnection(String filelocation)
        {
            String connstring = ConfigurationManager.AppSettings["excelKey1"];
            connstring = connstring.Replace("xxxxxxxx", filelocation);
            return (connstring);
        }

        static public List<String> ConnectAndQuery(String sql, String filelocation)
        {
            List<string> columncontents = new List<string>();
            using (OleDbConnection connection = new OleDbConnection(returnConnection(filelocation)))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                using(OleDbDataReader dr = command.ExecuteReader())
                {
                    int columns = dr.FieldCount;
                    String rowcontent = "";
                    while (dr.Read())
                    {
                        for(int i = 0; i < columns; i++)
                        {
                            rowcontent = rowcontent + "#/#" + dr[i].ToString();
                            if (rowcontent.Contains("_x000d_\n_x000d_\n"))
                            {
                                rowcontent = rowcontent.Replace("_x000d_\n_x000d_\n", "\n\n");
                            }
                        }
                        columncontents.Add(rowcontent.Substring(3));
                        rowcontent = "";
                    }
                }
            }
            return columncontents;
        }
    }
}
