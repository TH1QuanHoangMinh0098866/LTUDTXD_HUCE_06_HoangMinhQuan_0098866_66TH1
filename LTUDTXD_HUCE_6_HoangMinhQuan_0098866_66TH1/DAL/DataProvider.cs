using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.Models;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.m;

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.DAL
{
    public class DataProvider : SQLConnection
    {
        public DataTable LoadData(string tableName)
        {
            DataTable dt = new DataTable();
            CloseConnection();
            try
            {
                OpenConnection();
                string sql = "SELECT * FROM " + tableName;
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mất kết nối đến cơ sở dữ liệu! " + ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
    }
}