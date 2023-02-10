using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lineNumber = 0;
            using (SqlConnection con = new SqlConnection(@"Data Source=.; Initial Catalog=student; Integrated Security=True;"))
            {
                con.Open();
                using (StreamReader sr = new StreamReader(@"C:\Users\GuruH\Downloads\StudentDetails.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();

                        if (lineNumber != 0)
                        {
                            var values = line.Split(',');

                            var sql = " INSERT INTO student.dbo.studentdetails VALUES ('" + values[1] + "', '" + values[2] + "','" + values[3] + "','" + values[4].ToString() + "','" + values[5] + "','" + values[6] + "','" + values[7] + "','" + values[8] + "','" + values[9] + "','" + values[10] + "')";

                            var cmd = new SqlCommand();
                            cmd.CommandText = sql;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                        }
                        lineNumber++;
                    }
                }
                con.Close();
            }
            Console.WriteLine("Student Import Details Completed");
            Console.ReadLine();
        }
    }
}
