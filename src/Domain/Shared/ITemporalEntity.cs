using System;

namespace LaDanse.Domain.Shared
{
    public interface ITemporalEntity
    {
        DateTime FromTime { get; set; }
        DateTime? EndTime { get; set; }
    }
}