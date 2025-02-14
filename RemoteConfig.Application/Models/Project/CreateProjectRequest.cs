using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Application.Models.Project
{
    public class CreateProjectRequest
    {
        [Required]
        public string CompanyId { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}