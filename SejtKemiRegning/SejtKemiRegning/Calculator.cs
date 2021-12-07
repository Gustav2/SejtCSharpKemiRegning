namespace SejtKemiRegning
{
    public class Calculator
    {
        public string ParseInput(string input){
            input = input.Replace(" ", "");
            string[] inputArray = input.Split("+");
            return convertToString(inputArray);
        }
        
        public string convertToString(string[] inputArray){
            string output = "";
            foreach(string s in inputArray){
                output += s + " + ";
            }
            output = output.Remove(output.Length - 3, 3);
            return output;
        }
        
    }
}