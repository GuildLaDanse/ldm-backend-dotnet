using System;
using System.Collections.Generic;
using System.Text;
using LaDanse.Common.Domain;
using LaDanse.Core.GameData.Domain.Entities;

namespace LaDanse.Core.GameData.Domain.Specifications
{
    public sealed class AllRealmsSpecification : BaseSpecification<Realm>
    {
        public AllRealmsSpecification()
            : base(null)
        {
        }
    }
}
