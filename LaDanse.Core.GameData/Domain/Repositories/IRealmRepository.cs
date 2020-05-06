using System;
using System.Collections.Generic;
using System.Text;
using LaDanse.Common.Domain;
using LaDanse.Core.GameData.Domain.Entities;

namespace LaDanse.Core.GameData.Domain.Repositories
{
    public interface IRealmRepository : IRepository<Guid, Realm>, IAsyncRepository<Guid, Realm>
    {
    }
}
