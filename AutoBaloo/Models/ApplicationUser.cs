﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Nom Complet")]
        public string FullName { get; set; }
    }
}
