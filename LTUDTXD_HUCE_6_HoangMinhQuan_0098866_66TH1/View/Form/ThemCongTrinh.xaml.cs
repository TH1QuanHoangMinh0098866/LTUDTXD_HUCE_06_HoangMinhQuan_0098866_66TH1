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
    /// <summary>
    /// Interaction logic for ThemCongTrinh.xaml
    /// </summary>
    public partial class ThemCongTrinh : Window
    {
        private CongTrinhViewModel _viewModel;

        public ThemCongTrinh(CongTrinhViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = new CongTrinh(); 

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Đặt giá trị ngày bắt đầu là 1/1/2024
            dpNgayBatDau.SelectedDate = new DateTime(2024, 1, 1);

            // Đặt giá trị ngày kết thúc là 6 tháng sau ngày bắt đầu
            dpNgayKetThuc.SelectedDate = dpNgayBatDau.SelectedDate.Value.AddMonths(6);
        }

        private void btnThoatThem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLuuThemCT_Click(object sender, RoutedEventArgs e)
        {
            var congTrinhMoi = DataContext as CongTrinh;

            if (congTrinhMoi != null)
            {
                // Kiểm tra xem đã nhập đầy đủ thông tin chưa
                if (string.IsNullOrEmpty(congTrinhMoi.MaCongTrinh) ||
                    string.IsNullOrEmpty(congTrinhMoi.TenCongTrinh) ||
                    string.IsNullOrEmpty(congTrinhMoi.DiaDiem) ||
                    string.IsNullOrEmpty(congTrinhMoi.QuanLy) ||
                    dpNgayBatDau.SelectedDate == null ||
                    dpNgayKetThuc.SelectedDate == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }

                if (dpNgayBatDau.SelectedDate == null || dpNgayKetThuc.SelectedDate == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày bắt đầu và ngày kết thúc hợp lệ.");
                    return;
                }

                congTrinhMoi.ThoiGianBatDau = dpNgayBatDau.SelectedDate.Value;
                congTrinhMoi.ThoiGianKetThuc = dpNgayKetThuc.SelectedDate.Value;

                _viewModel.ThemCongTrinh(congTrinhMoi);
                _viewModel.LoadData(); // Refresh data after adding
            }


            this.Close();

        }
    }
}
    
