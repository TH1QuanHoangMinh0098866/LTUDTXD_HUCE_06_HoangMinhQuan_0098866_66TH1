using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Chuỗi kết nối (connection string)
        string connectionString = "Server=QUAN;Database=DALT;User Id=sa;Password=12345678;";

        // Tạo đối tượng kết nối
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Mở kết nối
                connection.Open();
                Console.WriteLine("Kết nối thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
