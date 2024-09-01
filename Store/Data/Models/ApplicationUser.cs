﻿using Microsoft.AspNetCore.Identity;

namespace Store.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}