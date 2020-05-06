namespace LaDanse.Common.Domain
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public long CreatedOn { get; set; }
    }
}