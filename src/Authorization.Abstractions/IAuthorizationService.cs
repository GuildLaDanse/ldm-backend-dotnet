namespace LaDanse.External.Authorization.Abstractions
{
    public interface IAuthorizationService
    {
        public void AllowOrThrow<TResourceKey>(
            SubjectReference subject, 
            string action, 
            ResourceReference<TResourceKey> resource);
        
        public EvaluationResult Evaluate<TResourceKey>(
            SubjectReference subject, 
            string action,
            ResourceReference<TResourceKey> resource);
    }
}