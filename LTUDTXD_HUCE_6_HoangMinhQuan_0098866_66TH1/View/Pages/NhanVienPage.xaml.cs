﻿using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.ViewModel;
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
    /// Interaction logic for NhanVienPage.xaml
    /// </summary>
    public partial class NhanVienPage : Page
    {
        private NhanVienViewModel _viewModel;

        public NhanVienPage()
        {
            InitializeComponent();
            _viewModel = new NhanVienViewModel();
            DataContext = _viewModel;
        }

        private void btn_themnhanvien_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
