using System;
using System.Collections.Generic;
using System.Data;
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
        public MainWindow() {
            InitializeComponent();
        }

        private void Calc_Click(object sender, RoutedEventArgs e) {
            try {
                Calculator calc = new Calculator(InputField.Text);
                double[] molMassArray = calc.Calculate();
                string molMasses = calc.convertToString(molMassArray);
                if (molMassArray.Length > 1) {
                    DataTable dt = new DataTable();
                    var ex = dt.Compute(molMasses.Replace(",", "."), "");
                    OutputField.Text = $"{molMasses} = {ex}";
                }
                else {
                    OutputField.Text = molMasses;
                }
            }
            catch (Exception exception) {
                OutputField.Text = $"Error when calculating: {exception.Message}";
            }
            
        }
        
        private void Export_Click(object sender, RoutedEventArgs e) {
            try {
                Calculator calc = new Calculator(InputField.Text);
                string[] subs = calc.ParseInput(InputField.Text);
                double[] molMass = calc.Calculate();
                InputOutput.arrayToExcel(subs, molMass);
            }
            catch (Exception exception) {
                OutputField.Text = $"Error exporting to excel: {exception.Message}";
            }
            
        }

    }
}