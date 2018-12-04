using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        List<int> ResistorArrayNumbers24 = new List<int> { 10, 11, 12, 13, 15, 16, 18, 20, 22, 24, 27, 30, 33, 36, 39, 43, 47, 51, 56, 62, 68, 75, 82, 91 };
        List<int> ResistorArrayNumbers12 = new List<int> { 10, 12, 15, 18, 22, 27, 33, 39, 47, 56, 68, 82 };
        List<int> ResistorArrayNumbers06 = new List<int> { 10, 15, 22, 33, 47, 68 };
        List<int> ResistorArrayNumbers03 = new List<int> { 10, 22, 47 };

        private double _resistOne;
        private double _resistTwo;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SelectedRSeries { get; set; }
        public double SupplementaryResistance { get; set; }
        public double VoltageIn { get; set; }
        public double VoltageOut { get; set; }
        public double ResistOne
        {
            get => _resistOne;
            set
            {
                _resistOne = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResistOne"));
            }
        }

        public double ResistTwo
        {
            get => _resistTwo;
            set
            {
                _resistTwo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResistTwo"));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            //  FindNearestValueInR24(20);
        }
        public int FindNearestValueInR(double valueToFind, List<int> ResintanceSeries, double? exept = null)
        {
            var result = ResintanceSeries[0];
            for (int counter = 1; counter < ResintanceSeries.Count; counter++)
            {
                var resistToCompare = ResintanceSeries[counter];

                if ((exept.HasValue) && (resistToCompare == exept.Value)) continue;

                double dR1Result = Math.Abs(result - valueToFind);
                double dR2Result = Math.Abs(resistToCompare - valueToFind);
                if (dR1Result > dR2Result)
                {
                    result = resistToCompare;
                }
            }
            Debug.WriteLine(result);
            return result;
        }

        private double FindValueNorm(double valueToNorm, List<int> whichSeries, bool getSecondBest = false)
        {
            var tenExponent = (-1) * Math.Floor(Math.Log10(valueToNorm)) + 1;
            double normalizedValue = valueToNorm * Math.Pow(10, tenExponent);
            double firstFinded = 0;

            firstFinded = FindNearestValueInR(normalizedValue, whichSeries);
            var secondFinded = FindNearestValueInR(normalizedValue, whichSeries, firstFinded);
            if (getSecondBest)
            {
                return secondFinded * Math.Pow(10, -(tenExponent));
            }
            else
            {
                return firstFinded * Math.Pow(10, -(tenExponent));
            }
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            ResistTwo = VoltageOut * SupplementaryResistance / VoltageIn;
            ResistOne = SupplementaryResistance - ResistTwo;
            Debug.WriteLine("Wybrano szereg: " + SelectedRSeries);

            double requestedValue = ResistOne;
            double requestedValue2 = ResistTwo;
            List<int> ResistorArrayNumbers = new List<int> ();

            if (SelectedRSeries == "R24")
            {
                ResistorArrayNumbers = ResistorArrayNumbers24;
            }
            if (SelectedRSeries == "R06")
            {
                ResistorArrayNumbers = ResistorArrayNumbers06;
            }
            if (SelectedRSeries == "R03")
            {
                ResistorArrayNumbers = ResistorArrayNumbers03;
            }
            if (SelectedRSeries == "R12")
            {
                ResistorArrayNumbers = ResistorArrayNumbers12;
            }
                    
                
            
            R24_max_max.Resistor1 = FindValueNorm(requestedValue, ResistorArrayNumbers);
            R24_max_max.Resistor2 = FindValueNorm(requestedValue2, ResistorArrayNumbers);
            R24_max_max.VoltageIn = VoltageIn;

            R24_min_min.Resistor1 = FindValueNorm(requestedValue, ResistorArrayNumbers, true);
            R24_min_min.Resistor2 = FindValueNorm(requestedValue2, ResistorArrayNumbers, true);
            R24_min_min.VoltageIn = VoltageIn;

            R24_min_max.Resistor1 = FindValueNorm(requestedValue, ResistorArrayNumbers, true);
            R24_min_max.Resistor2 = FindValueNorm(requestedValue2, ResistorArrayNumbers);
            R24_min_max.VoltageIn = VoltageIn;

            R24_max_min.Resistor1 = FindValueNorm(requestedValue, ResistorArrayNumbers);
            R24_max_min.Resistor2 = FindValueNorm(requestedValue2, ResistorArrayNumbers, true);
            R24_max_min.VoltageIn = VoltageIn;


            //R12_max_max.Resistor1 = FindValueNorm(requestedValue, ResistorArrayNumbers12);
            //R12_max_max.Resistor2 = FindValueNorm(requestedValue2, ResistorArrayNumbers12);
            //R12_max_max.VoltageIn = VoltageIn;

            //R12_min_min.Resistor1 = FindValueNorm(requestedValue, ResistorArrayNumbers12, true);
            //R12_min_min.Resistor2 = FindValueNorm(requestedValue2, ResistorArrayNumbers12, true);
            //R12_min_min.VoltageIn = VoltageIn;

            //R12_min_max.Resistor1 = FindValueNorm(requestedValue, ResistorArrayNumbers12, true);
            //R12_min_max.Resistor2 = FindValueNorm(requestedValue2, ResistorArrayNumbers12);
            //R12_min_max.VoltageIn = VoltageIn;

            //R12_max_min.Resistor1 = FindValueNorm(requestedValue, ResistorArrayNumbers12);
            //R12_max_min.Resistor2 = FindValueNorm(requestedValue2, ResistorArrayNumbers12, true);
            //R12_max_min.VoltageIn = VoltageIn;
        }

    }
}

