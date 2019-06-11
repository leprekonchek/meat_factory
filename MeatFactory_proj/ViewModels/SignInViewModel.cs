using System.Windows;
using System.Windows.Input;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;
using MeatFactory_proj.Tools.Navigation;
using MeatFactory_proj.Views;

namespace MeatFactory_proj.ViewModels
{
    internal class SignInViewModel : PropertyChangedVM
    {
        public SignInViewModel()
        {
            Login = "sika";
            Role = "Адміністрaтор";
        }

        #region Commands

        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _signUpCommand;

        #endregion

        #region Properties

        public string Login { get; set; }
        public string Role { get; set; }

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
                string passwordDB = StationManager.DataStorage.getPassword(Login);

                // hashing
                string hash_password = StationManager.Password.Password;
                byte[] data = System.Text.Encoding.ASCII.GetBytes(hash_password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                hash_password = System.Text.Encoding.ASCII.GetString(data);

                if (passwordDB == hash_password)
                {
                    StationManager.CurrentUser = StationManager.DataStorage.getUser(Login);
                    //NavigationManager.Instance.Navigate(ViewType.ProductsAndComponentsView);
                    ProductsAndComponents win = new ProductsAndComponents();
                    Application.Current.Windows[0]?.Close();
                    win?.Show();
                }
                else { MessageBox.Show("Password is not correct"); }
            }
            else { MessageBox.Show("User not found"); }
        }

        private void SignUpImplementation()
        {
            string hash_password = StationManager.Password.Password;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(hash_password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            hash_password = System.Text.Encoding.ASCII.GetString(data);

            StationManager.DataStorage.insertNewUser(Login, hash_password, Role);
            MessageBox.Show("New user created!");
        }

    }
}