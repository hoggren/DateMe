﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.Models;

namespace Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext() : base("DefaultConnection")
        {
            
        }


    }
}