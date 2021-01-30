using System;

namespace LaDanse.Domain.Entities.Shared
{
    public interface ITimeVersionedEntity
    {
        DateTime FromTime { get; set; }
        DateTime? EndTime { get; set; }
    }
}