namespace MeatFactory_proj.Models
{
    class User
    {
        private string _password;
        public string Login { get; set; }
        public string Role { get; set; }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                byte[] data = System.Text.Encoding.ASCII.GetBytes(_password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                string hash = System.Text.Encoding.ASCII.GetString(data);
                _password = hash;
            }
        }
    }
}
