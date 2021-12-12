using System;
using System.Data;
using System.Windows;

namespace SejtKemiRegning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
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
                succes.Visibility = Visibility.Visible;
            }
            catch (Exception exception) {
                OutputField.Text = $"Error exporting to excel: {exception.Message}";
            }
            
        }

    }
}