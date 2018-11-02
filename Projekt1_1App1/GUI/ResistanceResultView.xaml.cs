using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Projekt1_1App1.GUI
{
    /// <summary>
    /// Logika interakcji dla klasy ResistanceResultView.xaml
    /// </summary>
    public partial class ResistanceResultView : UserControl, INotifyPropertyChanged

    {
        private string _title1 = "Wariant X";
        private double _resistor1;
        private double _resistor2;

        public string Title1
        {
            get => _title1;
            set
            {
                _title1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title1"));
            }
        }
        public double Resistor1
        {
            get => _resistor1;
            set
            {
                _resistor1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Resistor1"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SupplementaryResistance"));
            }
        }
        public double Resistor2
        {
            get => _resistor2;
            set
            {
                _resistor2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Resistor2"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SupplementaryResistance"));
            }
        }
        public double VoltageIn { get; set; }
        public double SupplementaryResistance => Resistor1 + Resistor2;
        public double VoltageOut => (VoltageIn / (Resistor1 + Resistor2)) * Resistor2;
        public ResistanceResultView()
        {
            InitializeComponent();
            DataContext = this;
        }


        public void SetValue(string header, double r1, double r2, double uwe)
        {

        }

        #region I Notify Property Changed implementation
        public bool SetFieldAndNotify<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
