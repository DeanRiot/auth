namespace Mail.Data
{
    public struct Credentials
    {
        public Credentials(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
