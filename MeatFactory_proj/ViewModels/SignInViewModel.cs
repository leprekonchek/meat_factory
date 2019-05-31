using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;
using MeatFactory_proj.Tools.Navigation;

namespace MeatFactory_proj.ViewModels
{
    internal class SignInViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _login;
        private string _password;
        #endregion

        #region Commands

        private RelayCommand<object> _signInCommand;

        #endregion

        #region Properties

        public string Login
        {
            get => _login;
            set
            {
                _login = value.Replace(" ", "Space");
                OnPropertyChanged();
            }
        }


        public RelayCommand<object> SignInCommand =>
            _signInCommand ?? (_signInCommand = new RelayCommand<object>(o => SignInImplementation(), o => CanExecute()));


        #endregion

        private bool CanExecute() => !String.IsNullOrEmpty(_login) && !string.IsNullOrEmpty(StationManager.Password.Password);

        private void SignInImplementation()
        {
            bool exists = StationManager.DataStorage.userExists(_login);
            if (exists)
            {
                string password = StationManager.DataStorage.getPassword(_login);
                if (password == StationManager.Password.Password)
                {
                    StationManager.CurrentUser = StationManager.DataStorage.getUser(_login); ;
                    NavigationManager.Instance.Navigate(ViewType.ProductView);
                }
                else { MessageBox.Show("Password is not correct"); }
            }
            else { MessageBox.Show("User not found"); }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}