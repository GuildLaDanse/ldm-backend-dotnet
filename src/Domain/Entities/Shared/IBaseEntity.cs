namespace LaDanse.Domain.Entities.Shared
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}