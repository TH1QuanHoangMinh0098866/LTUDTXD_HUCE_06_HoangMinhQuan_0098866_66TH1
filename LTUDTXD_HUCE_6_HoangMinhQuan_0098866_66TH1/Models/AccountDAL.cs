using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.Models
{
    public class AccountDAL
    {
        private static AccountDAL instance;

        public static AccountDAL Instance => instance ?? (instance = new AccountDAL());

        public List<Account> ConvertDBToList()
        {
            // Giả lập dữ liệu từ database
            return new List<Account>
        {
            new Account { Username = "admin", Password = MD5Hash("123456") },
            new Account { Username = "user", Password = MD5Hash("password") }
        };
        }

        private string MD5Hash(string input)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                var sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
