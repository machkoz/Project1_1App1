using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

namespace Projekt1_1App1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FindNearestValueInR24(20);
        }
        public int FindNearestValueInR24(int valueToFind)
        {
            var ResistorArrayNumbers = new List<int> { 10, 11, 12, 13, 15, 16, 18, 20, 22, 24, 27, 30, 33, 36, 39, 43, 47, 51, 56, 62, 68, 75, 82, 91 };
            
            var result = ResistorArrayNumbers[0];
            for (int counter = 1; counter < ResistorArrayNumbers.Count; counter++)
            {
                var resistToCompare = ResistorArrayNumbers[counter];
                int dR1Result = Math.Abs(result - valueToFind);
                int dR2Result = Math.Abs(resistToCompare - valueToFind);
                if (dR1Result > dR2Result)
                {
                    result = resistToCompare;
                }
            }
            Debug.WriteLine(result);
            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int requestedValue = Convert.ToInt32(RequestedValue.Text);
            int findedValue = FindNearestValueInR24(requestedValue);
            ResultView.Content = findedValue;
        }
    }
}

