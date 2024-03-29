﻿using Core.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
        public required string FullName { get; set; }
        public UserStatus Status { get; set; }
        public Gender Gender { get; set; }
        public long CreatedDate { get; set; }
        public long UpdatedDate { get; set;}
    }
}
