using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.Models;
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
using System.Windows.Shapes;

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.View.Form
{
    public partial class SuaCongTrinh : Window
    {
        private CongTrinh _congTrinh;

        public SuaCongTrinh(CongTrinh congTrinh)
        {
            InitializeComponent();
            _congTrinh = congTrinh;
            DataContext = _congTrinh;
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            CongTrinhViewModel viewModel = new CongTrinhViewModel();
            viewModel.SuaCongTrinh(_congTrinh);
            this.Close();
        }

       

        private void btn_ThoatSua_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
