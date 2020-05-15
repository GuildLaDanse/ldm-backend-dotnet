using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LaDanse.Application.Common.Interfaces;
using LaDanse.Core.GameData.Models;
using LaDanse.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LaDanse.Application.GameData.Queries.GetAllRealms
{
    public class GetAllRealmsQuery : IRequest<IEnumerable<RealmDto>>
    {
        public class GetEmployeesListQueryHandler : IRequestHandler<GetAllRealmsQuery, IEnumerable<RealmDto>>
        {
            private readonly ILaDanseDbContext _context;

            public GetEmployeesListQueryHandler(ILaDanseDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<RealmDto>> Handle(GetAllRealmsQuery request, CancellationToken cancellationToken)
            {
                var realms = await _context.Realms
                    //.ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider)
                    .OrderBy(e => e.Name)
                    .ToListAsync(cancellationToken);

                var realmDtos = realms.Select(realm => new RealmDto
                {
                    Id = realm.Id,
                    Name = realm.Name,
                    GameId = realm.GameId
                });

                return realmDtos;
            }
        }
    }
}