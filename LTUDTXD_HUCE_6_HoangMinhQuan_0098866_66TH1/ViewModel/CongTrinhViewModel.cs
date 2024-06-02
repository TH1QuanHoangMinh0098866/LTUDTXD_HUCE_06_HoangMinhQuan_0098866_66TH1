
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Input;
using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.Models;
using System.ComponentModel;
using System;

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.ViewModel
{
    public class CongTrinhViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CongTrinh> _congTrinhs;
        public ObservableCollection<CongTrinh> CongTrinhs
        {
            get { return _congTrinhs; }
            set { _congTrinhs = value; OnPropertyChanged("CongTrinhs"); }
        }

        private CongTrinh _selectedCongTrinh;
        public CongTrinh SelectedCongTrinh
        {
            get { return _selectedCongTrinh; }
            set { _selectedCongTrinh = value; OnPropertyChanged("SelectedCongTrinh"); }
        }

        public CongTrinhViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FFM"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM CONGTRINH";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                CongTrinhs = new ObservableCollection<CongTrinh>();
                while (reader.Read())
                {
                    CongTrinh ct = new CongTrinh
                    {
                        MaCongTrinh = reader["MaCongTrinh"].ToString(),
                        TenCongTrinh = reader["TenCongTrinh"].ToString(),
                        DiaDiem = reader["DiaDiem"].ToString(),
                        QuanLy = reader["QuanLy"].ToString(),
                        ThoiGianBatDau = DateTime.Parse(reader["ThoiGianBatDau"].ToString()),
                        ThoiGianKetThuc = DateTime.Parse(reader["ThoiGianKetThuc"].ToString()),
                    };
                    CongTrinhs.Add(ct);
                }
            }
        }

        public void ThemCongTrinh(CongTrinh congTrinh)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FFM"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO CONGTRINH (MACONGTRINH, TENCONGTRINH, DIADIEM, QUANLY, THOIGIANBATDAU, THOIGIANKETTHUC) VALUES (@MaCongTrinh, @TenCongTrinh, @DiaDiem, @QuanLy, @ThoiGianBatDau, @ThoiGianKetThuc)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaCongTrinh", congTrinh.MaCongTrinh);
                cmd.Parameters.AddWithValue("@TenCongTrinh", congTrinh.TenCongTrinh);
                cmd.Parameters.AddWithValue("@DiaDiem", congTrinh.DiaDiem);
                cmd.Parameters.AddWithValue("@QuanLy", congTrinh.QuanLy);
                cmd.Parameters.AddWithValue("@ThoiGianBatDau", congTrinh.ThoiGianBatDau);
                cmd.Parameters.AddWithValue("@ThoiGianKetThuc", congTrinh.ThoiGianKetThuc);
                cmd.ExecuteNonQuery();

                CongTrinhs.Add(congTrinh);
            }
            LoadData(); 
        }

        public void SuaCongTrinh(CongTrinh congTrinh)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FFM"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE CONGTRINH SET TENCONGTRINH = @TenCongTrinh, DIADIEM = @DiaDiem, QUANLY = @QuanLy, THOIGIANBATDAU = @ThoiGianBatDau, THOIGIANKETTHUC = @ThoiGianKetThuc WHERE MACONGTRINH = @MaCongTrinh";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaCongTrinh", congTrinh.MaCongTrinh);
                cmd.Parameters.AddWithValue("@TenCongTrinh", congTrinh.TenCongTrinh);
                cmd.Parameters.AddWithValue("@DiaDiem", congTrinh.DiaDiem);
                cmd.Parameters.AddWithValue("@QuanLy", congTrinh.QuanLy);
                cmd.Parameters.AddWithValue("@ThoiGianBatDau", congTrinh.ThoiGianBatDau);
                cmd.Parameters.AddWithValue("@ThoiGianKetThuc", congTrinh.ThoiGianKetThuc);
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        public void XoaCongTrinh(CongTrinh congTrinh)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FFM"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM CONGTRINH WHERE MACONGTRINH = @MaCongTrinh";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaCongTrinh", congTrinh.MaCongTrinh);
                cmd.ExecuteNonQuery();
            } 
            LoadData(); // Load lại dữ liệu sau khi xóa
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
