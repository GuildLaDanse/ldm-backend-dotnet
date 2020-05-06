using System;
using Hermes.Persistence.Repositories.Base;
using LaDanse.Core.GameData.Domain.Entities;
using LaDanse.Core.GameData.Domain.Repositories;

namespace LaDanse.Persistence.Repositories.GameData
{
    public class RealmRepository : EfRepository<Guid, Realm>, IRealmRepository
    {
        public RealmRepository(LaDanseDbContext dbContext) : base(dbContext)
        {
        }
    }
}