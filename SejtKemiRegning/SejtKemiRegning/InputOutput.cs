using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ClosedXML.Excel;

namespace SejtKemiRegning
{
    public class InputOutput
    {
        public static Dictionary<string, double> CSVToDict(string path)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    if (values.Length == 4)
                    {
                        try
                        {
                            //uses index 2 for element and 3 for molmass
                            dict.Add(values[2],Double.Parse(values[3], CultureInfo.InvariantCulture));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }

            return dict;
        }

        
        //Bruger ClosedXML.Excel til at eksportere til excel
        //Installer ClosedXML som NuGet pakke 
        public static void arrayToExcel(string[] elementArr, double[] molMassArr)
        {
            int endIndex = 0;
            
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("MolMass sheet");
                
                for (int i = 0; i < elementArr.Length; i++)
                {
                    worksheet.Cell($"A{i+1}").Value = elementArr[i];
                    worksheet.Cell($"B{i+1}").Value = molMassArr[i];
                    endIndex = i;
                }
                worksheet.Cell($"A{endIndex+2}").Value = "Sum";
                worksheet.Cell($"B{endIndex + 2}").Value = worksheet.Evaluate($"=SUM(B1:B{endIndex + 1})");
                workbook.SaveAs("molMass.xlsx");
            }
        }
    }
}