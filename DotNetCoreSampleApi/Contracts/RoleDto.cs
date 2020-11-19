using System;

namespace DotNetCoreSampleApi.Contracts
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}