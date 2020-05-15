using System.Threading;
using System.Threading.Tasks;
using LaDanse.Domain.GameData.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaDanse.Application.Common.Interfaces
{
    public interface ILaDanseDbContext
    {
        DbSet<Realm> Realms { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}