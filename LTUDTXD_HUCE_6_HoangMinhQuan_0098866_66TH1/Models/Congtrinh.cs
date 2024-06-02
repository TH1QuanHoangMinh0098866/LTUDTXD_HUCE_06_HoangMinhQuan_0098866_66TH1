// CongTrinh.cs
using System;
using System.ComponentModel;

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.Models
{
    public class CongTrinh : INotifyPropertyChanged
    {
        private string _maCongTrinh;
        public string MaCongTrinh
        {
            get { return _maCongTrinh; }
            set { _maCongTrinh = value; OnPropertyChanged("MaCongTrinh"); }
        }

        private string _tenCongTrinh;
        public string TenCongTrinh
        {
            get { return _tenCongTrinh; }
            set { _tenCongTrinh = value; OnPropertyChanged("TenCongTrinh"); }
        }

        private string _diaDiem;
        public string DiaDiem
        {
            get { return _diaDiem; }
            set { _diaDiem = value; OnPropertyChanged("DiaDiem"); }
        }

        private string _quanLy;
        public string QuanLy
        {
            get { return _quanLy; }
            set { _quanLy = value; OnPropertyChanged("QuanLy"); }
        }


        private DateTime _thoiGianBatDau;
        public DateTime ThoiGianBatDau
        {
            get { return _thoiGianBatDau; }
            set { _thoiGianBatDau = value; OnPropertyChanged("ThoiGianBatDau"); }
        }

        private DateTime _thoiGianKetThuc;
        public DateTime ThoiGianKetThuc
        {
            get { return _thoiGianKetThuc; }
            set { _thoiGianKetThuc = value; OnPropertyChanged("ThoiGianKetThuc"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
