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

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1
{
    /// <summary>
    /// Interaction logic for test2.xaml
    /// </summary>
    public partial class test2 : Window
    {
        public test2()
        {
            InitializeComponent();
            mainMenu.MouseEnter += (s, e) => mainMenu.IsExpanded = true;
            mainMenu.MouseLeave += (s, e) => mainMenu.IsExpanded = false;
        }
        
    }
}
