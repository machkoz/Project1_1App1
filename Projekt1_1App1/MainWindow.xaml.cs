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
        List<int> ResistorArrayNumbers24 = new List<int> { 10, 11, 12, 13, 15, 16, 18, 20, 22, 24, 27, 30, 33, 36, 39, 43, 47, 51, 56, 62, 68, 75, 82, 91 };
        List<int> ResistorArrayNumbers12 = new List<int> { 10, 12, 15, 18, 22, 27, 33, 39, 47, 56, 68, 82 };

        public MainWindow()
        {
            InitializeComponent();
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
            ResultR1.Content = Convert.ToDouble(ResistDuo.Text) * (Convert.ToDouble(ResuaSumma.Text)) / Convert.ToDouble(ResistDivide.Text);
            ResultR.Content = (Convert.ToDouble(ResuaSumma.Text)) - Convert.ToDouble(ResultR1.Content);

            double requestedValue = Convert.ToDouble(ResultR.Content);
            ResultViewRe.Content = FindValueNorm(requestedValue, ResistorArrayNumbers24);
            double requestedValue2 = Convert.ToDouble(ResultR1.Content);
            ResultViewRe1.Content = FindValueNorm(requestedValue2, ResistorArrayNumbers24);
            ResultVol.Content = (Convert.ToDouble(ResistDivide.Text) / (Convert.ToDouble(ResultViewRe.Content) + Convert.ToDouble(ResultViewRe1.Content))) * Convert.ToDouble(ResultViewRe1.Content);
            //double resultSuma1_a = (Convert.ToDouble(ResultViewRe.Content));
            //double resultSuma1_b = (Convert.ToDouble(ResultViewRe1.Content));
            ResultSuma1.Content = Convert.ToDouble(ResultViewRe.Content) + Convert.ToDouble(ResultViewRe1.Content);//= resultSuma1_a + resultSuma1_b;

            double requestedValue20 = Convert.ToDouble(ResultR.Content);
            ResultViewRe20.Content = FindValueNorm(requestedValue, ResistorArrayNumbers24, true);
            double requestedValue22 = Convert.ToDouble(ResultR1.Content);
            ResultViewRe21.Content = FindValueNorm(requestedValue2, ResistorArrayNumbers24, true);
            ResultVol20.Content = (Convert.ToDouble(ResistDivide.Text) / (Convert.ToDouble(ResultViewRe20.Content) + Convert.ToDouble(ResultViewRe21.Content))) * Convert.ToDouble(ResultViewRe21.Content);
            double resultSuma2_a = (Convert.ToDouble(ResultViewRe20.Content));
            double resultSuma2_b = (Convert.ToDouble(ResultViewRe21.Content));
            ResultSuma2.Content = resultSuma2_a + resultSuma2_b;

            double requestedValue30 = Convert.ToDouble(ResultR.Content);
            ResultViewRe30.Content = FindValueNorm(requestedValue, ResistorArrayNumbers24);
            double requestedValue32 = Convert.ToDouble(ResultR1.Content);
            ResultViewRe31.Content = FindValueNorm(requestedValue2, ResistorArrayNumbers24, true);
            ResultVol30.Content = (Convert.ToDouble(ResistDivide.Text) / (Convert.ToDouble(ResultViewRe30.Content) + Convert.ToDouble(ResultViewRe31.Content))) * Convert.ToDouble(ResultViewRe31.Content);
            double resultSuma3_a = (Convert.ToDouble(ResultViewRe30.Content));
            double resultSuma3_b = (Convert.ToDouble(ResultViewRe31.Content));
            ResultSuma3.Content = resultSuma3_a + resultSuma3_b;

            double requestedValue40 = Convert.ToDouble(ResultR.Content);
            ResultViewRe40.Content = FindValueNorm(requestedValue, ResistorArrayNumbers24, true);
            double requestedValue42 = Convert.ToDouble(ResultR1.Content);
            ResultViewRe41.Content = FindValueNorm(requestedValue2, ResistorArrayNumbers24);
            ResultVol40.Content = (Convert.ToDouble(ResistDivide.Text) / (Convert.ToDouble(ResultViewRe40.Content) + Convert.ToDouble(ResultViewRe41.Content))) * Convert.ToDouble(ResultViewRe41.Content);
            double resultSuma4_a = (Convert.ToDouble(ResultViewRe40.Content));
            double resultSuma4_b = (Convert.ToDouble(ResultViewRe41.Content));
            ResultSuma4.Content = resultSuma4_a + resultSuma4_b;


            double requestedValue_12 = Convert.ToDouble(ResultR.Content);
            ResultViewRe_12.Content = FindValueNorm(requestedValue, ResistorArrayNumbers12);
            double requestedValue2_12 = Convert.ToDouble(ResultR1.Content);
            ResultViewRe1_12.Content = FindValueNorm(requestedValue2, ResistorArrayNumbers12);
            ResultVol_12.Content = (Convert.ToDouble(ResistDivide.Text) / (Convert.ToDouble(ResultViewRe_12.Content) + Convert.ToDouble(ResultViewRe1_12.Content))) * Convert.ToDouble(ResultViewRe1_12.Content);
            //double resultSuma1_a = (Convert.ToDouble(ResultViewRe.Content));
            //double resultSuma1_b = (Convert.ToDouble(ResultViewRe1.Content));
            ResultSuma1_12.Content = Convert.ToDouble(ResultViewRe_12.Content) + Convert.ToDouble(ResultViewRe1_12.Content);//= resultSuma1_a + resultSuma1_b;

            double requestedValue20_12 = Convert.ToDouble(ResultR.Content);
            ResultViewRe20_12.Content = FindValueNorm(requestedValue, ResistorArrayNumbers12, true);
            double requestedValue22_12 = Convert.ToDouble(ResultR1.Content);
            ResultViewRe21_12.Content = FindValueNorm(requestedValue2, ResistorArrayNumbers12, true);
            ResultVol20_12.Content = (Convert.ToDouble(ResistDivide.Text) / (Convert.ToDouble(ResultViewRe20_12.Content) + Convert.ToDouble(ResultViewRe21_12.Content))) * Convert.ToDouble(ResultViewRe21_12.Content);
            double resultSuma2_a_12 = (Convert.ToDouble(ResultViewRe20_12.Content));
            double resultSuma2_b_12 = (Convert.ToDouble(ResultViewRe21_12.Content));
            ResultSuma2_12.Content = resultSuma2_a_12 + resultSuma2_b_12;

            double requestedValue30_12 = Convert.ToDouble(ResultR.Content);
            ResultViewRe30_12.Content = FindValueNorm(requestedValue, ResistorArrayNumbers12);
            double requestedValue32_12 = Convert.ToDouble(ResultR1.Content);
            ResultViewRe31_12.Content = FindValueNorm(requestedValue2, ResistorArrayNumbers12, true);
            ResultVol30_12.Content = (Convert.ToDouble(ResistDivide.Text) / (Convert.ToDouble(ResultViewRe30_12.Content) + Convert.ToDouble(ResultViewRe31_12.Content))) * Convert.ToDouble(ResultViewRe31_12.Content);
            double resultSuma3_a_12 = (Convert.ToDouble(ResultViewRe30_12.Content));
            double resultSuma3_b_12 = (Convert.ToDouble(ResultViewRe31_12.Content));
            ResultSuma3_12.Content = resultSuma3_a_12 + resultSuma3_b_12;

            double requestedValue40_12 = Convert.ToDouble(ResultR.Content);
            ResultViewRe40_12.Content = FindValueNorm(requestedValue, ResistorArrayNumbers12, true);
            double requestedValue42_12 = Convert.ToDouble(ResultR1.Content);
            ResultViewRe41_12.Content = FindValueNorm(requestedValue2, ResistorArrayNumbers12);
            ResultVol40_12.Content = (Convert.ToDouble(ResistDivide.Text) / (Convert.ToDouble(ResultViewRe40_12.Content) + Convert.ToDouble(ResultViewRe41_12.Content))) * Convert.ToDouble(ResultViewRe41_12.Content);
            double resultSuma4_a_12 = (Convert.ToDouble(ResultViewRe40_12.Content));
            double resultSuma4_b_12 = (Convert.ToDouble(ResultViewRe41_12.Content));
            ResultSuma4_12.Content = resultSuma4_a_12 + resultSuma4_b_12;

        }
    }
}

