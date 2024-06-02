using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.Models;
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

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.View.Pages
{
    /// <summary>
    /// Interaction logic for CongTrinhPage.xaml
    /// </summary>
    public partial class CongTrinhPage : Page
    {
        private CongTrinhViewModel _viewModel;

        public CongTrinhPage()
        {
            InitializeComponent();
            //DataContext = new CongTrinhViewModel();
            _viewModel = new CongTrinhViewModel();
            DataContext = _viewModel;
        }

        private void btn_SuaCT_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedCongTrinh != null)
            {
                var suaCongTrinhWindow = new SuaCongTrinh(_viewModel.SelectedCongTrinh);
                suaCongTrinhWindow.ShowDialog();
                _viewModel.LoadData(); // Refresh data after editing
            }
            else
            {
                MessageBox.Show("Vui lòng chọn công trình cần sửa.");
            }

        }

        private void dtg_CongTrinh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtg_CongTrinh.SelectedItem is CongTrinh selectedCongTrinh)
            {
                _viewModel.SelectedCongTrinh = selectedCongTrinh;
            }
        }

        private void btn_ThemCT_Click(object sender, RoutedEventArgs e)
        {
            var themCongTrinhWindow = new ThemCongTrinh(_viewModel);
            themCongTrinhWindow.ShowDialog();
            _viewModel.LoadData(); // Refresh data after adding
        }

        private void btn_XoaCT_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedCongTrinh != null)
            {
                _viewModel.XoaCongTrinh(_viewModel.SelectedCongTrinh);
                _viewModel.LoadData(); // Refresh data after deleting
            }
            else
            {
                MessageBox.Show("Vui lòng chọn công trình cần xóa.");
            }
        }
    }
}
