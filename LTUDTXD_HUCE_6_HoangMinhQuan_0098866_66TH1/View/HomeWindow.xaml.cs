using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.View;
using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.View.Pages;
using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            mainMenu.MouseEnter += (s, e) => mainMenu.IsExpanded = true;
            mainMenu.MouseLeave += (s, e) => mainMenu.IsExpanded = false;
            frame_Body.Content = new HomePage();
            DataContext = new HomeViewModel();

        }


       

        private void Button_DpiChanged(object senderF, DpiChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_CongTrinh_Click(object sender, RoutedEventArgs e)
        {
            frame_Body.Content = new CongTrinhPage();
        }

        private void Btn_Congtrinh_Click_1(object sender, RoutedEventArgs e)
        {
            frame_Body.Content = new CongTrinhPage();
        }

        private void btn_NhanVien_Click(object sender, RoutedEventArgs e)
        {
            frame_Body.Content = new NhanVienPage();
        }
    }
}
