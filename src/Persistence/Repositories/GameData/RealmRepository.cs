using System;
using LaDanse.Domain.GameData.Entities;
using LaDanse.Domain.GameData.Repositories;
using LaDanse.Persistence.Repositories.Base;

namespace LaDanse.Persistence.Repositories.GameData
{
    public class RealmRepository : EfRepository<Guid, Realm>, IRealmRepository
    {
        public RealmRepository(LaDanseDbContext dbContext) : base(dbContext)
        {
        }
    }
}