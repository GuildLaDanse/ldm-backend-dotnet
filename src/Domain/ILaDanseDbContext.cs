using LaDanse.Domain.GameData.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaDanse.Domain
{
    public interface ILaDanseDbContext
    {
        DbSet<Realm> Realms { get; set; }
    }
}