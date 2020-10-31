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

//Tony Kwak
namespace q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindow mw = null;
        private void Window()
        {
            if (mw == null)
            {
                mw.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            }

        }
        VM vm = new VM();
        CostWindow cw = null;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cw == null)
            {
                cw = new CostWindow(vm);
                cw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                cw.Owner = this;
                cw.Closed += cw_Closed;
                cw.Show();
            }
        }

        private void cw_Closed(object sender, System.EventArgs e)
        {
            cw = null;
        }

    }
}

