using System;
using LaDanse.Common.Abstractions;

namespace LaDanse.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}