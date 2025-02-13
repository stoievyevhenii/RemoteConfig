﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Application.Models.Company
{
    public class CreateCompanyRequest
    {
        [Required]
        public string Name { get; set; }
    }
}