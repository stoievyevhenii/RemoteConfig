using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Application.Models.AppConfiguration
{
    public class AppConfigurationValueDto
    {
        public string Description { get; set; }

        [Required]
        public string Value { get; set; }
    }
}