namespace LaDanse.Domain.Common
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public long CreatedOn { get; set; }
    }
}