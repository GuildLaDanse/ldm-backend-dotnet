using LaDanse.Domain.Entities.Identity;

namespace LaDanse.External.Authorization.Abstractions
{
    public class SubjectReference
    {
        public User User { get; init; }
    }
}