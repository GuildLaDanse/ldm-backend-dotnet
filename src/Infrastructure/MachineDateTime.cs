using System;
using LaDanse.Common;

namespace LaDanse.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}