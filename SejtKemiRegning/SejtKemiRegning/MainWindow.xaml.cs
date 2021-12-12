using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SejtKemiRegning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            Calculator calc = new Calculator();
            string subs = calc.convertToString(calc.Calculate(InputField.Text));
            OutputField.Text = subs;
        }
        
        private void ParseDict(object sender, RoutedEventArgs e)
        {
            var dict = InputOutput.CSVToDict(@"dims.csv");
            
            foreach (KeyValuePair<string, double> entry in dict)
            {
                OutputField.Text += entry.Key + ": " + entry.Value + "\n";
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            string[] arr = new []{"He", "H", "N", "O", "H", "O", "N", "H", "O", "N"};
            double[] arr2 = new double[] { 1, 5, 3, 2, 5, 6, 2, 3, 6, 5 };
            InputOutput.arrayToExcel(arr, arr2);
        }
    }
}