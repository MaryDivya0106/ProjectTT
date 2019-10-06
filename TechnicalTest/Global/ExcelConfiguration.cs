using ExcelDataReader;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Global
{
    #region Excel
    class ExcelConfiguration
    {
    
        private static readonly List<Datacollection> DataCol = new List<Datacollection>();

        private static void ClearData()
        {
            DataCol.Clear();
        }

        private static DataTable ExcelToDataTable(string fileName, string sheetName)
        {
            // Open file and return as Stream
            using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {

                using (ExcelDataReader.IExcelDataReader reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                {

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    //Get all the tables
                    var table = result.Tables;
                    // store it in data table
                    var resultTable = table[sheetName];
                    return resultTable;
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations

                rowNumber = rowNumber - 1;
                var data = (from colData in DataCol
                            where (colData.ColName == columnName) && (colData.RowNumber == rowNumber)
                            select colData.ColValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data;
            }
            catch (Exception e)
            {
                // ReSharper disable once LocalizableElement
                Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine +
                                  e.Message);
                return null;
            }
        }


        public static void PopulateInCollection(string fileName, string sheetName)
        {
            ClearData();
            var table = ExcelToDataTable(fileName, sheetName);

            //Iterate through the rows and columns of the Table
            for (var row = 1; row <= table.Rows.Count; row++)
                for (var col = 0; col < table.Columns.Count; col++)
                {
                    var dtTable = new Datacollection
                    {
                        RowNumber = row,
                        ColName = table.Columns[col].ColumnName,
                        ColValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    DataCol.Add(dtTable);
                }
        }
        private class Datacollection
        {
            public int RowNumber { get; set; }
            public string ColName { get; set; }
            public string ColValue { get; set; }
        }
    }
}
#endregion
