using System;
using System.Collections.Generic;
using System.Text;
using LaDanse.Domain.Common;
using LaDanse.Domain.GameData.Entities;

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
