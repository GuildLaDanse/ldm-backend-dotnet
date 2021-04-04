namespace LaDanse.External.Authorization.Abstractions
{
    public interface IResourceFinder<TResourceKey, out TResourceValue>
    {
        public TResourceValue GetResourceValue(ResourceReference<TResourceKey> resourceReference);
    }
}