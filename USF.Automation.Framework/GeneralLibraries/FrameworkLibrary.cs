using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Office.Interop.Excel;
//using ExcelDataReader;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Excel;

namespace USFAutomationFramework.GeneralLibraries
{
    public class FrameworkLibrary
    {
        public static System.Data.DataTable ExcelToDataTable(string fileName, string sheetName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite);
            //Createopnexmlreader via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //Set the first row as Column Name
            excelReader.IsFirstRowAsColumnNames = true;
            //return async data set
            DataSet result = excelReader.AsDataSet();
            //Get all the tables
            DataTableCollection table = result.Tables;
            //LocalDataStoreSlot it in DataTable
            System.Data.DataTable resultTable = table[sheetName];
            return resultTable;
        }

        static List<DataCollection> dataCol = new List<DataCollection>();

        public static int PopulateInCollection(string fileName, string sheetName, string TestscriptId)
        {
            int rowNum = 0;

            dataCol.RemoveAll(item => item != null);
            dataCol.RemoveAll(item => item == null);

            System.Data.DataTable table = ExcelToDataTable(fileName, sheetName);

            for (int row = 1; row <= table.Rows.Count; row++)
            {
                if (table.Rows[row - 1][0].ToString().Trim() == TestscriptId)
                {
                    rowNum = row;
                }
                for (int col = 1; col < table.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName.Trim(),
                        colValue = table.Rows[row - 1][col].ToString().Trim()
                    };
                    dataCol.Add(dtTable);
                }

                if (rowNum > 0)
                {
                    break;
                }


            }
            return rowNum;
        }

        public static string ReadData(int rowNum, string colName)
        {
            string data = (from colData in dataCol
                           where colData.colName == colName && colData.rowNumber == rowNum
                           select colData.colValue).SingleOrDefault();
            return data.ToString();
        }


    }


    public class DataCollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}
