using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using WPFCustomMessageBox;
using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.View;

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.m
{
    public class SQLConnection
    {
        private string strConn;
        public SqlConnection conn;

        public SQLConnection()
        {
            try
            {
                strConn = ConfigurationManager.ConnectionStrings["FFM"].ConnectionString;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Mất kết nối đến cơ sở dữ liệu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                throw ex;
            }

            conn = new SqlConnection(strConn);
        }

        public void OpenConnection()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["FFM"].ConnectionString;
                    conn.Open();
                }
            }
            catch (SqlException ex)
            {
                CustomMessageBox.Show("Mất kết nối đến cơ sở dữ liệu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                throw ex;
            }
        }

        public void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
