using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;
using MeatFactory_proj.Tools.Navigation;

namespace MeatFactory_proj.ViewModels
{
    internal class SignInViewModel : INotifyPropertyChanged
    {
        public SignInViewModel()
        {
            Login = "dima";
        }

        #region Commands

        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _signUpCommand;

        #endregion

        #region Properties

        public string Login { get; set; }
  
        public RelayCommand<object> SignInCommand =>
            _signInCommand ?? (_signInCommand = new RelayCommand<object>(o => SignInImplementation(), o => CanExecute()));

        public RelayCommand<object> SignUpCommand =>
            _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(o => SignUpImplementation(), o => CanExecute()));

        #endregion

        private bool CanExecute() => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(StationManager.Password.Password);

        private void SignInImplementation()
        {
            bool exists = StationManager.DataStorage.userExists(Login);
            if (exists)
            {
                string password = StationManager.DataStorage.getPassword(Login);
                if (password == StationManager.Password.Password)
                {
                    StationManager.CurrentUser = StationManager.DataStorage.getUser(Login); ;
                    NavigationManager.Instance.Navigate(ViewType.ProductsAndComponentsView);
                }
                else { MessageBox.Show("Password is not correct"); }
            }
            else { MessageBox.Show("User not found"); }
        }

        private void SignUpImplementation()
        {
            StationManager.DataStorage.insertNewUser(Login, StationManager.Password.Password);
            MessageBox.Show("New user created!");
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