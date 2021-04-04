namespace LaDanse.External.Authorization.Abstractions
{
    public class EvaluationCtx<TResourceKey, TResourceValue>
    {
        public SubjectReference SubjectReference { get; init; }
        
        public string Action { get; init; }
        
        public ResourceReference<TResourceKey> ResourceReference { private get; init; }
        
        public IResourceFinder<TResourceKey, TResourceValue> ResourceFinder { private get; init; }

        public TResourceValue GetResourceValue()
        {
            return ResourceFinder.GetResourceValue(ResourceReference);
        }
    }
}