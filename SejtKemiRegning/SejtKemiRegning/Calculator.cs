using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SejtKemiRegning
{
    public class Calculator
    {
        public double[] Calculate(string inputText){
            Dictionary<string, double> molMasses = InputOutput.CSVToDict(@"dims.csv");
            string[] substances = ParseInput(inputText);
            int[] amounts = new int[substances.Length];
            
            for(int i = 0; i < substances.Length; i++){
                amounts[i] = int.Parse(Regex.Replace(substances[i], "[^0-9.]", ""));
                substances[i] = Regex.Replace(substances[i], @"\d", "");
            }
            double[] molMass = new double[substances.Length];
            
            for (int i = 0; i < substances.Length; i++){
                if (molMasses.ContainsKey(substances[i])){
                    molMass[i] = molMasses[substances[i]] * amounts[i];
                }
            }

            return molMass;
        }
        
        public string[] ParseInput(string input){
            input = input.Replace(" ", "");
            
            // Replaces every every coefficient with nothing to avoid errors, but pls fix in future
            input = Regex.Replace(input, @"\G([^(A-Z)\d]*)\d|([+]([^[A-Z]*))", "");
            
            input = input.Replace("+", "");
            string[] split =  Regex.Split(input, @"(?<!^)(?=[A-Z])|(?=[+])");
            return split;
        }
        
        public string convertToString(double[] inputArray){
            string output = "";
            foreach(double s in inputArray){
                output += s + " + ";
            }
            output = output.Remove(output.Length - 3, 3);
            return output;
        }
        
    }
}