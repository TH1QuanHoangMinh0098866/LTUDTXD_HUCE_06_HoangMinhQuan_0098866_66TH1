using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Input;
using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.Models;
using System.ComponentModel;
using System;

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.ViewModel
{
    public class NhanVienViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<NhanVien> _nhanViens;
        public ObservableCollection<NhanVien> NhanViens
        {
            get { return _nhanViens; }
            set { _nhanViens = value; OnPropertyChanged("NhanViens"); }
        }

        private NhanVien _selectedNhanVien;
        public NhanVien SelectedNhanVien
        {
            get { return _selectedNhanVien; }
            set { _selectedNhanVien = value; OnPropertyChanged("SelectedNhanVien"); }
        }

        public NhanVienViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FFM"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM NHANVIEN";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                NhanViens = new ObservableCollection<NhanVien>();
                while (reader.Read())
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNV = Convert.ToInt32(reader["MANV"]),
                        TenNV = reader["TENNV"].ToString(),
                        DiaChi = reader["DIACHI"].ToString(),
                        NgaySinh = DateTime.Parse(reader["NGAYSINH"].ToString()),
                        MaToDoi = Convert.ToInt32(reader["MATODOI"]),
                        MaCongTrinh = Convert.ToInt32(reader["MACONGTRINH"])
                    };
                    NhanViens.Add(nv);
                }
            }
        }

        public void ThemNhanVien(NhanVien nhanVien)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FFM"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO NHANVIEN (MANV, TENNV, DIACHI, NGAYSINH, MATODOI, MACONGTRINH) VALUES (@MaNV, @TenNV, @DiaChi, @NgaySinh, @MaToDoi, @MaCongTrinh)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                cmd.Parameters.AddWithValue("@DiaChi", nhanVien.DiaChi);
                cmd.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
                cmd.Parameters.AddWithValue("@MaToDoi", nhanVien.MaToDoi);
                cmd.Parameters.AddWithValue("@MaCongTrinh", nhanVien.MaCongTrinh);
                cmd.ExecuteNonQuery();

                NhanViens.Add(nhanVien);
            }
            LoadData();
        }

        public void SuaNhanVien(NhanVien nhanVien)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FFM"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE NHANVIEN SET TENNV = @TenNV, DIACHI = @DiaChi, NGAYSINH = @NgaySinh, MATODOI = @MaToDoi, MACONGTRINH = @MaCongTrinh WHERE MANV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                cmd.Parameters.AddWithValue("@DiaChi", nhanVien.DiaChi);
                cmd.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
                cmd.Parameters.AddWithValue("@MaToDoi", nhanVien.MaToDoi);
                cmd.Parameters.AddWithValue("@MaCongTrinh", nhanVien.MaCongTrinh);
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        public void XoaNhanVien(NhanVien nhanVien)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FFM"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM NHANVIEN WHERE MANV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
