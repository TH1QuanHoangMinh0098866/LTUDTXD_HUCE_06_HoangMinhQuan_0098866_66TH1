using LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.View;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WPF.UI.MVVM.Command;

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string _selectedAction;

        public string SelectedAction
        {
            get => _selectedAction;
            set
            {
                _selectedAction = value;
                OnPropertyChanged();
                PerformAction();
            }
        }

        private void PerformAction()
        {
            throw new NotImplementedException();
        }

        public ICommand SelectCommand { get; }

        public HomeViewModel()
        {
            SelectCommand = new RelayCommand<string>(PerformAction);
        }

        private void PerformAction(string action)
        {
            switch (action)
            {
                case "Tài khoản":
                    ThongTinTaiKhoan accountPage = new ThongTinTaiKhoan();
                    accountPage.Show();
                 
                    break;
                case "Đăng xuất":
                    MainWindow loginPage = new MainWindow();
                    loginPage.Show();
                   
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}