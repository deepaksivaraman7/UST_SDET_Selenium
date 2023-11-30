using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Utilities
{
    internal class ExcelUtils
    {
        public static List<BookMovie> ReadExcelData(string excelFilePath, string sheetName)
        {
            List<BookMovie> excelDataList = new();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables[sheetName];
                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            BookMovie excelData = new()
                            {
                                City = GetValueOrDefault(row, "city"),
                                MovieSearch = GetValueOrDefault(row, "searchtext"),
                                NumberOfSeats=GetValueOrDefault(row,"numberofseats"),
                                Email= GetValueOrDefault(row, "email"),
                                MobileNumber= GetValueOrDefault(row,"mobno"),
                                CardNumber=GetValueOrDefault(row,"cardno"),
                                NameOnCard=GetValueOrDefault(row,"nameoncard"),
                                CardExpiryMonth = GetValueOrDefault(row, "cardexpirymonth"),
                                CardExpiryYear = GetValueOrDefault(row, "cardexpiryyear"),
                                CardCvv = GetValueOrDefault(row, "cvv"),

                            };
                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine(sheetName + " not found in the excel file.");
                    }
                }
            }
            return excelDataList;
        }
        static string GetValueOrDefault(DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
