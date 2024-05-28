using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;
using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.View;
using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.ViewModel;
using WPF.UI.MVVM.Command;
using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.Models;
using System.ComponentModel;


namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.ViewModel
{

    public class LoginViewModel : INotifyPropertyChanged
    {
        private string username;
        private string password;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<object>(ExecuteLogin, CanExecuteLogin);
        }

        private void ExecuteLogin(object parameter)
        {
            var loginWindow = parameter as MainWindow;
            if (loginWindow == null) return;

            List<Account> accounts = AccountDAL.Instance.ConvertDBToList();

            foreach (var account in accounts)
            {
                if (account.Username == Username && account.Password == MD5Hash(Password))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Tạo và hiển thị HomeWindow
                    HomeWindow homeWindow = new HomeWindow();
                    homeWindow.Show();

                    // Đóng cửa sổ đăng nhập hiện tại
                    loginWindow.Close();

                    return;
                }
            }

            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private bool CanExecuteLogin(object parameter)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

