namespace LaDanse.Common.Domain
{
    public class TemporalEntity<TKey> : BaseEntity<TKey>
    {
        public long ValidFrom { get; set; }
        
        public long? ValidUntil { get; set; }
    }
}