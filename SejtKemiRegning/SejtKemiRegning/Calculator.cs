using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Spreadsheet;

namespace SejtKemiRegning
{
    public class Calculator {
        private Dictionary<string, double> molMasses = InputOutput.CSVToDict(@"dims.csv");
        private string[] _substances;
        private int[] _amounts;
        private int[] _coeffecients;

        public Calculator(string inputText) {
            _substances = ParseInput(inputText);
            _amounts = getAmounts(_substances);
            _coeffecients = getCoeffecients(_substances);
            _substances = removeCoeffecients(_substances);
        }
        
        public double[] Calculate(){
            double[] molMass = new double[_substances.Length];
            for (int i = 0; i < _substances.Length; i++){
                if (molMasses.ContainsKey(_substances[i]) && _amounts[i] == 0){
                    molMass[i] = molMasses[_substances[i]] * _coeffecients[i];
                }
                else if (molMasses.ContainsKey(_substances[i]) && _amounts[i] != 0){
                    molMass[i] = molMasses[_substances[i]] * _amounts[i] * _coeffecients[i];
                }
                else
                {
                    throw new Exception("Unknown Substance");
                }
            }
            return molMass;
        }

        private int[] getAmounts(string[] substances) {
            int[] amounts = new int[substances.Length];
            for(int i = 0; i < substances.Length; i++){
                try {
                    amounts[i] = int.Parse(Regex.Replace(substances[i], "[^0-9.]", ""));
                }
                catch (FormatException){
                    continue;
                }
                substances[i] = Regex.Replace(substances[i], @"\d", "");
            }

            return amounts;
        }

        private int[] getCoeffecients(string[] substances) {
            int[] coeffecients = new int[substances.Length];
            for (int i = 0; i < substances.Length; i++) {
                // Puts all coefficients in match
                var match = Regex.Match(substances[i], @"\G([^(A-Z)\d]*)\d");
                if (match.Success) {
                    coeffecients[i] = int.Parse(match.Value);
                }
                else {
                    coeffecients[i] = 1;
                }
            }
            return coeffecients;
        }

        private string[] removeCoeffecients(string[] substances) {
            string[] output = new string[substances.Length];

            for (int i = 0; i < substances.Length; i++) {
                // Remove first number, if it comes before a letter
                output[i] = Regex.Replace(substances[i], @"\G([^(A-Z)\d]*)\d","");
            }

            return output;
        }
        
        public string[] ParseInput(string input){
            input = input.Replace(" ", "");
            
            input = input.Replace("+", "");
            string[] split = Regex.Split(input, @"(?<!^)(?=[A-Z])|(?=[+])");
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