using LaDanse.Common.Abstractions;
using PasswordGenerator;

namespace LaDanse.Infrastructure
{
    public class PasswordGenerator : IPasswordGenerator
    {
        public string Generate()
        {
            var pass = new Password()
                .IncludeNumeric()
                .IncludeLowercase()
                .IncludeUppercase()
                .IncludeSpecial()
                .LengthRequired(20);

            return pass.Next();
        }
    }
}