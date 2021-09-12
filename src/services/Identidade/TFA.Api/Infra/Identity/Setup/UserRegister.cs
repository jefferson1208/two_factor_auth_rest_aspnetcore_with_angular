using Microsoft.AspNetCore.Identity;
using System;

namespace TFA.Api.Infra.Identity.Setup
{
    public class UserRegister : IdentityUser<Guid>
    {
        public UserRegister()
        {
            Id = Guid.NewGuid();
        }
        public string FullName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
