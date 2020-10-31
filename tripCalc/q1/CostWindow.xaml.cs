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
using System.Windows.Shapes;

namespace q1
{
    /// <summary>
    /// Interaction logic for CostWindow.xaml
    /// </summary>
    public partial class CostWindow : Window
    {
        public CostWindow(VM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
