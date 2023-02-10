//using Microsoft.VisualBasic.FileIO;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace ConsoleApp3
//{
//    internal class Class1
//    {
//        static void Main()
//        {
//            string csv_file_path = @"C:\Users\GuruH\Downloads\StudentDetails.csv";
//            DataTable csvData = GetDataTabletFromCSVFile(csv_file_path);

//            InsertData(csvData);
//        }
//        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
//        {
//            DataTable csvData = new DataTable();
//            try
//            {
//                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
//                {
//                    csvReader.SetDelimiters(new string[] { "," });
//                    csvReader.HasFieldsEnclosedInQuotes = true;
//                    string[] colFields = csvReader.ReadFields();
//                    foreach (string column in colFields)
//                    {
//                        DataColumn datecolumn = new DataColumn(column);
//                        datecolumn.AllowDBNull = true;
//                        csvData.Columns.Add(datecolumn);
//                    }
//                    while (!csvReader.EndOfData)
//                    {
//                        string[] fieldData = csvReader.ReadFields();

//                        for (int i = 0; i < fieldData.Length; i++)
//                        {
//                            if (fieldData[i] == "")
//                            {
//                                fieldData[i] = null;
//                            }
//                        }
//                        csvData.Rows.Add(fieldData);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//            }
//            return csvData;
//        }

//        public static void InsertData(DataTable csvFileData)
//        {
//            using (SqlConnection dbConnection = new SqlConnection(@"Data Source=.; Initial Catalog=student; Integrated Security=True;"))
//            {
//                dbConnection.Open();
//                try
//                {
//                    using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
//                    {
//                        s.DestinationTableName = "studentdetails";

//                        // foreach (var column in csvFileData.Columns)
//                        //   s.ColumnMappings.Add(column.ToString(), column.ToString(), column.ToString(), column.ToString(), column.ToString(), column.ToString(), column.ToString(), column.ToString(), column.ToString(), column.ToString());

//                        s.WriteToServer(csvFileData);
//                    }
//                }
//                catch (Exception ex)
//                {

//                    Console.WriteLine(ex.Message);
//                }
//            }
//        }


//    }
//}
