using RemoteConfig.Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Application.Models.AppConfiguration
{
    public class CreateAppConfigurationRequest
    {
        [Required]
        public string Key { get; set; } = string.Empty;

        [Required]
        public string ProjectId { get; set; } = string.Empty;

        [Required]
        public IEnumerable<AppConfigurationValue> Values { get; set; } = [];
    }
}