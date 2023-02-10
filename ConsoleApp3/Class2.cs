using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ConsoleApp3
{
    internal class Class2
    {
        static void Main(string[] args)
        {

            var lineNumber = 0;
            using (SqlConnection con = new SqlConnection(@"Data Source=.; Initial Catalog=student; Integrated Security=True;"))
            {
                con.Open();
                using (StreamReader sr = new StreamReader(@"C:\Users\GuruH\Downloads\Attend.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        try
                        {
                            if (lineNumber != 0)
                            {
                                var values = line.Split(',');

                                var sql = " INSERT INTO student.dbo.Attendance VALUES ('" + values[1] + "', '" + values[2] + "','" + values[3] + "')";

                                var cmd = new SqlCommand();
                                cmd.CommandText = sql;
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                            }
                            lineNumber++;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);

                        }
                    }

                }
                con.Close();
            }


        }
    }


}
