using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        string excelFilePath = "path_to_your_excel_file.xlsx";
        string jsonFilePath = "output.json";

        try
        {
            // Read Excel file
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true // Use the first row as column headers
                        }
                    });

                    // Convert the first DataTable to JSON
                    if (dataSet.Tables.Count > 0)
                    {
                        DataTable dataTable = dataSet.Tables[0];
                        string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);

                        // Write JSON to file
                        File.WriteAllText(jsonFilePath, json);
                        Console.WriteLine("Excel file converted to JSON successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No data found in the Excel file.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

// If you still get CS0103, you likely need to install the ExcelDataReader NuGet package.
// In Visual Studio, right-click your project > Manage NuGet Packages > Browse > search for "ExcelDataReader" and "ExcelDataReader.DataSet" and install both.
// This will make ExcelReaderFactory available in your project.