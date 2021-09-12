﻿using System;
using TFA.Api.Domain.Interfaces;

namespace TFA.Api.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string FullName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public void EnableTwoFactorAuthentication()
        {
            TwoFactorEnabled = true;
        }
    }
}
