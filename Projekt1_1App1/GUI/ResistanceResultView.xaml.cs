using System;
using System.Collections.Generic;
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

namespace Projekt1_1App1.GUI
{
    /// <summary>
    /// Logika interakcji dla klasy ResistanceResultView.xaml
    /// </summary>
    public partial class ResistanceResultView : UserControl
    {
        public ResistanceResultView()
        {
            InitializeComponent();
        }
        public void SetValue (string header, double r1, double r2, double uwe)
        {
            Title.Content = header;
            R1.Content = r1;
            R2.Content = r2;
            Voltage.Content = (uwe / (r1  + r2)) * r2;
            RResult.Content = r1 + r2;
        }
    }
}
