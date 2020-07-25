﻿using Microsoft.AspNetCore.Identity;
using System;

namespace SupportService.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
