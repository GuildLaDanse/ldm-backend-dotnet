namespace LaDanse.Configuration.Abstractions
{
    public interface IAuth0AdminConfiguration
    {
        public string Domain();
        public string Audience();
        public string ClientId();
        public string ClientSecret();
        public string DefaultDatabaseConnection();
    }
}