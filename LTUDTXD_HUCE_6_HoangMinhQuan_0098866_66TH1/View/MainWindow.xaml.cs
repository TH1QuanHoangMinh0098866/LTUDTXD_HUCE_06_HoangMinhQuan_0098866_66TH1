using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.View.Form;
using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.ViewModel;
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

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
            

        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel && sender is PasswordBox passwordBox)
            {
                string password = passwordBox.Password;
                viewModel.Password = password;
            }
        }


        private void txt_DangNhap_TextChanged(object sender, TextChangedEventArgs e)
        {
            string username = txt_DangNhap.Text;
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Username = username;
            }
        }

        private void btn_DangKy_Click(object sender, RoutedEventArgs e)
        {
            DangKyForm Dangkyform = new DangKyForm(); 
            Dangkyform.ShowDialog(); 
        }

        private void btn_QuenMK_Click(object sender, RoutedEventArgs e)
        {
            QuanMKForm quenmk = new QuanMKForm();
            quenmk.ShowDialog();
        }
    }
}