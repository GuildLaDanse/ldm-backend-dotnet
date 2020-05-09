using System;
using LaDanse.Domain.Common;
using LaDanse.Domain.GameData.Entities;

namespace LaDanse.Domain.GameData.Repositories
{
    public interface IRealmRepository : IRepository<Guid, Realm>, IAsyncRepository<Guid, Realm>
    {
    }
}
