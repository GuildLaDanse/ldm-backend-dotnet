namespace LaDanse.Domain.Common
{
    public class TemporalEntity<TKey> : BaseEntity<TKey>
    {
        public long ValidFrom { get; set; }
        
        public long? ValidUntil { get; set; }
    }
}