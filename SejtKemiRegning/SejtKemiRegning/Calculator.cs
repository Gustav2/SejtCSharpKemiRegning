using System;
namespace SejtKemiRegning
{
    public class Calculator
    {
        public string[] parseInput(string input){
            input = input.Replace(" ", "");
            string[] inputArray = input.Split("+");
            return inputArray;
        }
    }
}