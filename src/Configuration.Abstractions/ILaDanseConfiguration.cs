namespace LaDanse.Configuration.Abstractions
{
    public interface ILaDanseConfiguration
    {
        public string BaseUrl();

        public bool IsProduction();
        
        public IAuth0AdminConfiguration Auth0AdminConfiguration();

        public IBattleNetConfiguration BattleNetConfiguration();
    }
}