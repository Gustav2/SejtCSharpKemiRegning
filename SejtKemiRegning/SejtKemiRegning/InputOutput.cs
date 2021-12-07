using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

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
                            //uses index 1 for element and 3 for molmass
                            dict.Add(values[1],Double.Parse(values[3], CultureInfo.InvariantCulture));
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
    }
}