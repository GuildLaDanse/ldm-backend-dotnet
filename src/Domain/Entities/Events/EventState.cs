namespace LaDanse.Domain.Entities.Events
{
    public enum EventState
    {
        Pending = 0,
        Confirmed = 1,
        Cancelled = 2,
        NotHappened = 3,
        Happened = 4,
        Deleted = 5,
        Archived = 6
    }
}