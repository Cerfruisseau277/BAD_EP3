﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string Firstname { get; set; }
        [PersonalData]
        public string LastName { get; set; }
    }
}
